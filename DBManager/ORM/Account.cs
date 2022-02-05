using System;
using System.Collections.Generic;

namespace DBManager
{
    public partial class Account
    {
        public Account()
        {
            Enternalaccounts = new HashSet<Enternalaccount>();
        }

        public string Accountid { get; set; } = null!;
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }

        public virtual Customer AccountNavigation { get; set; } = null!;
        public virtual Externalaccount Externalaccount { get; set; } = null!;
        public virtual ICollection<Enternalaccount> Enternalaccounts { get; set; }
    }
}
