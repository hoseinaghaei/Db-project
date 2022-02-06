namespace DBManager.ORM
{
    public partial class Goodsprice
    {
        public string Priceid { get; set; } = null!;
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public double? RealTimePriceDollar { get; set; }
        public double? RealTimePriceRial { get; set; }
        public double? DifferenceRateThanYesterday { get; set; }
        public DateOnly? LastChanged { get; set; }
        public double? TheLeastPrice { get; set; }
        public double? TheMostPrice { get; set; }

        public virtual Good Price { get; set; } = null!;
    }
}
