using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InmovestAPI.Domain.Models;
using InmovestAPI.Domain.Services.Communication;

namespace InmovestAPI.Domain.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> ListAsync();
        Task<IEnumerable<Project>> ListByManagerIdAsync(int managerId);
        Task<ProjectResponse> SaveAsync(Project project);
        Task<ProjectResponse> UpdateAsync(int id, Project project);
        Task<ProjectResponse> DeleteAsync(int id);
        //Agregar las relaciones de ListByEntityIdAsync
    }
}
