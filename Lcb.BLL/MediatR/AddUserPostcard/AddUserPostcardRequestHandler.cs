using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Template.DAL.Models;
using Template.Infrastructure;

namespace Lcb.BLL.MediatR.AddUserPostcard;

public class AddUserPostcardRequestHandler : IRequestHandler<AddUserPostcardRequest>
{
    private readonly IRepository<Postcard> _repository;

    private readonly IMapper _mapper;

    public AddUserPostcardRequestHandler(IRepository<Postcard> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(AddUserPostcardRequest request, CancellationToken cancellationToken)
    {
        var postcard = _mapper.Map<Postcard>(request);
        await _repository.Add(postcard);

        return Unit.Value;
    }
}