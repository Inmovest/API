using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InmovestAPI.Domain.Models;
using InmovestAPI.Domain.Repositories;
using InmovestAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InmovestAPI.Persistance.Repositories
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context) { }
        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        public async Task<Project> FindByIdAsync(int id)
        {
            return await _context.Projects
                .Include(p=>p.Manager)
                .FirstOrDefaultAsync(p => p.Id == id);
            //recuerda agregar las relaciones con District y Developer, usando el .include.
        }

        public async Task<Project> FindByNameAsync(string name)
        {
            return await _context.Projects
                .Include(p=>p.Manager)
                .FirstOrDefaultAsync(p => p.Name == name);
            //recuerda agregar las relaciones con District y Developer, usando el .include.
        }

        public async Task<IEnumerable<Project>> FindByManagerId(int managerId)
        {
            return await _context.Projects
                .Where(p => p.ManagerId == managerId)
                .Include(p => p.Manager)
                .ToListAsync();
        }

        public async Task<IEnumerable<Project>> ListAsync()
        {
            return await _context.Projects
                .Include(p=>p.Manager)
                .ToListAsync();
            //antes de ToListAsync Una vez que se creen las entidades Developer y District debería ir .Include(p => p.District).
        }

        public void Remove(Project project)
        {
            _context.Projects.Remove(project);
        }

        public void Update(Project project)
        {
            _context.Projects.Update(project);
        }
    }
}
