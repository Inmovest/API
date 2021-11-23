using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InmovestAPI.Domain.Models;
using InmovestAPI.Domain.Services;
using InmovestAPI.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InmovestAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/projects/{projectId}/campaigns")]
    public class ProjectCampaignsController : ControllerBase
    {
        private readonly ICampaignService _campaignService;
        private readonly IMapper _mapper;

        public ProjectCampaignsController(ICampaignService campaignService, IMapper mapper)
        {
            _campaignService = campaignService;
            _mapper = mapper;
        }
        
        [SwaggerOperation(
            Summary = "Get All Campaigns By Projects",
            Description = "Get All Campaigns for a given ProjectId",
            Tags = new[] {"Campaigns"}
        )]
        [HttpGet]
        public async Task<IEnumerable<CampaignResource>> GetAllByManagerIdAsync(int projectId)
        {
            var campaigns = await _campaignService.ListByProjectIdAsync(projectId);
            var resources = _mapper.Map<IEnumerable<Campaign>, IEnumerable<CampaignResource>>(campaigns);

            return resources;
        }
    }
}