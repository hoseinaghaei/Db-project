namespace DBManager.ORM
{
    public partial class Transfer
    {
        public string Goodsid { get; set; } = null!;
        public string Selleraccountid { get; set; } = null!;
        public string Buyeraccountid { get; set; } = null!;
        public string Transactioncode { get; set; } = null!;
        public string? Digitalorphysical { get; set; }
        public double? Qty { get; set; }
        public bool? Successful { get; set; }
        public double? Payment { get; set; }
        public double? Wageamount { get; set; }
        public DateOnly? Date { get; set; }

        public virtual Externalaccount Buyeraccount { get; set; } = null!;
        public virtual Good Goods { get; set; } = null!;
        public virtual Externalaccount Selleraccount { get; set; } = null!;
    }
}
