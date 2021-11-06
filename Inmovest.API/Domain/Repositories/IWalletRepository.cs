using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Imnovest.API.Domain;

namespace Inmovest.API.Domain.Repositories
{
    public interface IWalletRepository
    {
        Task<IEnumerable<Wallet>> ListAsync();
    }
}