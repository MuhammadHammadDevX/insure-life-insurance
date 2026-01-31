using System.ComponentModel.DataAnnotations;

namespace Life_Insurance.Models
{
	public class TermPlanYearlyMonthly
	{
		[Key]
		public int termplanyearlymonthly_id {  get; set; }

		public string termplanyearlymonthly_name { get; set; }
	}
}
