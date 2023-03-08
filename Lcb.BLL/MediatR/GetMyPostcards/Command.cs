using MediatR;
using Template.DAL.Models;

namespace Lcb.BLL.MediatR.GetMyPostcards;

public static partial class GetMyPostcards
{
    public class Command : IRequest<ICollection<Postcard>>
    {
        public Guid? UserId { get; set; }

        public Command(Guid? userId)
        {
            UserId = userId;
        }
    }
}