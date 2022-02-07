namespace DBManager.Model
{
    public partial class Fiatmoney
    {
        public string FiatMoneyId { get; set; } = null!;
        public string? Government { get; set; }

        public virtual Good FiatMoneyNavigation { get; set; } = null!;
    }
}
