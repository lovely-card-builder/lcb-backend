using AutoMapper;
using Lcb.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Template.DAL.Models;
using Template.Infrastructure;

namespace Lcb.BLL.MediatR.GetMyPostcards;

public static partial class GetMyPostcards
{
    public class Handler : IRequestHandler<Command, ICollection<Postcard>>
    {
        private readonly IRepository<Postcard> _repository;
        private readonly IMapper _mapper;

        public Handler(IRepository<Postcard> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<Postcard>> Handle(Command command, CancellationToken cancellationToken)
        {
            var postcards = await _repository.GetAll().Where(x => x.UserId == command.UserId).ToListAsync(cancellationToken: cancellationToken);

            return postcards;
        }
    }
}