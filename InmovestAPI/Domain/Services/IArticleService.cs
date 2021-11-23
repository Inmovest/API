using System.Collections.Generic;
using System.Threading.Tasks;
using InmovestAPI.Domain.Models;
using InmovestAPI.Domain.Services.Communication;

namespace InmovestAPI.Domain.Services
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> ListAsync();
        Task<IEnumerable<Article>> ListByProjectIdAsync(int projectId);
        Task<ArticleResponse> SaveAsync(Article article);
        Task<ArticleResponse> UpdateAsync(int id, Article article);
        Task<ArticleResponse> DeleteAsync(int id);
    }
}