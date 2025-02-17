using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.Console;
using Student_Management_System.Models;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;




internal class Program
{
    public static object Configuration { get; private set; }

    private static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        var configuration = builder.Configuration;

        Log.Logger = new LoggerConfiguration()
              .ReadFrom.Configuration(builder.Configuration)
              .CreateLogger();

        builder.Host.UseSerilog(); // Set Serilog as the logging provider

        //1. Add services to the container | Dbcontext
        builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("APPlicationDBCon"),
            sqlOptions => sqlOptions.CommandTimeout(1000)));

        //2. Identity
        builder.Services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
        builder.Services.AddControllers();

        //3. Authentication
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })

        //4. Add JWT bearer
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = configuration["JWT:ValidAudience"],
                ValidIssuer = configuration["JWT:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))

            };

        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        // 5. Swagger Authentication

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Wedding Planner API", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });
        });

        builder.Services.AddControllers();
            builder.Services.AddLogging();



        builder.Services.AddCors(p => p.AddPolicy("Corspolicy", build =>
        {
            build.WithOrigins("https://0.0.0.0:7159").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
           // build.WithOrigins("https://172.16.2.144/:5025").AllowAnyMethod().AllowAnyHeader();
        }));

        //builder.Services.AddCors(p => p.AddPolicy("Corspolicy", build =>
        //{
        //    build.AllowAnyOrigin()
        //         .AllowAnyMethod()
        //         .AllowAnyHeader();
        //}));


        var app = builder.Build();

        app.UseCors("Corspolicy");

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        app.Lifetime.ApplicationStopped.Register(Log.CloseAndFlush);


        app.Run();
    }
}