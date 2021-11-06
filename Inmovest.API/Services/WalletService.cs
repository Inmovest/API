using System.Collections.Generic;
using System.Threading.Tasks;
using Imnovest.API.Domain;
using Inmovest.API.Domain.Repositories;
using Inmovest.API.Domain.Services;

namespace Inmovest.API.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<IEnumerable<Wallet>> ListAsync()
        {
            return await _walletRepository.ListAsync();
        }
    }
}