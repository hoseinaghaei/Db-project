namespace DBManager.Model
{
    public partial class Parsiancoin
    {
        public string PersianCoinId { get; set; } = null!;
        public double Weight { get; set; }

        public virtual Coin PersianCoinNavigation { get; set; } = null!;
    }
}
