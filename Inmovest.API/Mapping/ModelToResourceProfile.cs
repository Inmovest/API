using AutoMapper;
using Inmovest.API.Domain;
using Inmovest.API.Resources;

namespace Inmovest.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Developer, DeveloperResource>();
        }
    }
}