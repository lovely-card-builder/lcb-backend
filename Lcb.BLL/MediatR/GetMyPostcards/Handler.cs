using AutoMapper;
using Lcb.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Template.DAL.Models;
using Template.Infrastructure;

namespace Lcb.BLL.MediatR.GetMyPostcards;

public static partial class GetMyPostcards
{
    public class Handler : IRequestHandler<Command, ICollection<Response>>
    {
        private readonly IRepository<Postcard> _repository;
        private readonly IMapper _mapper;

        public Handler(IRepository<Postcard> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<Response>> Handle(Command command, CancellationToken cancellationToken)
        {
            var postcards = await _repository
                .GetAll()
                .Where(x => x.UserId == command.UserId)
                .ToListAsync(cancellationToken: cancellationToken);

            var mapped = _mapper.Map<ICollection<Response>>(postcards);

            return mapped;
        }
    }
}