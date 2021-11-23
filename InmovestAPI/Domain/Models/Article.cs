namespace InmovestAPI.Domain.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Body { get; set; }
        //Relationships
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}