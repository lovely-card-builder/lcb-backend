using AutoMapper;
using Lcb.DAL.Models;

namespace Lcb.BLL.MediatR.GetPostcard;

public static partial class GetPostcard
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Postcard, Response>();
            CreateMap<PostcardImage, ResponseImage>();
        }
    }
}