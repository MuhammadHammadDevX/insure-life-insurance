using System.ComponentModel.DataAnnotations;

namespace Life_Insurance.Models
{
    public class faqs
    {
        [Key]
        public int faqs_id { get; set; }

        public string faqs_question { get; set; }

        public string faqs_answer { get; set; }
    }
}
