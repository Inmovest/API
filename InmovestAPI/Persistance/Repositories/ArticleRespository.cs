using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InmovestAPI.Domain.Models;
using InmovestAPI.Domain.Repositories;
using InmovestAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InmovestAPI.Persistance.Repositories
{
    public class ArticleRepository : BaseRepository, IArticleRepository
    {
        public ArticleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Article>> ListAsync()
        {
            return await _context.Articles
                .Include(p=>p.Project)
                .ToListAsync();
        }

        public async Task AddAsync(Article article)
        {
            await _context.Articles.AddAsync(article);
        }

        public async Task<Article> FindByIdAsync(int id)
        {
            return await _context.Articles
                .Include(p=>p.Project)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Article> FindByNameAsync(string name)
        {
            return await _context.Articles
                .Include(p=>p.Project)
                .FirstOrDefaultAsync(p => p.Body == name);
        }

        public async Task<IEnumerable<Article>> FindByProjectId(int projectId)
        {
            return await _context.Articles
                .Where(p => p.ProjectId == projectId)
                .Include(p => p.Project)
                .ToListAsync();
        }

        public void Update(Article article)
        {
            _context.Articles.Update(article);
        }

        public void Remove(Article article)
        {
            _context.Articles.Remove(article);
        }
    }
}