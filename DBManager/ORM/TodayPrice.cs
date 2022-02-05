using System;
using System.Collections.Generic;

namespace DBManager
{
    public partial class TodayPrice
    {
        public string? Goodsid { get; set; }
        public string? Name { get; set; }
        public byte[]? Image { get; set; }
        public double? RealTimePriceRial { get; set; }
    }
}
