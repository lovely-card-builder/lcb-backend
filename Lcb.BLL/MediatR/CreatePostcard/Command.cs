using MediatR;
using Newtonsoft.Json;

namespace Lcb.BLL.MediatR.CreatePostcard;

public static partial class CreatePostcard
{
    public class Command : IRequest<Guid>
    {
        public Guid? UserId { get; set; }
        
        public string? WishFrom { get; set; }

        public string WishTo { get; set; }

        public string? WishText { get; set; }

        public ICollection<CommandImage> Images { get; set; }
    }

    public class CommandImage
    {
        public string FileName { get; set; }
        public string Title { get; set; }
    }
}