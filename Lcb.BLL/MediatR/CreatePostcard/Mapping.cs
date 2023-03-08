using AutoMapper;
using Lcb.DAL.Models;

namespace Lcb.BLL.MediatR.CreatePostcard;

public static partial class CreatePostcard
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Command, Postcard>()
                .ForMember(dst => dst.Images, cfg => cfg.MapFrom(src => src.Images.Select((x, i) => new PostcardImage() {FileName = x, Order = i})));
        }
    }
}