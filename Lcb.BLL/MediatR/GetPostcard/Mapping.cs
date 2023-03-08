using AutoMapper;
using Template.DAL.Models;

namespace Lcb.BLL.MediatR.GetPostcard;

public static partial class GetPostcard
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Postcard, Response>()
                .ForMember(dst => dst.Images, cfg => cfg.MapFrom(src => src.Images.Select(x => x.FileName)));
        }
    }
}