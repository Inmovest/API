using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InmovestAPI.Domain.Models;
using InmovestAPI.Domain.Repositories;
using InmovestAPI.Domain.Services;
using InmovestAPI.Domain.Services.Communication;

namespace InmovestAPI.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CampaignService(ICampaignRepository campaignRepository, IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _campaignRepository = campaignRepository;
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Campaign>> ListAsync()
        {
            return await _campaignRepository.ListAsync();
        }

        public async Task<IEnumerable<Campaign>> ListByProjectIdAsync(int projectId)
        {
            return await _campaignRepository.FindByProjectId(projectId);
        }

        public async Task<CampaignResponse> SaveAsync(Campaign campaign)
        {
            //Validate Relationships (por realizar)
            
            var existingProject = _projectRepository.FindByIdAsync(campaign.ProjectId);

            if (existingProject == null)
                return new CampaignResponse("Invalid Project.");

            //Validate Name
            var existingCampaignWithName = await _campaignRepository.FindByNameAsync(campaign.Name);

            if (existingCampaignWithName != null)
                return new CampaignResponse("Campaign name already exist.");

            try
            {
                await _campaignRepository.AddAsync(campaign);
                await _unitOfWork.CompleteAsync();

                return new CampaignResponse(campaign);
            }
            catch (Exception e)
            {
                return new CampaignResponse($"An error occurred while saving the campaign: {e.Message}");
            }
        }

        public async Task<CampaignResponse> UpdateAsync(int id, Campaign campaign)
        {
            //Validate Project Id
            var existingCampaign = await _campaignRepository.FindByIdAsync(id);

            if (existingCampaign == null)
                return new CampaignResponse("Campaign not found.");
            
            //Validate Relationships 
            
            var existingProject = _projectRepository.FindByIdAsync(campaign.ProjectId);

            if (existingProject == null)
                return new CampaignResponse("Invalid Project.");

            //Validate Name
            var existingCampaignWithName = await _campaignRepository.FindByNameAsync(campaign.Name);

            if (existingCampaignWithName != null)
                return new CampaignResponse("Campaign name already exist.");

            existingCampaign.Name = campaign.Name;
            existingCampaign.MinAmount = campaign.MinAmount;
            existingCampaign.MaxAmount = campaign.MaxAmount;

            try
            {
                _campaignRepository.Update(existingCampaign);
                await _unitOfWork.CompleteAsync();

                return new CampaignResponse(existingCampaign);
            }
            catch (Exception e)
            {
                return new CampaignResponse($"An error occurred while updating the campaign: {e.Message}");
            }
        }

        public async Task<CampaignResponse> DeleteAsync(int id)
        {
            //Validate Product Id
            var existingCampaign = await _campaignRepository.FindByIdAsync(id);

            if (existingCampaign == null)
                return new CampaignResponse("Campaign not found.");

            try
            {
                _campaignRepository.Remove(existingCampaign);
                await _unitOfWork.CompleteAsync();

                return new CampaignResponse(existingCampaign);
            }
            catch (Exception e)
            {
                return new CampaignResponse($"An error occurred while deleting the campaign: {e.Message}");
            }
        }
    }
}