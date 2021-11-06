using System.Collections.Generic;
using System.Threading.Tasks;
using Inmovest.API.Domain;
using Inmovest.API.Domain.Repositories;
using Inmovest.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Inmovest.API.Persistence.Repositories
{
    public class BankAccountRepository: BaseRepository, IBankAccountRepository
    {
        public BankAccountRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<BankAccount>> ListAsync()
        {
            return await _context.BankAccounts.ToListAsync();
        }
    }
}