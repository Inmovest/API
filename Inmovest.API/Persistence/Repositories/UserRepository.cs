using System.Collections.Generic;
using System.Threading.Tasks;
using Inmovest.API.Domain;
using Inmovest.API.Domain.Repositories;
using Inmovest.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Inmovest.API.Persistence.Repositories
{
    public class UserRepository: BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}