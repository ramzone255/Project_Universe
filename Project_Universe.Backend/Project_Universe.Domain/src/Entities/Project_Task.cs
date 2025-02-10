using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Domain.src.Entities
{
    public class Project_Task
    {
        [Key]
        public int id_project_task { get; set; }
        [ForeignKey("Task")]
        public int id_task { get; set; }
        public Task Task { get; set; }
        [ForeignKey("Project")]
        public int id_project { get; set; }
        public Project Project { get; set; }
    }
}
