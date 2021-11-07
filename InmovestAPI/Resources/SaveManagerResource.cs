using System.ComponentModel.DataAnnotations;

namespace InmovestAPI.Resources
{
    public class SaveManagerResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}