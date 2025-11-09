using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StudentMinimalAPI.Data;
using StudentMinimalAPI.Interfaces;
using StudentMinimalAPI.Services;
using System.Reflection;

namespace StudentMinimalAPI.APIServices
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IStudentInterface, StudentService>();


            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Services.AddProblemDetails();
        }
    }
}
