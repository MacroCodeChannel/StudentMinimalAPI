using StudentMinimalAPI.Contracts;
using StudentMinimalAPI.Data;
using StudentMinimalAPI.Interfaces;
using StudentMinimalAPI.StudentAPIModels;

namespace StudentMinimalAPI.Services
{
    public class StudentService : IStudentInterface
    {
        private readonly ApplicationDbContext _context;
        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<StudentResponse> AddNewStudentAsync(CreateStudentRequest createRequest)
        {
            try
            {
                var studentEntity = new Student
                {
                    FirstName = createRequest.FirstName,
                    MiddleName = createRequest.MiddleName,
                    LastName = createRequest.LastName,
                    EmailAddress = createRequest.EmailAddress,
                    DateOfBirth = createRequest.DateOfBirth,
                    Address = createRequest.Address
                };
                 _context.Students.Add(studentEntity);
                await _context.SaveChangesAsync();


                return new StudentResponse
                {
                    Id = studentEntity.Id,
                    FirstName = studentEntity.FirstName,
                    MiddleName = studentEntity.MiddleName,
                    LastName = studentEntity.LastName,
                    EmailAddress = studentEntity.EmailAddress,
                    DateOfBirth = studentEntity.DateOfBirth,
                    Address = studentEntity.Address
                };

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteStudentAsync(int Id)
        {
            try
            {
                var studentEntity = _context.Students.Find(Id);
                if (studentEntity == null)
                {
                    return false;
                }
                _context.Students.Remove(studentEntity);
               await  _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<StudentResponse> GetStudentByIdAsync(int Id)
        {
            try
            {
                var studentEntity = await _context.Students.FindAsync(Id);
                if (studentEntity == null)
                {
                    return null;
                }
                return new StudentResponse
                {
                    Id = studentEntity.Id,
                    FirstName = studentEntity.FirstName,
                    MiddleName = studentEntity.MiddleName,
                    LastName = studentEntity.LastName,
                    EmailAddress = studentEntity.EmailAddress,
                    DateOfBirth = studentEntity.DateOfBirth,
                    Address = studentEntity.Address
                };

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public  Task<IEnumerable<StudentResponse>> GetStudentsAsync()
        {
            try
            {
                var studentResponses = _context.Students.Select(studentEntity => new StudentResponse
                {
                    Id = studentEntity.Id,
                    FirstName = studentEntity.FirstName,
                    MiddleName = studentEntity.MiddleName,
                    LastName = studentEntity.LastName,
                    EmailAddress = studentEntity.EmailAddress,
                    DateOfBirth = studentEntity.DateOfBirth,
                    Address = studentEntity.Address
                }).ToList();
                return Task.FromResult<IEnumerable<StudentResponse>>(studentResponses);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<StudentResponse> UpdateStudentAsync(int id, UpdateStudentRequest updateStudent)
        {


            try
            {
                var studentEntity = await _context.Students.FindAsync(id);
                if (studentEntity == null)
                {
                    return null;
                }
                studentEntity.FirstName = updateStudent.FirstName;
                studentEntity.MiddleName = updateStudent.MiddleName;
                studentEntity.LastName = updateStudent.LastName;
                studentEntity.EmailAddress = updateStudent.EmailAddress;
                studentEntity.DateOfBirth = updateStudent.DateOfBirth;
                studentEntity.Address = updateStudent.Address;
                await _context.SaveChangesAsync();

                return new StudentResponse
                {
                    Id = studentEntity.Id,
                    FirstName = studentEntity.FirstName,
                    MiddleName = studentEntity.MiddleName,
                    LastName = studentEntity.LastName,
                    EmailAddress = studentEntity.EmailAddress,
                    DateOfBirth = studentEntity.DateOfBirth,
                    Address = studentEntity.Address
                };

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
