using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InmovestAPI.Resources
{
    public class SaveProjectResource
    {
        [Required]
        [MaxLength(90)]
        public string Name { get; set; }
        [Required]
        [MaxLength(1500)]
        public string Description { get; set; }
        [Required]
        [MaxLength(250)]
        public string PhotoUrl { get; set; }
        [Required]
        public int ManagerId { get; set; }
        //public int DistrictId { get; set; }
    }
}
