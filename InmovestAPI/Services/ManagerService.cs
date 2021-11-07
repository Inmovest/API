using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InmovestAPI.Domain.Models;
using InmovestAPI.Domain.Repositories;
using InmovestAPI.Domain.Services;
using InmovestAPI.Domain.Services.Communication;

namespace InmovestAPI.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRespository _managerRespository;
        private readonly IUnitOfWork _unitOfWork;

        public ManagerService(IManagerRespository managerRespository, IUnitOfWork unitOfWork)
        {
            _managerRespository = managerRespository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Manager>> ListAsync()
        {
            return await _managerRespository.ListAsync();
        }

        public async Task<ManagerResponse> SaveAsync(Manager manager)
        {
            try
            {
                await _managerRespository.AddAsync(manager);
                await _unitOfWork.CompleteAsync();

                return new ManagerResponse(manager);
            }
            catch (Exception e)
            {
                return new ManagerResponse($"An error occurred while saving Category: {e.Message}");
            }
        }

        public async Task<ManagerResponse> UpdateAsync(int id, Manager manager)
        {
            var existingManager = await _managerRespository.FindByIdAsync(id);

            if (existingManager == null)
                return new ManagerResponse("Manager not found.");

            existingManager.Name = manager.Name;

            try
            {
                _managerRespository.Update(existingManager);
                await _unitOfWork.CompleteAsync();

                return new ManagerResponse(existingManager);
            }
            catch (Exception e)
            {
                return new ManagerResponse($"An error occurred while updating the manager: {e.Message}");
            }
        }

        public async Task<ManagerResponse> DeleteAsync(int id)
        {
            var existingManager = await _managerRespository.FindByIdAsync(id);

            if (existingManager == null)
                return new ManagerResponse("Manager not found.");

            try
            {
                _managerRespository.Remove(existingManager);
                await _unitOfWork.CompleteAsync();

                return new ManagerResponse(existingManager);
            }
            catch (Exception e)
            {
                return new ManagerResponse($"An error occurred while deleting the manager: {e.Message}");
            }
        }
    }
}