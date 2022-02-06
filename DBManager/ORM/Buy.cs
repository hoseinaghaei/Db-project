namespace DBManager.ORM
{
    public partial class Buy
    {
        public string Goodsid { get; set; } = null!;
        public string Accountid { get; set; } = null!;
        public string Transactioncode { get; set; } = null!;
        public string? Digitalorphysical { get; set; }
        public double? Qty { get; set; }
        public bool? Successful { get; set; }
        public double? Payment { get; set; }
        public int? Score { get; set; }
        public DateOnly Date { get; set; }

        public virtual Externalaccount Account { get; set; } = null!;
        public virtual Good Goods { get; set; } = null!;
    }
}
