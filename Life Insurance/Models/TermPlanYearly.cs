using System.ComponentModel.DataAnnotations;

namespace Life_Insurance.Models
{
	public class TermPlanYearly
	{
		[Key]
		public int termplanyearly_id {  get; set; }

		public string termplanyearly_name { get; set; }
	}
}
