using Lcb.BLL.MediatR.GetUserPosrcards;
using MediatR;

namespace Lcb.BLL.MediatR.GetPostcard;

public class GetUserPostcardRequest : IRequest<GetUserPostcardResponse>
{
    public Guid PostcardId { get; set; }
}