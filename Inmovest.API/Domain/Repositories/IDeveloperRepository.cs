using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inmovest.API.Domain.Repositories
{
    public interface IDeveloperRepository
    {
        Task<IEnumerable<Developer>> ListAsync();
    }
}