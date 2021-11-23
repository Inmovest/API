using InmovestAPI.Domain.Models;

namespace InmovestAPI.Domain.Services.Communication
{
    public class CampaignResponse : BaseResponse<Campaign>
    {
        public CampaignResponse(string message) : base(message)
        {
        }

        public CampaignResponse(Campaign resource) : base(resource)
        {
        }
    }
}