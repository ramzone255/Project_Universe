using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project_Universe.Frontend.src.Data.Entities.Project
{
    public class Project
    {
        public int id_project { get; set; }
        public string name_project { get; set; }
        public DateTime start_date_project { get; set; }
        public DateTime? end_date_project { get; set; }
        public int id_contractor_company { get; set; }
        public int id_customer_company { get; set; }
        public int id_priority { get; set; }
        public string name_priority {  get; set; }
        public string name_contractor_company { get; set; }
        public string name_customer_company { get; set; }
    }
}
