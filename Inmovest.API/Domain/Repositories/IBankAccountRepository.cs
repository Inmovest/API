using System.Collections.Generic;
using System.Threading.Tasks;
using Imnovest.API.Domain;

namespace Inmovest.API.Domain.Repositories
{
    public interface IBankAccountRepository
    {
        Task<IEnumerable<BankAccount>> ListAsync();
        Task<List<BankAccount>> FindByUserId(int userId);
    }
}