using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Life_Insurance.Models
{
	public class InsurancePolicy
	{
		[Key]
		public int insurancepolicy_id {  get; set; }

		public string insurancepolicy_name { get; set; }

		public string insurancepolicy_description { get; set; }

		public string insurancepolicy_premiumamount { get; set; }

		public string insurancepolicy_covergeamount { get; set; }

        public string insurancepolicy_image { get; set; }

        public int policytype_id { get; set; }

		[ForeignKey("policytype_id")]
		public PolicyType PolicyType { get; set; }  // Foreign key relationship

		public int termplanyearly_id { get; set; }

		[ForeignKey("termplanyearly_id")]
		public TermPlanYearly TermPlanYearly { get; set; }  // Foreign key relationship

	}
}
