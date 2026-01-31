using Microsoft.EntityFrameworkCore;

namespace Life_Insurance.Models
{
	public class Mycontext : DbContext
	{
		public Mycontext(DbContextOptions<Mycontext> options) : base(options)
		{

		}

		public DbSet<Admin> tbl_admin {  get; set; }

		public DbSet<User> tbl_users { get; set; }

		public DbSet<PolicyType> tbl_policytype { get; set; }

		public DbSet<TermPlanYearly> tbl_termplanyearly { get; set; }

		public DbSet<TermPlanYearlyMonthly> tbl_termplanyearlymonthly { get; set; }

		public DbSet<TransactionType> tbl_transactiontype { get; set; }

		public DbSet<InsurancePolicy> tbl_insurancepolicy { get; set; }

		public DbSet<UserPolicy> tbl_userpolicy { get; set; }

		public DbSet<PremiumCalculation> tbl_premiumcalculation { get; set; }

		public DbSet<Loan> tbl_loan { get; set; }

		public DbSet<PaymentTransaction> tbl_paymenttransaction { get; set; }

		public DbSet<News> tbl_news { get; set; }

		public DbSet<Claim> tbl_claim { get; set; }

		public DbSet<Contact> tbl_contact { get; set; }

		public DbSet<faqs> tbl_faqs { get; set; }

        public DbSet<feedback> tbl_feedback { get; set; }
		public DbSet<Preminuim> tbl_pre { get; set; }

        public DbSet<EMI> tbl_emi { get; set; }

        public DbSet<Payment> tbl_payment { get; set; }


    }
}
