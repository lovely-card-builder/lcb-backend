using FluentValidation;

namespace Lcb.BLL.MediatR.CreateUser;

public static partial class CreateUser
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