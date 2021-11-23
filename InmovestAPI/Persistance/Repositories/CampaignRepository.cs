using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InmovestAPI.Domain.Models;
using InmovestAPI.Domain.Repositories;
using InmovestAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InmovestAPI.Persistance.Repositories
{
    public class CampaignRepository : BaseRepository, ICampaignRepository
    {
        public CampaignRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Campaign>> ListAsync()
        {
            return await _context.Campaigns
                .Include(p=>p.Project)
                .ToListAsync();
        }

        public async Task AddAsync(Campaign campaign)
        {
            await _context.Campaigns.AddAsync(campaign);
        }

        public async Task<Campaign> FindByIdAsync(int id)
        {
            return await _context.Campaigns
                .Include(p=>p.Project)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Campaign> FindByNameAsync(string name)
        {
            return await _context.Campaigns
                .Include(p=>p.Project)
                .FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<IEnumerable<Campaign>> FindByProjectId(int projectId)
        {
            return await _context.Campaigns
                .Where(p => p.ProjectId == projectId)
                .Include(p => p.Project)
                .ToListAsync();
        }

        public void Update(Campaign campaign)
        {
            _context.Campaigns.Update(campaign);
        }

        public void Remove(Campaign campaign)
        {
            _context.Campaigns.Remove(campaign);
        }
    }
}