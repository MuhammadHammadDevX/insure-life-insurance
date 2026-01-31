using System.ComponentModel.DataAnnotations;

namespace Life_Insurance.Models
{
	public class PolicyType
	{
		[Key]
		public int policytype_id {  get; set; }

		public string policytype_name { get; set; }
	}
}
