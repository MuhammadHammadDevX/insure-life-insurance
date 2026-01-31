using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Life_Insurance.Models
{
	public class PremiumCalculation
	{

		[Key]
		public int premiumcalculation_id {  get; set; }

		public string premiumcalculation_calculatedpremium { get; set; }

		public string premiumcalculation_calculationdate { get; set; }

		public int user_id { get; set; }

		[ForeignKey("user_id")]
		public User User { get; set; }  // Foreign key relationship

		public int insurancepolicy_id { get; set; }

		[ForeignKey("insurancepolicy_id")]
		public InsurancePolicy InsurancePolicy { get; set; }  // Foreign key relationship

		public int termplanyearlymonthly_id { get; set; }

		[ForeignKey("termplanyearlymonthly_id")]
		public TermPlanYearlyMonthly TermPlanYearlyMonthly { get; set; }  // Foreign key relationship

	}
}
