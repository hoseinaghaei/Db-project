using System;
using System.Collections.Generic;
using DBManager.Model;

namespace DBManager
{
    public partial class Customer
    {
        public string CustomerId { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Email { get; set; }
        public byte[]? Image { get; set; }
        public string? FirstPhone { get; set; }
        public string? SecondPhone { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Customeraddress CustomerAddress { get; set; } = null!;
        public virtual Legalcustomer LegalCustomer { get; set; } = null!;
        public virtual Realcustomer RealCustomer { get; set; } = null!;
    }
}
