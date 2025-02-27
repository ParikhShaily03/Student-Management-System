//using Microsoft.EntityFrameworkCore;
//using Microsoft.OpenApi.Models;
//using StudentManagement.Data;

//var builder = WebApplication.CreateBuilder(args);

//// Add services
//builder.Services.AddControllers();
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//// Enable CORS
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll", builder =>
//        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//});

//// Add Swagger
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Student API", Version = "v1" });
//});

//var app = builder.Build();

//// Configure middleware
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseCors("AllowAll");
//app.UseAuthorization();
//app.MapControllers();
//app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StudentManagement.Model;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using StudentManagement.Models;
using Student_Management_System.Models;
using Microsoft.AspNetCore.DataProtection;
using Serilog.Events;
using Serilog;
using Microsoft.Extensions.DependencyInjection;
//using StudentManagement.Data;


var builder = WebApplication.CreateBuilder(args);

// ✅ Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration) // Read settings from appsettings.json
    .WriteTo.Console() // Log to console
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day) // Log to file
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning) // Reduce log verbosity for Microsoft logs
    .CreateLogger();

builder.Host.UseSerilog();


// Register ApplicationDbContext (placed in Models folder)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//Added Identity
builder.Services.AddIdentity<User, IdentityRole>()
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS.
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

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




