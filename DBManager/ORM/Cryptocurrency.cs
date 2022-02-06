namespace DBManager.ORM
{
    public partial class Cryptocurrency
    {
        public string Cryptocurrencyid { get; set; } = null!;
        public int? Age { get; set; }

        public virtual Good CryptocurrencyNavigation { get; set; } = null!;
    }
}
