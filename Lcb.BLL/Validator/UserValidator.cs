using FluentValidation;
using Lcb.BLL.MediatR.UserRegister;

namespace Espa.BLL.Validator;

public class UserValidator : AbstractValidator<UserRegisterRequest>
{
    public UserValidator()
    {
        RuleFor(x => x.Password.Length).GreaterThan(6).WithMessage("Пароль больше 6 символов, позязя");
    }
}