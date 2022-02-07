namespace DBManager.Model
{
    public partial class TodayPrice
    {
        public string? GoodsId { get; set; }
        public string? Name { get; set; }
        public byte[]? Image { get; set; }
        public double? RealTimePriceRial { get; set; }
    }
}
