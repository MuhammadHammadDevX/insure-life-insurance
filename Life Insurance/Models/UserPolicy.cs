using System.ComponentModel.DataAnnotations;

namespace Life_Insurance.Models
{
	public class UserPolicy
	{
		[Key]
		public int userpolicy_id { get; set; }

		public string userpolicy_cnicnumber { get; set; }

        public string userpolicy_cnicissuancedate { get; set; }

        public string userpolicy_name { get; set; }

        public string userpolicy_dateofbirth { get; set; }

        public string userpolicy_fatherhusbandname { get; set; }

        public string userpolicy_gender { get; set; }

        public string userpolicy_mobilenumber { get; set; }

        public string userpolicy_city { get; set; }

        public string userpolicy_emailaddress { get; set; }

        public string userpolicy_sourceofincome { get; set; }

        public string userpolicy_organizationname { get; set; }

        public string userpolicy_organizationsector { get; set; }

        public string userpolicy_monthlynetincome { get; set; }

        public string userpolicy_residentialaddress { get; set; }

        public string userpolicy_insurancepolicyname { get; set; }

        public string userpolicy_termplan { get; set; }

        public string userpolicy_startdate { get; set; }

        public int policyID { get; set; }
    }
}
