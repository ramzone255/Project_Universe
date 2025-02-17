using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Frontend.src.Data.Entities.Task_Entity
{
    public class Task_Entity
    {
        public int id_task { get; set; }
        public string name_task { get; set; }
        public string comment { get; set; }
        public int id_status { get; set; }
        public string name_status { get; set; }
        public int id_priority { get; set; }
        public string name_priority { get; set; }
    }
}
