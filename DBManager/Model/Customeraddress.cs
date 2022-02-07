namespace DBManager.Model
{
    public partial class Customeraddress
    {
        public string AddressId { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Postalcode { get; set; } = null!;
        public double? Tag { get; set; }
        public string? FullAddress { get; set; }

        public virtual Customer Address { get; set; } = null!;
    }
}
