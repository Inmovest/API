namespace InmovestAPI.Domain.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float MinAmount { get; set; }
        public float MaxAmount { get; set; }
        
        //Relationship
        
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}