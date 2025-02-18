using MediatR;
using Project_Universe.Application.src.Entities.Staff.Commands.CreateStaff;
using Project_Universe.Application.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project.Commands.CreateProject
{
    public class CreateProjectCommandHandler
        : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProject_UniverseDbContext _dbContext;

        public CreateProjectCommandHandler(IProject_UniverseDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var projects = new Domain.src.Entities.Project
            {
                name_project = request.name_project,
                start_date_project = DateTime.Now,
                end_date_project = request.end_date_project,
                id_contractor_company = request.id_contractor_company,
                id_customer_company = request.id_customer_company,
                id_priority = request.id_priority
            };

            await _dbContext.Project.AddAsync(projects, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return projects.id_project;
        }
    }
}
