using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InmovestAPI.Domain.Models;

namespace InmovestAPI.Domain.Services.Communication
{
    public class ProjectResponse : BaseResponse<Project>
    {
        public ProjectResponse(string message) : base(message) { }
        public ProjectResponse(Project resource) : base(resource) { }
    }
}
