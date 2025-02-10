using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Domain.src.Entities
{
    public class Contractor_Company
    {
        [Key]
        public int id_contractor_company { get; set; }
        public string name_contractor_company { get; set; }
        public string description_contractor_company { get; set; }
        public ICollection<Project> Project { get; set; }
    }
}
