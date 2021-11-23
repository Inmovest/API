using System.Collections.Generic;
using System.Threading.Tasks;
using InmovestAPI.Domain.Models;

namespace InmovestAPI.Domain.Repositories
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> ListAsync();
        Task AddAsync(Article article);
        Task<Article> FindByIdAsync(int id);
        Task<Article> FindByNameAsync(string name);
        Task<IEnumerable<Article>> FindByProjectId(int projectId);
        void Update(Article article);
        void Remove(Article article);
    }
}