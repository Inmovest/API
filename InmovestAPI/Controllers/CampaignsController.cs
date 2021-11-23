using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InmovestAPI.Domain.Models;
using InmovestAPI.Domain.Services;
using InmovestAPI.Extensions;
using InmovestAPI.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InmovestAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class CampaignsController : ControllerBase
    {
        private readonly ICampaignService _campaignService;
        private readonly IMapper _mapper;

        public CampaignsController(ICampaignService campaignService, IMapper mapper)
        {
            _campaignService = campaignService;
            _mapper = mapper;
        }
        
        [SwaggerOperation(
            Summary = "Get All Campaigns",
            Description = "Get All Campaigns already stored",
            Tags = new[] { "Campaigns" }
         )]
        [HttpGet]
        public async Task<IEnumerable<CampaignResource>> GetAllAsync()
        {
            var campaigns = await _campaignService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Campaign>, IEnumerable<CampaignResource>>(campaigns);

            return resources;
        }

        [SwaggerOperation(
            Summary = "Post a Campaign",
            Description = "Post a Campaign to the database",
            Tags = new[] { "Campaigns" }
         )]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCampaignResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var campaign = _mapper.Map<SaveCampaignResource, Campaign>(resource);

            var result = await _campaignService.SaveAsync(campaign);

            if (!result.Success)
                return BadRequest(result.Message);

            var campaignResource = _mapper.Map<Campaign, CampaignResource>(result.Resource);

            return Ok(campaignResource);
        }

        [SwaggerOperation(
            Summary = "Delete a Campaign",
            Description = "Delete a Campaign in the database",
            Tags = new[] { "Campaigns" }
         )]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _campaignService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var campaignResource = _mapper.Map<Campaign, CampaignResource>(result.Resource);

            return Ok(campaignResource);
        }

        [SwaggerOperation(
            Summary = "Update a Campaign",
            Description = "Update a Campaign in the database",
            Tags = new[] { "Campaigns" }
         )]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCampaignResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var campaign = _mapper.Map<SaveCampaignResource, Campaign>(resource);

            var result = await _campaignService.UpdateAsync(id, campaign);

            if (!result.Success)
                return BadRequest(result.Message);

            var campaignResource = _mapper.Map<Campaign, CampaignResource>(result.Resource);

            return Ok(campaignResource);
        }
    }
}