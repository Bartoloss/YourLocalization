namespace YourLocalization.Domain.Model
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public int? FlatNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}