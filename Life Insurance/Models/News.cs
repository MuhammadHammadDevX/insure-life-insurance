using System.ComponentModel.DataAnnotations;

namespace Life_Insurance.Models
{
	public class News
	{
		[Key]
		public int news_id {  get; set; }

		public string news_title { get; set; }

		public string news_description { get; set; }
	}
}
