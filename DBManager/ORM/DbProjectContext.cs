using Microsoft.EntityFrameworkCore;

namespace DBManager.ORM
{
    public partial class DbProjectContext : DbContext
    {
        public DbProjectContext()
        {
        }

        public DbProjectContext(DbContextOptions<DbProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Buy> Buys { get; set; } = null!;
        public virtual DbSet<BuyDaily> BuyDailies { get; set; } = null!;
        public virtual DbSet<Coin> Coins { get; set; } = null!;
        public virtual DbSet<Cryptocurrency> Cryptocurrencies { get; set; } = null!;
        public virtual DbSet<Customer?> Customers { get; set; } = null!;
        public virtual DbSet<Customeraddress> Customeraddresses { get; set; } = null!;
        public virtual DbSet<Enternalaccount> Enternalaccounts { get; set; } = null!;
        public virtual DbSet<Existence> Existences { get; set; } = null!;
        public virtual DbSet<Externalaccount> Externalaccounts { get; set; } = null!;
        public virtual DbSet<Fiatmoney> Fiatmoneys { get; set; } = null!;
        public virtual DbSet<Goldcoin> Goldcoins { get; set; } = null!;
        public virtual DbSet<Good> Goods { get; set; } = null!;
        public virtual DbSet<Goodsprice> Goodsprices { get; set; } = null!;
        public virtual DbSet<Legalcustomer> Legalcustomers { get; set; } = null!;
        public virtual DbSet<Parsiancoin> Parsiancoins { get; set; } = null!;
        public virtual DbSet<Realcustomer> Realcustomers { get; set; } = null!;
        public virtual DbSet<Sell> Sells { get; set; } = null!;
        public virtual DbSet<TodayPrice> TodayPrices { get; set; } = null!;
        public virtual DbSet<TopBuyer> TopBuyers { get; set; } = null!;
        public virtual DbSet<Transfer> Transfers { get; set; } = null!;
        public virtual DbSet<WageDaily> WageDailies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost:5433;Database=db-project;Username=postgres;Password=db-project");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.Property(e => e.Accountid)
                    .HasMaxLength(8)
                    .HasColumnName("accountid")
                    .IsFixedLength();

                entity.Property(e => e.Day).HasColumnName("day");

                entity.Property(e => e.Month).HasColumnName("month");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.AccountNavigation)
                    .WithOne(p => p.Account)
                    .HasForeignKey<Account>(d => d.Accountid)
                    .HasConstraintName("account_accountid_fkey");
            });

            modelBuilder.Entity<Buy>(entity =>
            {
                entity.HasKey(e => new { e.Goodsid, e.Accountid, e.Transactioncode })
                    .HasName("buy_pkey");

                entity.ToTable("buy");

                entity.Property(e => e.Goodsid)
                    .HasMaxLength(8)
                    .HasColumnName("goodsid")
                    .IsFixedLength();

                entity.Property(e => e.Accountid)
                    .HasMaxLength(8)
                    .HasColumnName("accountid")
                    .IsFixedLength();

                entity.Property(e => e.Transactioncode)
                    .HasMaxLength(10)
                    .HasColumnName("transactioncode")
                    .IsFixedLength();

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Digitalorphysical)
                    .HasMaxLength(8)
                    .HasColumnName("digitalorphysical");

                entity.Property(e => e.Payment).HasColumnName("payment");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.Successful).HasColumnName("successful");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Buys)
                    .HasForeignKey(d => d.Accountid)
                    .HasConstraintName("buy_accountid_fkey");

                entity.HasOne(d => d.Goods)
                    .WithMany(p => p.Buys)
                    .HasForeignKey(d => d.Goodsid)
                    .HasConstraintName("buy_goodsid_fkey");
            });

            modelBuilder.Entity<BuyDaily>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("buy_daily");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Sum).HasColumnName("sum");
            });

            modelBuilder.Entity<Coin>(entity =>
            {
                entity.ToTable("coin");

                entity.Property(e => e.Coinid)
                    .HasMaxLength(8)
                    .HasColumnName("coinid")
                    .IsFixedLength();

                entity.Property(e => e.Tax).HasColumnName("tax");

                entity.HasOne(d => d.CoinNavigation)
                    .WithOne(p => p.Coin)
                    .HasForeignKey<Coin>(d => d.Coinid)
                    .HasConstraintName("coin_coinid_fkey");
            });

            modelBuilder.Entity<Cryptocurrency>(entity =>
            {
                entity.ToTable("cryptocurrency");

                entity.Property(e => e.Cryptocurrencyid)
                    .HasMaxLength(8)
                    .HasColumnName("cryptocurrencyid")
                    .IsFixedLength();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.HasOne(d => d.CryptocurrencyNavigation)
                    .WithOne(p => p.Cryptocurrency)
                    .HasForeignKey<Cryptocurrency>(d => d.Cryptocurrencyid)
                    .HasConstraintName("cryptocurrency_cryptocurrencyid_fkey");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.Username, "customer_username_key")
                    .IsUnique();

                entity.Property(e => e.Customerid)
                    .HasMaxLength(8)
                    .HasColumnName("customerid")
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .HasColumnName("email");

                entity.Property(e => e.FirstPhone)
                    .HasMaxLength(11)
                    .HasColumnName("first_phone")
                    .IsFixedLength();

                entity.Property(e => e.Firstname)
                    .HasMaxLength(20)
                    .HasColumnName("firstname");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(30)
                    .HasColumnName("lastname");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .HasColumnName("password");

                entity.Property(e => e.SecondPhone)
                    .HasMaxLength(11)
                    .HasColumnName("second_phone")
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Customeraddress>(entity =>
            {
                entity.HasKey(e => e.Addressid)
                    .HasName("customeraddress_pkey");

                entity.ToTable("customeraddress");

                entity.Property(e => e.Addressid)
                    .HasMaxLength(8)
                    .HasColumnName("addressid")
                    .IsFixedLength();

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .HasColumnName("city");

                entity.Property(e => e.Fulladdress)
                    .HasMaxLength(100)
                    .HasColumnName("fulladdress");

                entity.Property(e => e.Postalcode)
                    .HasMaxLength(20)
                    .HasColumnName("postalcode");

                entity.Property(e => e.Province)
                    .HasMaxLength(20)
                    .HasColumnName("province");

                entity.Property(e => e.Tag).HasColumnName("tag");

                entity.HasOne(d => d.Address)
                    .WithOne(p => p.Customeraddress)
                    .HasForeignKey<Customeraddress>(d => d.Addressid)
                    .HasConstraintName("customeraddress_addressid_fkey");
            });

            modelBuilder.Entity<Enternalaccount>(entity =>
            {
                entity.HasKey(e => new { e.Enaccountid, e.Sheba })
                    .HasName("enternalaccount_pkey");

                entity.ToTable("enternalaccount");

                entity.Property(e => e.Enaccountid)
                    .HasMaxLength(8)
                    .HasColumnName("enaccountid")
                    .IsFixedLength();

                entity.Property(e => e.Sheba)
                    .HasMaxLength(24)
                    .HasColumnName("sheba")
                    .IsFixedLength();

                entity.Property(e => e.Approval)
                    .HasColumnName("approval")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Bank)
                    .HasMaxLength(20)
                    .HasColumnName("bank");

                entity.Property(e => e.Transactionpermission)
                    .HasColumnName("transactionpermission")
                    .HasDefaultValueSql("true");

                entity.HasOne(d => d.Enaccount)
                    .WithMany(p => p.Enternalaccounts)
                    .HasForeignKey(d => d.Enaccountid)
                    .HasConstraintName("enternalaccount_enaccountid_fkey");
            });

            modelBuilder.Entity<Existence>(entity =>
            {
                entity.HasKey(e => new { e.Goodsid, e.Accountid })
                    .HasName("existence_pkey");

                entity.ToTable("existence");

                entity.Property(e => e.Goodsid)
                    .HasMaxLength(8)
                    .HasColumnName("goodsid")
                    .IsFixedLength();

                entity.Property(e => e.Accountid)
                    .HasMaxLength(8)
                    .HasColumnName("accountid")
                    .IsFixedLength();

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Existences)
                    .HasForeignKey(d => d.Accountid)
                    .HasConstraintName("existence_accountid_fkey");

                entity.HasOne(d => d.Goods)
                    .WithMany(p => p.Existences)
                    .HasForeignKey(d => d.Goodsid)
                    .HasConstraintName("existence_goodsid_fkey");
            });

            modelBuilder.Entity<Externalaccount>(entity =>
            {
                entity.HasKey(e => e.Exaccountid)
                    .HasName("externalaccount_pkey");

                entity.ToTable("externalaccount");

                entity.Property(e => e.Exaccountid)
                    .HasMaxLength(8)
                    .HasColumnName("exaccountid")
                    .IsFixedLength();

                entity.Property(e => e.Fulladdress)
                    .HasMaxLength(100)
                    .HasColumnName("fulladdress");

                entity.HasOne(d => d.Exaccount)
                    .WithOne(p => p.Externalaccount)
                    .HasForeignKey<Externalaccount>(d => d.Exaccountid)
                    .HasConstraintName("externalaccount_exaccountid_fkey");
            });

            modelBuilder.Entity<Fiatmoney>(entity =>
            {
                entity.ToTable("fiatmoney");

                entity.Property(e => e.Fiatmoneyid)
                    .HasMaxLength(8)
                    .HasColumnName("fiatmoneyid")
                    .IsFixedLength();

                entity.Property(e => e.Govermant)
                    .HasMaxLength(30)
                    .HasColumnName("govermant");

                entity.HasOne(d => d.FiatmoneyNavigation)
                    .WithOne(p => p.Fiatmoney)
                    .HasForeignKey<Fiatmoney>(d => d.Fiatmoneyid)
                    .HasConstraintName("fiatmoney_fiatmoneyid_fkey");
            });

            modelBuilder.Entity<Goldcoin>(entity =>
            {
                entity.HasKey(e => new { e.Goldcoinid, e.Type, e.Carat })
                    .HasName("goldcoin_pkey");

                entity.ToTable("goldcoin");

                entity.Property(e => e.Goldcoinid)
                    .HasMaxLength(8)
                    .HasColumnName("goldcoinid")
                    .IsFixedLength();

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("type");

                entity.Property(e => e.Carat).HasColumnName("carat");

                entity.HasOne(d => d.GoldcoinNavigation)
                    .WithMany(p => p.Goldcoins)
                    .HasForeignKey(d => d.Goldcoinid)
                    .HasConstraintName("goldcoin_goldcoinid_fkey");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.HasKey(e => e.Goodsid)
                    .HasName("goods_pkey");

                entity.ToTable("goods");

                entity.Property(e => e.Goodsid)
                    .HasMaxLength(8)
                    .HasColumnName("goodsid")
                    .IsFixedLength();

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Wage).HasColumnName("wage");
            });

            modelBuilder.Entity<Goodsprice>(entity =>
            {
                entity.HasKey(e => new { e.Priceid, e.Year, e.Month, e.Day })
                    .HasName("goodsprice_pkey");

                entity.ToTable("goodsprice");

                entity.Property(e => e.Priceid)
                    .HasMaxLength(8)
                    .HasColumnName("priceid")
                    .IsFixedLength();

                entity.Property(e => e.Year).HasColumnName("year");

                entity.Property(e => e.Month).HasColumnName("month");

                entity.Property(e => e.Day).HasColumnName("day");

                entity.Property(e => e.DifferenceRateThanYesterday).HasColumnName("difference_rate_than_yesterday");

                entity.Property(e => e.LastChanged).HasColumnName("last_changed");

                entity.Property(e => e.RealTimePriceDollar).HasColumnName("real_time_price_dollar");

                entity.Property(e => e.RealTimePriceRial).HasColumnName("real_time_price_rial");

                entity.Property(e => e.TheLeastPrice).HasColumnName("the_least_price");

                entity.Property(e => e.TheMostPrice).HasColumnName("the_most_price");

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.Goodsprices)
                    .HasForeignKey(d => d.Priceid)
                    .HasConstraintName("goodsprice_priceid_fkey");
            });

            modelBuilder.Entity<Legalcustomer>(entity =>
            {
                entity.HasKey(e => e.Lcustomerid)
                    .HasName("legalcustomer_pkey");

                entity.ToTable("legalcustomer");

                entity.Property(e => e.Lcustomerid)
                    .HasMaxLength(8)
                    .HasColumnName("lcustomerid")
                    .IsFixedLength();

                entity.Property(e => e.Fax)
                    .HasMaxLength(20)
                    .HasColumnName("fax");

                entity.Property(e => e.Manager)
                    .HasMaxLength(30)
                    .HasColumnName("manager");

                entity.Property(e => e.Registerycode)
                    .HasMaxLength(30)
                    .HasColumnName("registerycode");

                entity.HasOne(d => d.Lcustomer)
                    .WithOne(p => p.Legalcustomer)
                    .HasForeignKey<Legalcustomer>(d => d.Lcustomerid)
                    .HasConstraintName("legalcustomer_lcustomerid_fkey");
            });

            modelBuilder.Entity<Parsiancoin>(entity =>
            {
                entity.HasKey(e => new { e.Parsiancoinid, e.Weight })
                    .HasName("parsiancoin_pkey");

                entity.ToTable("parsiancoin");

                entity.Property(e => e.Parsiancoinid)
                    .HasMaxLength(8)
                    .HasColumnName("parsiancoinid")
                    .IsFixedLength();

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.HasOne(d => d.ParsiancoinNavigation)
                    .WithMany(p => p.Parsiancoins)
                    .HasForeignKey(d => d.Parsiancoinid)
                    .HasConstraintName("parsiancoin_parsiancoinid_fkey");
            });

            modelBuilder.Entity<Realcustomer>(entity =>
            {
                entity.HasKey(e => e.Rcustomerid)
                    .HasName("realcustomer_pkey");

                entity.ToTable("realcustomer");

                entity.Property(e => e.Rcustomerid)
                    .HasMaxLength(8)
                    .HasColumnName("rcustomerid")
                    .IsFixedLength();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Mellicode)
                    .HasMaxLength(10)
                    .HasColumnName("mellicode");

                entity.HasOne(d => d.Rcustomer)
                    .WithOne(p => p.Realcustomer)
                    .HasForeignKey<Realcustomer>(d => d.Rcustomerid)
                    .HasConstraintName("realcustomer_rcustomerid_fkey");
            });

            modelBuilder.Entity<Sell>(entity =>
            {
                entity.HasKey(e => new { e.Goodsid, e.Accountid, e.Transactioncode })
                    .HasName("sell_pkey");

                entity.ToTable("sell");

                entity.Property(e => e.Goodsid)
                    .HasMaxLength(8)
                    .HasColumnName("goodsid")
                    .IsFixedLength();

                entity.Property(e => e.Accountid)
                    .HasMaxLength(8)
                    .HasColumnName("accountid")
                    .IsFixedLength();

                entity.Property(e => e.Transactioncode)
                    .HasMaxLength(10)
                    .HasColumnName("transactioncode")
                    .IsFixedLength();

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Digitalorphysical)
                    .HasMaxLength(8)
                    .HasColumnName("digitalorphysical");

                entity.Property(e => e.Payment).HasColumnName("payment");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.Successful).HasColumnName("successful");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Sells)
                    .HasForeignKey(d => d.Accountid)
                    .HasConstraintName("sell_accountid_fkey");

                entity.HasOne(d => d.Goods)
                    .WithMany(p => p.Sells)
                    .HasForeignKey(d => d.Goodsid)
                    .HasConstraintName("sell_goodsid_fkey");
            });

            modelBuilder.Entity<TodayPrice>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("today_prices");

                entity.Property(e => e.Goodsid)
                    .HasMaxLength(8)
                    .HasColumnName("goodsid")
                    .IsFixedLength();

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.RealTimePriceRial).HasColumnName("real_time_price_rial");
            });

            modelBuilder.Entity<TopBuyer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("top_buyer");

                entity.Property(e => e.Customerid)
                    .HasMaxLength(8)
                    .HasColumnName("customerid")
                    .IsFixedLength();

                entity.Property(e => e.Pay).HasColumnName("pay");
            });

            modelBuilder.Entity<Transfer>(entity =>
            {
                entity.HasKey(e => new { e.Goodsid, e.Selleraccountid, e.Buyeraccountid, e.Transactioncode })
                    .HasName("transfer_pkey");

                entity.ToTable("transfer");

                entity.Property(e => e.Goodsid)
                    .HasMaxLength(8)
                    .HasColumnName("goodsid")
                    .IsFixedLength();

                entity.Property(e => e.Selleraccountid)
                    .HasMaxLength(8)
                    .HasColumnName("selleraccountid")
                    .IsFixedLength();

                entity.Property(e => e.Buyeraccountid)
                    .HasMaxLength(8)
                    .HasColumnName("buyeraccountid")
                    .IsFixedLength();

                entity.Property(e => e.Transactioncode)
                    .HasMaxLength(10)
                    .HasColumnName("transactioncode")
                    .IsFixedLength();

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Digitalorphysical)
                    .HasMaxLength(8)
                    .HasColumnName("digitalorphysical");

                entity.Property(e => e.Payment).HasColumnName("payment");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Successful).HasColumnName("successful");

                entity.Property(e => e.Wageamount).HasColumnName("wageamount");

                entity.HasOne(d => d.Buyeraccount)
                    .WithMany(p => p.TransferBuyeraccounts)
                    .HasForeignKey(d => d.Buyeraccountid)
                    .HasConstraintName("transfer_buyeraccountid_fkey");

                entity.HasOne(d => d.Goods)
                    .WithMany(p => p.Transfers)
                    .HasForeignKey(d => d.Goodsid)
                    .HasConstraintName("transfer_goodsid_fkey");

                entity.HasOne(d => d.Selleraccount)
                    .WithMany(p => p.TransferSelleraccounts)
                    .HasForeignKey(d => d.Selleraccountid)
                    .HasConstraintName("transfer_selleraccountid_fkey");
            });

            modelBuilder.Entity<WageDaily>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("wage_daily");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Sum).HasColumnName("sum");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
