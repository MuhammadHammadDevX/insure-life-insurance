using System.ComponentModel.DataAnnotations;

namespace Life_Insurance.Models
{
    public class Preminuim
    {
        [Key]
        public int pre_id { get; set; }
        public string prolicy_type { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public string sum_assured { get; set; }
        public string premium_pay_mode { get; set; }
        public decimal calculated_premium { get; set; }


    }
}
