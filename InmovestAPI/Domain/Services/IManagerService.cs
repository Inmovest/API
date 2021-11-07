using System.Collections.Generic;
using System.Threading.Tasks;
using InmovestAPI.Domain.Models;
using InmovestAPI.Domain.Services.Communication;

namespace InmovestAPI.Domain.Services
{
    public interface IManagerService
    {
        Task<IEnumerable<Manager>> ListAsync();

        Task<ManagerResponse> SaveAsync(Manager manager);

        Task<ManagerResponse> UpdateAsync(int id, Manager manager);

        Task<ManagerResponse> DeleteAsync(int id);
    }
}