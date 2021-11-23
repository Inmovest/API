using System.ComponentModel.DataAnnotations;

namespace InmovestAPI.Resources
{
    public class SaveCampaignResource
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public float MinAmount { get; set; }
        [Required]
        public float MaxAmount { get; set; }
        
        //Relationship
        [Required]
        public int ProjectId { get; set; }
    }
}