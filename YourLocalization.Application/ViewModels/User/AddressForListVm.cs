namespace YourLocalization.Application.ViewModels.User
{
    public class AddressForListVm
    {
        public int Id { get; set; }
        public string NameAddress { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public int? FlatNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}