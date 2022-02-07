namespace DBManager.Model
{
    public partial class Legalcustomer
    {
        public string LCustomerId { get; set; } = null!;
        public string RegisterCode { get; set; } = null!;
        public string? Manager { get; set; }
        public string? Fax { get; set; }

        public virtual Customer LCustomer { get; set; } = null!;
    }
}
