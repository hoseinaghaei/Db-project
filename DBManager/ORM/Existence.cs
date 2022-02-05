using System;
using System.Collections.Generic;

namespace DBManager
{
    public partial class Existence
    {
        public string Goodsid { get; set; } = null!;
        public string Accountid { get; set; } = null!;
        public double? Qty { get; set; }

        public virtual Externalaccount Account { get; set; } = null!;
        public virtual Good Goods { get; set; } = null!;
    }
}
