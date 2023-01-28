namespace CustomerApi.Model
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? EmailAddress { get; set; }
        public int Age { get; set; }
        public string? DateCreated { get; set; }

        public string? DateEdited { get; set; }
        public bool IsDeleted { get; set; }
    }
}
