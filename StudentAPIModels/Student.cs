namespace StudentMinimalAPI.StudentAPIModels
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }
    }
}
