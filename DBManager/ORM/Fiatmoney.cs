using System;
using System.Collections.Generic;

namespace DBManager
{
    public partial class Fiatmoney
    {
        public string Fiatmoneyid { get; set; } = null!;
        public string? Govermant { get; set; }

        public virtual Good FiatmoneyNavigation { get; set; } = null!;
    }
}
