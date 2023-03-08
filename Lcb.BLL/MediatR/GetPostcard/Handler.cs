using AutoMapper;
using Lcb.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Template.DAL.Models;

namespace Lcb.BLL.MediatR.GetPostcard;

public static partial class GetPostcard
{
    public class Handler : IRequestHandler<Command, Response>
    {
        private readonly IRepository<Postcard> _repository;
        private readonly IMapper _mapper;

        public Handler(IRepository<Postcard> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            var postcard = await _repository.GetAll()
                .Include(x => x.Images.OrderBy(y => y.Order))
                .FirstAsync(p => p.Id == request.PostcardId, cancellationToken: cancellationToken);
            return _mapper.Map<Response>(postcard);
        }
    }
}