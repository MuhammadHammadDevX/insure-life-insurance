using System.ComponentModel.DataAnnotations;

namespace Life_Insurance.Models
{
    public class Payment
    {
        [Key]
        public int payment_id {  get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public string NameOnCard { get; set; }

        public string CardNumber { get; set; } 

        public string ExpiryDate { get; set; } 

        public string CVV { get; set; }

        public string Amount { get; set; }

        public int TransactionID { get; set; }
    }
}
