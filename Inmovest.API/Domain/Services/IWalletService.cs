using System.Collections.Generic;
using System.Threading.Tasks;
using Imnovest.API.Domain;

namespace Inmovest.API.Domain.Services
{
    public interface IWalletService
    {
        Task<IEnumerable<Wallet>> ListAsync();
    }
}