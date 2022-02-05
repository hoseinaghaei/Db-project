using System;
using System.Collections.Generic;

namespace DBManager
{
    public partial class Customeraddress
    {
        public string Addressid { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Postalcode { get; set; } = null!;
        public double? Tag { get; set; }
        public string? Fulladdress { get; set; }

        public virtual Customer Address { get; set; } = null!;
    }
}
