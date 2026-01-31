using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Life_Insurance.Models
{
	public class Loan
	{
		[Key]
		public int loan_id { get; set; }

        public string loan_username { get; set; }

        public string loan_usercnicnumber { get; set; }

        public string loan_userdateofbirth { get; set; }

        public string loan_userphonenumber { get; set; }

        public string loan_useremail { get; set; }

        public string loan_usercity { get; set; }

        public string loan_usersector { get; set; }

        public string loan_userorganizationname { get; set; }

        public string loan_usermontlynetincome { get; set; }

        public string loan_userloanamount { get; set; }

        public string loan_desiredloanrepaymentperiod { get; set; }

        public string loan_requestid { get; set; }
    }
}
