using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Domain.src.Entities
{
    public class Customer_Company
    {
        [Key]
        public int id_customer_company {  get; set; }
        public string name_customer_company { get; set; }
        public string description_customer_company { get; set; }
        public ICollection<Project> Project { get; set; }
    }
}
