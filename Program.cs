using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.EventLog;
using Serilog.Sinks.MSSqlServer;
using Student_Management_System.Data;
using Student_Management_System.Hubs;
using Student_Management_System.Middleware;
using Student_Management_System.Model;
using Student_Management_System.Models;
using Student_Management_System.Repositories;
using Student_Management_System.Repositories.Irepositories;
using Student_Management_System.Service;
using System.Collections.ObjectModel;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Text;




var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ✅ Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console() // log to console
    .WriteTo.EventLog("student_management_system", restrictedToMinimumLevel: LogEventLevel.Warning)

    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day) // log to file
    .WriteTo.MSSqlServer
    (
    connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
    sinkOptions: new MSSqlServerSinkOptions
    {
        TableName = "logs",
        AutoCreateSqlTable = true,
    },
    columnOptions: GetSqlColumnOptions()
    )

    .CreateLogger();

builder.Host.UseSerilog();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped(typeof(IUser<>), typeof(UserRepo<>));


builder.Services.AddIdentity<User, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["Secret"];
if (string.IsNullOrEmpty(secretKey) || secretKey.Length < 32)
{
    throw new Exception("JWT Secret Key is too short. Must be at least 32 characters.");
}

var key = Encoding.UTF8.GetBytes(secretKey);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };

        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = async context =>
            {
                var dbContext = context.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
                var token = context.SecurityToken as JwtSecurityToken;

                if (token != null)
                {
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                    var isRevoked = await dbContext.RevokedTokens.AnyAsync(rt => rt.Token == tokenString);
                    if (isRevoked)
                    {
                        context.Fail("This token has been revoked.");
                    }
                }
            }
        };
    });
Console.WriteLine($"Key Length: {key.Length * 8} bits");


// Register the repository and services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<PermissionHandler>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<IEmailService, EmailService>();


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IAuthorizationHandler, PermissionHandler>();



builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader();


    });
});



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "JWT Authorization header",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.AddSignalR();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IChatService, ChatService>();


var app = builder.Build();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().WithExposedHeaders("content-disposition"));

app.UseMiddleware<TokenValidationMiddleware>();

app.UseAuthentication();

app.UseRouting();

app.UseMiddleware<RoleMiddleware>();

app.UseMiddleware<PermissionMiddleware>();

app.UseMiddleware<LoggingMiddleware>();

app.UseAuthorization();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

// Map API controllers
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapHub<NotificationHub>("/hubs/notifications");
app.MapHub<ChatHub>("/hubs/chat");


try
{
    Log.Information("Starting the application...");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly.");
}
finally
{
    Log.CloseAndFlush();
}

app.Run(async context =>
{
    var env = app.Services.GetRequiredService<IWebHostEnvironment>();
    context.Response.ContentType = "text/html";
    await context.Response.SendFileAsync(Path.Combine(env.WebRootPath, "index.html"));
});




ColumnOptions GetSqlColumnOptions()
{
    var columnOptions = new ColumnOptions();
    columnOptions.Store.Remove(StandardColumn.Properties);
    columnOptions.Store.Remove(StandardColumn.MessageTemplate);
    columnOptions.Store.Add(StandardColumn.LogEvent);

    columnOptions.AdditionalColumns = new Collection<SqlColumn>
    {
        new SqlColumn { ColumnName = "UserId", DataType = SqlDbType.NVarChar, AllowNull = true, DataLength = 450 },
        new SqlColumn { ColumnName = "RequestPath", DataType = SqlDbType.NVarChar, AllowNull = true, DataLength = 2048 },
    };

    return columnOptions;
}




