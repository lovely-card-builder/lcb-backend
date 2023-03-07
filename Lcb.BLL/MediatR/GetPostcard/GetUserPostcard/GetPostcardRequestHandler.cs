using AutoMapper;
using Lcb.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Template.DAL.Models;

namespace Lcb.BLL.MediatR.GetPostcard.GetUserPostcard;

public class GetPostcardRequestHandler : IRequestHandler<GetUserPostcardRequest, GetUserPostcardResponse>
{
    private readonly IRepository<Postcard> _repository;
    private readonly IMapper _mapper;

    public GetPostcardRequestHandler(IRepository<Postcard> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetUserPostcardResponse> Handle(GetUserPostcardRequest request, CancellationToken cancellationToken)
    {
        var postcard = await _repository.GetAll().FirstAsync(p => p.Id == request.PostcardId, cancellationToken: cancellationToken);
        return _mapper.Map<GetUserPostcardResponse>(postcard);
    }
}