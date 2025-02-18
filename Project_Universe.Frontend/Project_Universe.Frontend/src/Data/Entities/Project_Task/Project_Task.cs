using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Frontend.src.Data.Entities.Project_Task
{
    public class Project_Task
    {
        public int id_project_task { get; set; }
        public int? id_task { get; set; }
        public string name_task { get; set; }
        public int? id_project { get; set; }
        public string name_project { get; set; }
    }
}
