namespace DBManager.Model
{
    public partial class Coin
    {
        public Coin()
        {
            GoldCoins = new HashSet<Goldcoin>();
            PersianCoins = new HashSet<Parsiancoin>();
        }

        public string CoinId { get; set; } = null!;
        public double? Tax { get; set; }

        public virtual Good CoinNavigation { get; set; } = null!;
        public virtual ICollection<Goldcoin> GoldCoins { get; set; }
        public virtual ICollection<Parsiancoin> PersianCoins { get; set; }
    }
}
