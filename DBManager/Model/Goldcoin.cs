namespace DBManager.Model
{
    public partial class Goldcoin
    {
        public string GoldCoinId { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int Carat { get; set; }
        
        public virtual Coin GoldCoinNavigation { get; set; } = null!;
    }
}
