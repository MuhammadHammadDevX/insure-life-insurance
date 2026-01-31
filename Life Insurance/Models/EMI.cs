using System.ComponentModel.DataAnnotations;

namespace Life_Insurance.Models
{
    public class EMI
    {
        [Key]
        public int emi_id { get; set; }
        public decimal principal { get; set; } 
        public decimal rate_of_interest { get; set; } 
        public int tenure { get; set; } 
        public decimal calculated_emi { get; set; } 
    }
}
