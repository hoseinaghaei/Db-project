namespace DBManager.Model
{
    public partial class Externalaccount
    {
        public Externalaccount()
        {
            Buys = new HashSet<Buy>();
            Existences = new HashSet<Existence>();
            Sells = new HashSet<Sell>();
            TransferBuyerAccounts = new HashSet<Transfer>();
            TransferSellerAccounts = new HashSet<Transfer>();
        }

        public string ExAccountId { get; set; } = null!;
        public string? FullAddress { get; set; }
        public bool? Approval { get; set; }

        public virtual Account ExAccount { get; set; } = null!;
        public virtual ICollection<Buy> Buys { get; set; }
        public virtual ICollection<Existence> Existences { get; set; }
        public virtual ICollection<Sell> Sells { get; set; }
        public virtual ICollection<Transfer> TransferBuyerAccounts { get; set; }
        public virtual ICollection<Transfer> TransferSellerAccounts { get; set; }
    }
}
