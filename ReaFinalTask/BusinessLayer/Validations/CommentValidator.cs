using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class CommentValidator:AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.commentText).NotEmpty().WithMessage("commentText cant be empty")
                                .MinimumLength(3).WithMessage("commentText must be greater than 3 letters")
                                .MaximumLength(50).WithMessage("commentText must be less than 50 letters");
        }
    }
}
