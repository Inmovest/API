using AutoMapper;
using InmovestAPI.Domain.Models;
using InmovestAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InmovestAPI.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveProjectResource, Project>();
            CreateMap<SaveManagerResource, Manager>();
            CreateMap<SaveArticleResource, Article>();
        }
    }
}
