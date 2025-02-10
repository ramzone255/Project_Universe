using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Domain.src.Entities
{
    public class Priority
    {
        [Key]
        public int id_priority {  get; set; }
        public string name_priority { get; set; }
        public ICollection<Task> Task { get; set; }
        public ICollection<Project> Project { get; set; }
    }
}
