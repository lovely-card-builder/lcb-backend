using AutoMapper;
using Lcb.DAL.Models;

namespace Lcb.BLL.MediatR.GetMyPostcards;

public static partial class GetMyPostcards
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