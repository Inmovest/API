using System.Collections;
using System.Collections.Generic;

namespace InmovestAPI.Domain.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Project> Projects { get; set; } = new List<Project>();
    }
}