namespace InmovestAPI.Resources
{
    public class ArticleResource
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public ProjectResource Project { get; set; }
    }
}