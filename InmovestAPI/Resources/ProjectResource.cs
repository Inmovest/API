using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InmovestAPI.Resources
{
    public class ProjectResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        //public DeveloperResource Developer {get;set;}
        //public DistrictResource District {get;set;}
    }
}
