using InmovestAPI.Domain.Models;
using InmovestAPI.Domain.Repositories;
using InmovestAPI.Domain.Services;
using InmovestAPI.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InmovestAPI.Persistance.Repositories;

namespace InmovestAPI.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IManagerRespository _managerRespository;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IProjectRepository projectRepository, IManagerRespository managerRespository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _managerRespository = managerRespository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProjectResponse> DeleteAsync(int id)
        {
            //Validate Product Id
            var existingProject = await _projectRepository.FindByIdAsync(id);

            if (existingProject == null)
                return new ProjectResponse("Project not found.");

            try
            {
                _projectRepository.Remove(existingProject);
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(existingProject);
            }
            catch (Exception e)
            {
                return new ProjectResponse($"An error occurred while deleting the project: {e.Message}");
            }
        }

        public async Task<IEnumerable<Project>> ListAsync()
        {
            return await _projectRepository.ListAsync();
        }

        public async Task<IEnumerable<Project>> ListByManagerIdAsync(int managerId)
        {
            return await _projectRepository.FindByManagerId(managerId);
        }

        public async Task<ProjectResponse> SaveAsync(Project project)
        {
            //Validate Relationships (por realizar)
            
            var existingManager = _managerRespository.FindByIdAsync(project.ManagerId);

            if (existingManager == null)
                return new ProjectResponse("Invalid Manager.");

            //Validate Name
            var existingProductWithName = await _projectRepository.FindByNameAsync(project.Name);

            if (existingProductWithName != null)
                return new ProjectResponse("Project name already exist.");

            try
            {
                await _projectRepository.AddAsync(project);
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(project);
            }
            catch (Exception e)
            {
                return new ProjectResponse($"An error occurred while saving the project: {e.Message}");
            }
        }

        public async Task<ProjectResponse> UpdateAsync(int id, Project project)
        {
            //Validate Project Id
            var existingProject = await _projectRepository.FindByIdAsync(id);

            if (existingProject == null)
                return new ProjectResponse("Project not found.");
            
            //Validate Relationships 
            
            var existingManager = _managerRespository.FindByIdAsync(project.ManagerId);

            if (existingManager == null)
                return new ProjectResponse("Invalid Manager.");

            //Validate Name
            var existingProjectWithName = await _projectRepository.FindByNameAsync(project.Name);

            if (existingProjectWithName != null && existingProjectWithName.Id != existingProject.Id)
                return new ProjectResponse("Project name already exist.");

            existingProject.Name = project.Name;
            existingProject.Description = project.Description;
            existingProject.PhotoUrl = project.PhotoUrl;

            try
            {
                _projectRepository.Update(existingProject);
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(existingProject);
            }
            catch (Exception e)
            {
                return new ProjectResponse($"An error occurred while updating the project: {e.Message}");
            }
        }
    }
}
