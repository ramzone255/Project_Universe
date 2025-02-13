using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.User.Commands.SingInUser
{
    public class SignInUserCommand : IRequest<SignInUserCommandVm?>
    {
        public string user_name { get; set; }
        public string user_password { get; set; }
    }
}
