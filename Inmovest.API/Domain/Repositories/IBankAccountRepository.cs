using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inmovest.API.Domain.Repositories
{
    public interface IBankAccountRepository
    {
        Task<IEnumerable<BankAccount>> ListAsync();
    }
}