using System.Collections.Generic;
using System.Threading.Tasks;
using Inmovest.API.Domain;
using Inmovest.API.Domain.Repositories;
using Inmovest.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Inmovest.API.Persistence.Repositories
{
    public class DeveloperRepository : BaseRepository, IDeveloperRepository
    {
        public DeveloperRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Developer>> ListAsync()
        {
            return await _context.Developers.ToListAsync();
        }
    }
}