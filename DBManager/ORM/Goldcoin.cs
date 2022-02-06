namespace DBManager.ORM
{
    public partial class Goldcoin
    {
        public string Goldcoinid { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int Carat { get; set; }

        public virtual Coin GoldcoinNavigation { get; set; } = null!;
    }
}
