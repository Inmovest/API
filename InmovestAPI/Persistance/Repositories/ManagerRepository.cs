using System.Collections.Generic;
using System.Threading.Tasks;
using InmovestAPI.Domain.Models;
using InmovestAPI.Domain.Repositories;
using InmovestAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InmovestAPI.Persistance.Repositories
{
    public class ManagerRepository : BaseRepository, IManagerRespository
    {
        public ManagerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Manager>> ListAsync()
        {
            return await _context.Managers.ToListAsync();
        }

        public async Task AddAsync(Manager manager)
        {
            await _context.Managers.AddAsync(manager);
        }

        public async Task<Manager> FindByIdAsync(int id)
        {
            return await _context.Managers.FindAsync(id);
        }

        public void Update(Manager manager)
        {
            _context.Managers.Update(manager);
        }

        public void Remove(Manager manager)
        {
            _context.Managers.Update(manager);
        }
    }
}