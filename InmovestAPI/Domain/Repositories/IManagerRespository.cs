using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using InmovestAPI.Domain.Models;

namespace InmovestAPI.Domain.Repositories
{
    public interface IManagerRespository
    {
        Task<IEnumerable<Manager>> ListAsync();

        Task AddAsync(Manager manager);

        Task<Manager> FindByIdAsync(int id);
        void Update(Manager manager);
        void Remove(Manager manager);
    }
}