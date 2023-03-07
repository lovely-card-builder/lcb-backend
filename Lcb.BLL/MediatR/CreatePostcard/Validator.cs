using FluentValidation;

namespace Lcb.BLL.MediatR.CreatePostcard;

public static partial class CreatePostcard
{
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(x => x.WishTo)
                .NotEmpty();

            RuleFor(x => x.Images)
                .NotEmpty();
        }
    }
}