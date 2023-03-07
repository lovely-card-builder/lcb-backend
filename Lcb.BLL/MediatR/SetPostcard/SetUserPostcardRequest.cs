using MediatR;

namespace Lcb.BLL.MediatR.SetPostcard;

public class SetUserPostcardRequest : IRequest
{
    public Guid PostcardId { get; set; }
    
    public string? WishFrom { get; set; }

    public string? WishTo { get; set; }

    public string? WishText { get; set; }
    
    public string? FileName { get; set; }
}