namespace DBManager.ORM
{
    public partial class Parsiancoin
    {
        public string Parsiancoinid { get; set; } = null!;
        public double Weight { get; set; }

        public virtual Coin ParsiancoinNavigation { get; set; } = null!;
    }
}
