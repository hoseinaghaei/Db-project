namespace DBManager.Model
{
    public partial class Existence
    {
        public string GoodsId { get; set; } = null!;
        public string AccountId { get; set; } = null!;
        public double? Qty { get; set; }

        public virtual Externalaccount Account { get; set; } = null!;
        public virtual Good Goods { get; set; } = null!;
    }
}
