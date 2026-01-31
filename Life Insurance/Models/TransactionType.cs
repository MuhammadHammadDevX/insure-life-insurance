using System.ComponentModel.DataAnnotations;

namespace Life_Insurance.Models
{
	public class TransactionType
	{
		[Key]
		public int transactiontype_id { get; set; }

		public string transactiontype_name { get; set; }
	}
}
