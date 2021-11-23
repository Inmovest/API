using System.Collections.Generic;
using System.Threading.Tasks;
using Inmovest.API.Domain;
using Inmovest.API.Domain.Repositories;
using Inmovest.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Imnovest.API.Domain;

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

        public async Task<List<BankAccount>> FindByUserId(int userId)
        {
            return await _context.BankAccounts
                .Where(p=>p.UserId == userId)
                .Include(p=>p.User)
                .ToListAsync();
        }
    }
}