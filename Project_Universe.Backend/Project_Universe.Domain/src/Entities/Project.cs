using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Domain.src.Entities
{
    public class Project
    {
        [Key]
        public int id_project { get; set; }
        public string name_project { get; set; }
        public ICollection<Project_Task> Project_Task { get; set; }
        [ForeignKey("Contractor_Company")]
        public int id_contractor_company { get; set; }
        public Contractor_Company Contractor_Company { get; set; }
        [ForeignKey("Customer_Company")]
        public int id_customer_company { get; set; }
        public Customer_Company Customer_Company { get; set; }
        [ForeignKey("Priority")]
        public int id_priority { get; set; }
        public Priority Priority { get; set; }
    }
}
