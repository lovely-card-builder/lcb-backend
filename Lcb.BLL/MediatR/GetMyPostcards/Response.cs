namespace Lcb.BLL.MediatR.GetMyPostcards;

public static partial class GetMyPostcards
{
    public class Response
    {
        public string WishFrom { get; set; }

        public string WishTo { get; set; }

        public string WishText { get; set; }

        public ICollection<string> Images { get; set; }
    }
}