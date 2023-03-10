using FluentValidation;

namespace Lcb.BLL.MediatR.AuthorizeUser;

public static partial class AuthorizeUser
{
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(x => x.Login)
                .NotEmpty();
            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}