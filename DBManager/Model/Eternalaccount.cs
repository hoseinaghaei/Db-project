namespace DBManager.Model
{
    public partial class Eternalaccount
    {
        public Eternalaccount()
        {
            Buys = new HashSet<Buy>();
            Transfers = new HashSet<Transfer>();
        }

        public string? EAccountId { get; set; }
        public string Sheba { get; set; } = null!;
        public bool? TransactionPermission { get; set; }

        public virtual Account? EAccount { get; set; }
        public virtual ICollection<Buy> Buys { get; set; }
        public virtual ICollection<Transfer> Transfers { get; set; }
    }
}
