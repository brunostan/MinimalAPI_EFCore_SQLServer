namespace PhonebookDB
{
    public record Contact
    {
        public int Id { get; set; } = 0;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string DDD { get; set; } = string.Empty;
    }
}