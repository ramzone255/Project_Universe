using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.User.Commands.SingInUser
{
    public class SignInUserCommandValidator : AbstractValidator<SignInUserCommand>
    {
        public SignInUserCommandValidator()
        {
            RuleFor(entity => entity.user_name).MaximumLength(20).NotEmpty();
            RuleFor(entity => entity.user_password).MaximumLength(20).NotEmpty();
        }
    }
}
