using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Domain.src.Entities
{
    public class Task_Staff
    {
        [Key]
        public int id_task_staff { get; set; }
        [ForeignKey("Task")]
        public int id_task { get; set; }
        public Task Task { get; set; }
        [ForeignKey("Staff")]
        public int id_staff { get; set; }
        public Staff Staff { get; set; }
    }
}
