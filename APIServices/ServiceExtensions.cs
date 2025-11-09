using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentMinimalAPI.Data;
using StudentMinimalAPI.Interfaces;
using StudentMinimalAPI.Options;
using StudentMinimalAPI.Services;
using System.Reflection;

namespace StudentMinimalAPI.APIServices
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            builder.Services.ConfigureOptions<DatabaseOptionsSetup>();
            
            builder.Services.AddDbContext<ApplicationDbContext>(
            (serviceprovider, options) =>
            {
                var databaseoptions = serviceprovider.GetService<IOptions<DatabaseOptions>>()!.Value;

                options.UseSqlServer(databaseoptions.ConnectionString, sqlserverconnection=>
                {
                    sqlserverconnection.EnableRetryOnFailure(databaseoptions.MaxRetryCount);
                    sqlserverconnection.CommandTimeout(databaseoptions.CommandTimeout);
                });

                options.EnableDetailedErrors(databaseoptions.EnabledDetailedErrors);
                options.EnableSensitiveDataLogging(databaseoptions.EnableSensitiveDataLogging);
            });

            builder.Services.AddScoped<IStudentInterface, StudentService>();


            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Services.AddProblemDetails();
        }
    }
}
