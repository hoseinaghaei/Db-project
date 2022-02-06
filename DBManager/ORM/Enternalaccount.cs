namespace DBManager.ORM
{
    public partial class Enternalaccount
    {
        public string Enaccountid { get; set; } = null!;
        public string Sheba { get; set; } = null!;
        public bool? Approval { get; set; }
        public bool? Transactionpermission { get; set; }
        public string? Bank { get; set; }

        public virtual Account Enaccount { get; set; } = null!;
    }
}
