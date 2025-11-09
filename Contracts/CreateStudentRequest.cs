namespace StudentMinimalAPI.Contracts
{
    public record CreateStudentRequest
    {
        public string FirstName { get; init; }

        public string MiddleName { get; init; }

        public string LastName { get; init; }

        public string EmailAddress { get; init; }

        public DateTime DateOfBirth { get; init; }

        public string Address { get; init; }
    }
}
