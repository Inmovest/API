using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inmovest.API.Domain.Services
{
    public interface IBankAccountService
    {
        Task<IEnumerable<BankAccount>> ListAsync();
    }
}