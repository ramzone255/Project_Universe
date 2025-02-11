using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest
    {
        public int id_project { get; set; }
        public string name_project { get; set; }
        public DateOnly? end_date_project { get; set; }
        public int id_contractor_company { get; set; }
        public int id_customer_company { get; set; }
        public int id_priority { get; set; }
    }
}
