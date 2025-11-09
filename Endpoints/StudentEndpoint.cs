using StudentMinimalAPI.Contracts;
using StudentMinimalAPI.Interfaces;

namespace StudentMinimalAPI.Endpoints
{
    public static class StudentEndpoint
    {
        public static IEndpointRouteBuilder MapStudentEndpoints(this IEndpointRouteBuilder app)
        {
            //Endpoint to add new Student
            app.MapPost("/students",async(CreateStudentRequest createstudentrequest,IStudentInterface studentservice)=>
            {
                var studentResponse = await studentservice.AddNewStudentAsync(createstudentrequest);
                return Results.Created($"/students/{studentResponse.Id}", studentResponse);
            });


            //Endpoint to get all Students
            app.MapGet("/students", async (IStudentInterface studentservice) =>
            {
                var students = await studentservice.GetStudentsAsync();
                return Results.Ok(students);
            });


            //Endpoint to update a student by ID
            app.MapPut("/students/{id}", async (int id, UpdateStudentRequest updatestudentrequest, IStudentInterface studentservice) =>
            {
                var updatedStudent = await studentservice.UpdateStudentAsync(id, updatestudentrequest);
                if (updatedStudent == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(updatedStudent);
            });

            //Endpoint to delete a student by ID
            app.MapDelete("/students/{id}", async (int id, IStudentInterface studentservice) =>
            {
                var isDeleted = await studentservice.DeleteStudentAsync(id);
                if (!isDeleted)
                {
                    return Results.NotFound();
                }
                return Results.NoContent();
            });

            //Endpoint to get a student by ID
            app.MapGet("/students/{id}", async (int id, IStudentInterface studentservice) =>
            {
                var student = await studentservice.GetStudentByIdAsync(id);
                if (student == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(student);
            });

            return app;
        }
    }
}
