using System.Collections.Generic;
using System.Threading.Tasks;
using Inmovest.API.Domain.Models;
using Inmovest.API.Domain.Repositories;
using Inmovest.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inmovest.API.Persistence.Repositories
{
    public class ContractRepository: BaseRepository, IContractRepository
    {
        public ContractRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Contract>> ListAsync()
        {
            return await _context.Contracts.ToListAsync();
        }

        public async Task<IEnumerable<Contract>> FindByUserId(int userId)
        {
            return await _context.Contracts
                .Where(p=>p.UserId == userId)
                .Include(p=>p.User)
                .ToListAsync();
        }
    }
}