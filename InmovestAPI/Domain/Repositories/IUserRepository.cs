using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inmovest.API.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
    }
}