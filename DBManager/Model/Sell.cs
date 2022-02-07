namespace DBManager.Model
{
    public partial class Sell
    {
        public string GoodsId { get; set; } = null!;
        public string AccountId { get; set; } = null!;
        public string TransactionCode { get; set; } = null!;
        public string? DigitalOrPhysical { get; set; }
        public double? Qty { get; set; }
        public bool? Successful { get; set; }
        public double? Payment { get; set; }
        public int? Score { get; set; }
        public DateTime? Date { get; set; }

        public virtual Externalaccount Account { get; set; } = null!;
        public virtual Good Goods { get; set; } = null!;
    }
}
