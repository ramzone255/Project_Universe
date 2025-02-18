using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<int>
    {
        public string name_project { get; set; }
        public DateTime start_date_project { get; set; }
        public DateTime? end_date_project { get; set; }
        public int id_contractor_company { get; set; }
        public int id_customer_company { get; set; }
        public int id_priority { get; set; }
    }
}
