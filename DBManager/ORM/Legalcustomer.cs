namespace DBManager.ORM
{
    public partial class Legalcustomer
    {
        public string Lcustomerid { get; set; } = null!;
        public string Registerycode { get; set; } = null!;
        public string? Manager { get; set; }
        public string? Fax { get; set; }

        public virtual Customer Lcustomer { get; set; } = null!;
    }
}
