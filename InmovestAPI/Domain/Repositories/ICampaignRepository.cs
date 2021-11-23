using System.Collections.Generic;
using System.Threading.Tasks;
using InmovestAPI.Domain.Models;

namespace InmovestAPI.Domain.Repositories
{
    public interface ICampaignRepository
    {
        Task<IEnumerable<Campaign>> ListAsync();
        Task AddAsync(Campaign campaign);
        Task<Campaign> FindByIdAsync(int id);
        Task<Campaign> FindByNameAsync(string name);
        Task<IEnumerable<Campaign>> FindByProjectId(int projectId);
        void Update(Campaign campaign);
        void Remove(Campaign campaign);
    }
}