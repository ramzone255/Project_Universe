using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Domain.src.Entities
{
    public class Status
    {
        [Key]
        public int id_status { get; set; }
        public string name_status { get; set; }
        public ICollection<Task> Task { get; set; }
    }
}
