using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Imnovest.API.Domain;
using Inmovest.API.Domain.Repositories;
using Inmovest.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Inmovest.API.Persistence.Repositories
{
    public class WalletRepository : BaseRepository, IWalletRepository
    {
        public WalletRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Wallet>> ListAsync()
        {
            return await _context.Wallets.ToListAsync();
        }
    }
}