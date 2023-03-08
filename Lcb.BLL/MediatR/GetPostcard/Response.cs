namespace Lcb.BLL.MediatR.GetPostcard;

public static partial class GetPostcard
{
    public class Response
    {
        public string WishFrom { get; set; }

        public string WishTo { get; set; }

        public string WishText { get; set; }

        public ICollection<ResponseImage> Images { get; set; }
    }
    
    public class ResponseImage
    {
        public string FileName { get; set; }
        public string Title { get; set; }
    }
}