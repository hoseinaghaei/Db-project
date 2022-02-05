using System;
using System.Collections.Generic;

namespace DBManager
{
    public partial class Realcustomer
    {
        public string Rcustomerid { get; set; } = null!;
        public string? Mellicode { get; set; }
        public int? Age { get; set; }

        public virtual Customer Rcustomer { get; set; } = null!;
    }
}
