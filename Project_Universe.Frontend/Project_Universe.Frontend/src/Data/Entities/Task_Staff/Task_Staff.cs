using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Frontend.src.Data.Entities.Task_Staff
{
    public class Task_Staff
    {
        public int id_task_staff { get; set; }
        public int? id_task { get; set; }
        public string name_task { get; set; }
        public int? id_staff { get; set; }
        public string name_staff { get; set; }
        public string lastname_staff { get; set; }
        public string patronymic_staff { get; set; }
    }
}
