namespace DBManager.Model
{
    public partial class Transfer
    {
        public string GoodsId { get; set; } = null!;
        public string SellerAccountId { get; set; } = null!;
        public string BuyerAccountId { get; set; } = null!;
        public string TransactionCode { get; set; } = null!;
        public string? DigitalOrPhysical { get; set; }
        public double? Qty { get; set; }
        public bool? Successful { get; set; }
        public double? Payment { get; set; }
        public double? WageAmount { get; set; }
        public DateTime? Date { get; set; }
        public string? Sheba { get; set; }

        public virtual Externalaccount BuyerAccount { get; set; } = null!;
        public virtual Good Goods { get; set; } = null!;
        public virtual Externalaccount SellerAccount { get; set; } = null!;
        public virtual Eternalaccount? ShebaNavigation { get; set; }
    }
}
