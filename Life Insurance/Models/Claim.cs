using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Life_Insurance.Models
{
	public class Claim
	{
		[Key]
		public int claim_id {  get; set; }

		public string claim_description { get; set; }

		public string claim_image {  get; set; }

        public string claim_username { get; set; }

        public string claim_userphone { get; set; }

        public string claim_userpolicynumber { get; set; }

        public string claim_useremail { get; set; }

        public int claim_requestid { get; set; }
    }
}
