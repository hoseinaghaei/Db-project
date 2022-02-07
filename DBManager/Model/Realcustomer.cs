namespace DBManager.Model
{
    public partial class Realcustomer
    {
        public string RCustomerId { get; set; } = null!;
        public string? MelliCode { get; set; }
        public int? Age { get; set; }

        public virtual Customer RCustomer { get; set; } = null!;
    }
}
