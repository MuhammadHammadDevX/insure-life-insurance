using System.ComponentModel.DataAnnotations;

namespace Life_Insurance.Models
{
    public class feedback
    {
        [Key]
        public int feedback_id { get; set; }

        public string feedback_name { get; set; }

        public string feedback_message { get; set; }
    }
}
