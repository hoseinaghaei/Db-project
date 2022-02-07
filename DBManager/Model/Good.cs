namespace DBManager.Model
{
    public partial class Good
    {
        public Good()
        {
            Buys = new HashSet<Buy>();
            Existences = new HashSet<Existence>();
            GoodsPrices = new HashSet<Goodsprice>();
            Sells = new HashSet<Sell>();
            Transfers = new HashSet<Transfer>();
        }

        public string GoodsId { get; set; } = null!;
        public string? Name { get; set; }
        public byte[]? Image { get; set; }
        public double? Qty { get; set; }
        public double? Wage { get; set; }

        public virtual Coin Coin { get; set; } = null!;
        public virtual Cryptocurrency Cryptocurrency { get; set; } = null!;
        public virtual Fiatmoney FiatMoney { get; set; } = null!;
        public virtual ICollection<Buy> Buys { get; set; }
        public virtual ICollection<Existence> Existences { get; set; }
        public virtual ICollection<Goodsprice> GoodsPrices { get; set; }
        public virtual ICollection<Sell> Sells { get; set; }
        public virtual ICollection<Transfer> Transfers { get; set; }
    }
}
