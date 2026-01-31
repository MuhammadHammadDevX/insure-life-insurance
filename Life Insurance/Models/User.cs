using System.ComponentModel.DataAnnotations;

namespace Life_Insurance.Models
{
	public class User
	{
		[Key]
		public int user_id { get; set; }

		public string user_firstname { get; set; }

		public string user_lastname { get; set; }

		public string user_email { get; set; }

		public string user_password { get; set; }

		public string user_cnic { get; set; }

		public string user_dateofbirth { get; set; }

		public string user_phone { get; set; }

		public string user_address { get; set; }

		public string user_image { get; set; }
	}
}
