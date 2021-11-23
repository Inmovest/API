using System.Collections.Generic;
using System.Threading.Tasks;
using Inmovest.API.Domain.Models;

namespace Inmovest.API.Domain.Services
{
    public interface IContractService
    {
        Task<IEnumerable<Contract>> ListAsync();
        Task<IEnumerable<Contract>> ListByUserIdAsync(int userId);
    }
}