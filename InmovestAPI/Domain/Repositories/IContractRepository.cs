using System.Collections.Generic;
using System.Threading.Tasks;
using Inmovest.API.Domain.Models;

namespace Inmovest.API.Domain.Repositories
{
    public interface IContractRepository
    {
        Task<IEnumerable<Contract>> ListAsync();
        Task<IEnumerable<Contract>> FindByUserId(int userId);
    }
}