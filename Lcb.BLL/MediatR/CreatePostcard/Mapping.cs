using AutoMapper;
using Lcb.DAL.Models;

namespace Lcb.BLL.MediatR.CreatePostcard;

public static partial class CreatePostcard
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Command, Postcard>();
            
            CreateMap<CommandImage, PostcardImage>();
        }
    }
}