using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x=>x.userName).NotEmpty().WithMessage("Username cant be empty")
                                .MinimumLength(3).WithMessage("Usename must be greater than 3 letters")
                                .MaximumLength(20).WithMessage("UserName must be less than 20 letters");

            RuleFor(x => x.password).NotEmpty().WithMessage("Password cant be empty")
                                .MinimumLength(3).WithMessage("Password must be greater than 3 letters")
                                .MaximumLength(20).WithMessage("Password must be less than 20 letters");

        }
    }
}
