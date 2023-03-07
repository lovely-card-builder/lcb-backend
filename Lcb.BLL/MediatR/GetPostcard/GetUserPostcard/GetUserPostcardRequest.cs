using MediatR;

namespace Lcb.BLL.MediatR.GetPostcard.GetUserPostcard;

public class GetUserPostcardRequest : IRequest<GetUserPostcardResponse>
{
    public Guid PostcardId { get; set; }
}