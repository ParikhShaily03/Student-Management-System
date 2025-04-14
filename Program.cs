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
using System.Collections.ObjectModel;
using System.Data;
//using StudentManagement.Data;y



var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//// ✅ Configure Serilog
//Log.Logger = new LoggerConfiguration()
//    /* .readfrom.configuration(builder.configuration)*/ // read settings from appsettings.json
//    .WriteTo.Console() // log to console
//    .WriteTo.EventLog("student_management_system", manageEventSource: true, restrictedToMinimumLevel: LogEventLevel.Warning)
//    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day) // log to file
//    .WriteTo.MSSqlServer
//    (
//    connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
//    sinkOptions: new MSSqlServerSinkOptions
//    {
//        TableName = "logs",
//        AutoCreateSqlTable = true,
//    },
//    columnOptions: GetSqlColumnOptions()
//    )

//    .CreateLogger();

//builder.Host.UseSerilog();


// Register ApplicationDbContext (placed in Models folder)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped(typeof(IUser<>), typeof(UserRepo<>));


//Added Identity
builder.Services.AddIdentity<User, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

//JWT AUthentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
//var key = Encoding.UTF8.GetBytes(jwtSettings["Secret"]);

//var key = Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Secret"]); // 🔥 Ensure key is 32+ chars

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


// Enable CORS for frontend integration.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
// Add services to the container.
builder.Services.AddControllers();


// Add Swagger for API documentation.
builder.Services.AddEndpointsApiExplorer();



//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Student API", Version = "v1" });
//});

builder.Services.AddScoped<IRoleRepository, RoleRepository>();

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


var app = builder.Build();





app.UseRouting();


app.UseCors("AllowAll");
app.UseMiddleware<TokenValidationMiddleware>();
app.UseAuthentication();  // Ensure Authentication comes first
app.UseAuthorization();   // Then Authorization

app.UseMiddleware<RoleMiddleware>();
app.UseRoleMiddleware();
app.UseMiddleware<LoggingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseSwagger();
//app.UseSwaggerUI();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
//app.MapControllers();

//app.Run();
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




