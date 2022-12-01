using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class TaskValidator:AbstractValidator<EntTask>
    {
        public TaskValidator()
        {
            RuleFor(x => x.title).NotEmpty().WithMessage("Title cant be empty")
                                .MinimumLength(3).WithMessage("Title must be greater than 3 letters")
                                .MaximumLength(20).WithMessage("Title must be less than 20 letters");
           

        }
    }
}
