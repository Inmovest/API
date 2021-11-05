using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InmovestAPI.Domain.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        //public int DeveloperId { get; set; }
        //public int DistrictId { get; set; }
        //recuerda agregar el public Developer Developer {get;set;} y el relacionado a distrinct tambien
    }
}
