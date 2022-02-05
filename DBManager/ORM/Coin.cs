using System;
using System.Collections.Generic;

namespace DBManager
{
    public partial class Coin
    {
        public Coin()
        {
            Goldcoins = new HashSet<Goldcoin>();
            Parsiancoins = new HashSet<Parsiancoin>();
        }

        public string Coinid { get; set; } = null!;
        public double? Tax { get; set; }

        public virtual Good CoinNavigation { get; set; } = null!;
        public virtual ICollection<Goldcoin> Goldcoins { get; set; }
        public virtual ICollection<Parsiancoin> Parsiancoins { get; set; }
    }
}
