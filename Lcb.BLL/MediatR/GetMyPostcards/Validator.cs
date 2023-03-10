using FluentValidation;

namespace Lcb.BLL.MediatR.GetMyPostcards;

public static partial class GetMyPostcards
{
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
        }
    }
}