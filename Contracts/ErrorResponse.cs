namespace StudentMinimalAPI.Contracts
{
    public record ErrorResponse
    {
        public string Title { get; set; }
        public string ErrorMessage { get; set; }
        public string StatusCode { get; set; }

    }
}
