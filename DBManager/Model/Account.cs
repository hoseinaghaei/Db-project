namespace DBManager.Model
{
    public partial class Account
    {
        public Account()
        {
            EternalAccounts = new HashSet<Eternalaccount>();
        }

        public string AccountId { get; set; } = null!;
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }

        public virtual Customer AccountNavigation { get; set; } = null!;
        public virtual Externalaccount ExternalAccount { get; set; } = null!;
        public virtual ICollection<Eternalaccount> EternalAccounts { get; set; }
    }
}
