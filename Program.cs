using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.Console;
using Student_Management_System.Models;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using Microsoft.EntityFrameworkCore.SqlServer;



internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        Log.Logger = new LoggerConfiguration()
              .ReadFrom.Configuration(builder.Configuration)
              .CreateLogger();

        builder.Host.UseSerilog(); // Set Serilog as the logging provider

        // Add services to the container.
        builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("APPlicationDBCon"),
            sqlOptions => sqlOptions.CommandTimeout(1000)));
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
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