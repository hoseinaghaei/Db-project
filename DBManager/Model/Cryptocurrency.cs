namespace DBManager.Model
{
    public partial class Cryptocurrency
    {
        public string CryptocurrencyId { get; set; } = null!;
        public int? Age { get; set; }

        public virtual Good CryptocurrencyNavigation { get; set; } = null!;
    }
}
