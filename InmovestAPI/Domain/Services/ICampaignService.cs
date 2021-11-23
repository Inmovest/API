using System.Collections.Generic;
using System.Threading.Tasks;
using InmovestAPI.Domain.Models;
using InmovestAPI.Domain.Services.Communication;

namespace InmovestAPI.Domain.Services
{
    public interface ICampaignService
    {
        Task<IEnumerable<Campaign>> ListAsync();
        Task<IEnumerable<Campaign>> ListByProjectIdAsync(int projectId);
        Task<CampaignResponse> SaveAsync(Campaign campaign);
        Task<CampaignResponse> UpdateAsync(int id, Campaign campaign);
        Task<CampaignResponse> DeleteAsync(int id);
    }
}