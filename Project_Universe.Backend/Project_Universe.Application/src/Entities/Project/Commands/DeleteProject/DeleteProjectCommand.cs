using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest
    {
        public int id_project { get; set; }
    }
}
