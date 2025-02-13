using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project_Universe.Application.src.Common.Exceptions;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffDetails;
using Project_Universe.Application.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.User.Commands.SingInUser
{
    public class SignInUserCommandHandler
        : IRequestHandler<SignInUserCommand, SignInUserCommandVm?>
    {
        private readonly IProject_UniverseDbContext _dbContext;
        private readonly IMapper _mapper;

        public SignInUserCommandHandler(IProject_UniverseDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<SignInUserCommandVm?> Handle(SignInUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _dbContext.User
                .Where(note => note.user_name == request.user_name && 
                note.user_password == request.user_password)
                .Select(note => new {note.Staff.id_post, note.id_staff, note.Staff.Post.name_post})
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null)
            {
                return null;
            }

            return new SignInUserCommandVm(user.id_post, user.id_staff, user.name_post);
        }
    }
}
