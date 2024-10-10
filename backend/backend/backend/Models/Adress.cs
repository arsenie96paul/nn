namespace backend.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        // Foreign key for Person
        public int PersonId { get; set; }
        // Navigation property to Person
        public Person Person { get; set; }  // Added this line
    }
}