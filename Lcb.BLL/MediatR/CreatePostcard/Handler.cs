using AutoMapper;
using Lcb.DAL.Models;
using Lcb.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Template.Infrastructure;

namespace Lcb.BLL.MediatR.CreatePostcard;

public static partial class CreatePostcard
{
    public class Handler : IRequestHandler<Command, Guid>
    {
        private readonly IRepository<Postcard> _repository;
        private readonly IMapper _mapper;

        public Handler(IRepository<Postcard> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(Command command, CancellationToken cancellationToken)
        {
            var postcard = _mapper.Map<Postcard>(command);

            var _ = postcard.Images.Select((x, i) => x.Order = i);

            await _repository.Add(postcard);

            return postcard.Id;
        }
    }
}