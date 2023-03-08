using MediatR;

namespace Lcb.BLL.MediatR.GetPostcard;

public static partial class GetPostcard
{
    public class Command : IRequest<Response>
    {
        public Guid PostcardId { get; set; }

        public Command(Guid postcardId)
        {
            PostcardId = postcardId;
        }
    }
}