using System.ComponentModel.DataAnnotations;

namespace InmovestAPI.Resources
{
    public class SaveArticleResource
    {
        [Required]
        public string Body { get; set; }
        [Required]
        public int ProjectId { get; set; }
    }
}