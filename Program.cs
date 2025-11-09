using Microsoft.EntityFrameworkCore;
using StudentMinimalAPI.APIServices;
using StudentMinimalAPI.Data;
using StudentMinimalAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.AddApplicationServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapGroup("/api/students")
   .WithTags("Student Endpoints")
   .MapStudentEndpoints();

app.Run();


