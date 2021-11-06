using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inmovest.API.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
    }
}