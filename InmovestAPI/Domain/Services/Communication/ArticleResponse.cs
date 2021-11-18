using InmovestAPI.Domain.Models;

namespace InmovestAPI.Domain.Services.Communication
{
    public class ArticleResponse : BaseResponse<Article>
    {
        public ArticleResponse(string message) : base(message)
        {
        }

        public ArticleResponse(Article article) : base(article)
        {
        }
    }
}