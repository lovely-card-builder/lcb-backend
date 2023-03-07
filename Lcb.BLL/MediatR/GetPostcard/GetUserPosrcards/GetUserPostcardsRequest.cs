using MediatR;

namespace Lcb.BLL.MediatR.GetPostcard.GetUserPosrcards;

public class GetUserPostcardsRequest : IRequest<ICollection<GetUserPostcardResponse>>
{
    public Guid UserId { get; set; }

    public GetUserPostcardsRequest(Guid id)
    {
        UserId = id;
    }
}