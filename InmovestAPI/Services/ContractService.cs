using System.Collections.Generic;
using System.Threading.Tasks;
using Inmovest.API.Domain.Models;
using Inmovest.API.Domain.Repositories;
using Inmovest.API.Domain.Services;

namespace Inmovest.API.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        
        public ContractService(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }
        public async Task<IEnumerable<Contract>> ListAsync()
        {
            return await _contractRepository.ListAsync();
        }

        public async Task<IEnumerable<Contract>> ListByUserIdAsync(int userId)
        {
            return await _contractRepository.FindByUserId(userId);
        }
    }
}