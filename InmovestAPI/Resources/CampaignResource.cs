using InmovestAPI.Domain.Models;

namespace InmovestAPI.Resources
{
    public class CampaignResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float MinAmount { get; set; }
        public float MaxAmount { get; set; }
        
        //Relationship
        public ProjectResource Project { get; set; }
    }
}