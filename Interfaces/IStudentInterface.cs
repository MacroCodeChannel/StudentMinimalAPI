using StudentMinimalAPI.Contracts;

namespace StudentMinimalAPI.Interfaces
{
    public interface IStudentInterface
    {
        Task<StudentResponse> AddNewStudentAsync(CreateStudentRequest createRequest);

        Task<StudentResponse> GetStudentByIdAsync(int Id);

        Task<IEnumerable<StudentResponse>> GetStudentsAsync();

        Task<StudentResponse> UpdateStudentAsync(int id,UpdateStudentRequest updateStudent);

        Task<bool> DeleteStudentAsync(int Id);
    }
}
