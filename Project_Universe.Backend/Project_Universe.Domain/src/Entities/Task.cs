using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Domain.src.Entities
{
    public class Task
    {
        [Key]
        public int id_task { get; set; }
        public string name_task { get; set; }
        public string comment { get; set; }
        public ICollection<Task_Staff> Task_Staff { get; set; }
        public ICollection<Project_Task> Project_Task { get; set; }
        [ForeignKey("Status")]
        public int id_status { get; set; }
        public Status Status { get; set; }
        [ForeignKey("Priority")]
        public int id_priority { get; set; }
        public Priority Priority { get; set; }
    }
}
