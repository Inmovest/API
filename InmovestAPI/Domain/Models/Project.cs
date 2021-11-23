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
        
        // Relationships
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        public IList<Article> Articles { get; set; } = new List<Article>();

        public IList<Campaign> Campaigns { get; set; } = new List<Campaign>();
        //recuerda agregar el public Developer Developer {get;set;} y el relacionado a distrinct tambien
    }
}
