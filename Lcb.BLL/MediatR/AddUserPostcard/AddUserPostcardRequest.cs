using MediatR;

namespace Lcb.BLL.MediatR.AddUserPostcard;

public class AddUserPostcardRequest : IRequest
{
    public Guid UserId { get; set; }
    
    public string WishFrom { get; set; }

    public string WishTo { get; set; }

    public string WishText { get; set; }
    
    public string FileName { get; set; }
}