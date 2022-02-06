namespace DBManager.ORM
{
    public partial class Externalaccount
    {
        public Externalaccount()
        {
            Buys = new HashSet<Buy>();
            Existences = new HashSet<Existence>();
            Sells = new HashSet<Sell>();
            TransferBuyeraccounts = new HashSet<Transfer>();
            TransferSelleraccounts = new HashSet<Transfer>();
        }

        public string Exaccountid { get; set; } = null!;
        public string? Fulladdress { get; set; }

        public virtual Account Exaccount { get; set; } = null!;
        public virtual ICollection<Buy> Buys { get; set; }
        public virtual ICollection<Existence> Existences { get; set; }
        public virtual ICollection<Sell> Sells { get; set; }
        public virtual ICollection<Transfer> TransferBuyeraccounts { get; set; }
        public virtual ICollection<Transfer> TransferSelleraccounts { get; set; }
    }
}
