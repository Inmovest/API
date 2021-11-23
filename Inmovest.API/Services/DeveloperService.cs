using System.Collections.Generic;
using System.Threading.Tasks;
using Inmovest.API.Domain;
using Inmovest.API.Domain.Repositories;
using Inmovest.API.Domain.Services;

namespace Inmovest.API.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepository _developerRepository;
        
        public DeveloperService(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }
        
        public async Task<IEnumerable<Developer>> ListAsync()
        {
            return await _developerRepository.ListAsync();
        }
    }
}