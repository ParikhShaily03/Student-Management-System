using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.DataProtection;
using Serilog.Events;
using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Student_Management_System.Data;
using Student_Management_System.Models;
using Student_Management_System.Model;
using Student_Management_System.Repositories;
using Student_Management_System.Repositories.Irepositories;
using Student_Management_System.Middleware;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.EventLog;
using Student_Management_System.Service;
using System.Collections.ObjectModel;
using System.Data;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
//using StudentManagement.Data;y



var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ✅ Configure Serilog
Log.Logger = new LoggerConfiguration()
    /* .readfrom.configuration(builder.configuration)*/ // read settings from appsettings.json
    .WriteTo.Console() // log to console
    .WriteTo.EventLog("student_management_system", manageEventSource: true, restrictedToMinimumLevel: LogEventLevel.Warning)
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
            //ValidIssuer = jwtSettings["Issuer"],
            //ValidAudience = jwtSettings["Audience"],
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });
Console.WriteLine($"Key Length: {key.Length * 8} bits");


// Register the repository and services
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<PermissionHandler>();

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("PermissionPolicy", policy =>
//        policy.Requirements.Add(new AuthorizePermissionAttribute(PermissionType.ViewUsers)));
//});

// Register the HttpContextAccessor

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IAuthorizationHandler, PermissionHandler>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddScoped<IRoleRepository, RoleRepository>();
//builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
//builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();

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


// Add middleware

//builder.Services.AddScoped<PermissionMiddleware>();

//builder.Services.AddScoped<RoleMiddleware>();

//builder.Services.AddScoped<LoggingMiddleware>();


var app = builder.Build();





// Use the CORS policy
app.UseCors("AllowAll");

// Token Validation Middleware (Authentication)
app.UseAuthentication();

app.UseRouting();


// Role Middleware (Optional, for role-based authorization)
app.UseMiddleware<RoleMiddleware>();

// Permission Middleware (for dynamic permission validation)
app.UseMiddleware<PermissionMiddleware>();

// Logging Middleware (for logging requests)
app.UseMiddleware<LoggingMiddleware>();

// Use Authorization to apply the permission policies
app.UseAuthorization();

// Enable Swagger UI for API documentation in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Map API controllers
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
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




