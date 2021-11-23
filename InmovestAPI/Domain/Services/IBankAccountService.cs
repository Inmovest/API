using System.Collections.Generic;
using System.Threading.Tasks;
using Imnovest.API.Domain;

namespace Inmovest.API.Domain.Services
{
    public interface IBankAccountService
    {
        Task<IEnumerable<BankAccount>> ListAsync();
        Task<IEnumerable<BankAccount>> ListByUserIdAsync(int bankAccountId);
    }
}