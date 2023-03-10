using MediatR;

namespace Lcb.BLL.MediatR.GetMyPostcards;

public static partial class GetMyPostcards
{
    public class Command : IRequest<ICollection<Response>>
    {
        public Guid? UserId { get; set; }

        public Command(Guid? userId)
        {
            UserId = userId;
        }
    }
}