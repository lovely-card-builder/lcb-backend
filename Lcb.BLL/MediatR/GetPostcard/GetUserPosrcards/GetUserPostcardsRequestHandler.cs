using AutoMapper;
using Lcb.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Template.DAL.Models;

namespace Lcb.BLL.MediatR.GetPostcard.GetUserPosrcards;

public class GetUserPostcardsRequestHandler : IRequestHandler<GetUserPostcardsRequest, ICollection<GetUserPostcardResponse>>
{
    private readonly IRepository<User> _repository;
    private readonly IMapper _mapper;

    public GetUserPostcardsRequestHandler(IRepository<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ICollection<GetUserPostcardResponse>> Handle(GetUserPostcardsRequest request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetAll().FirstAsync(u => u.Id == request.UserId, cancellationToken: cancellationToken);
        var dto = _mapper.Map<ICollection<GetUserPostcardResponse>>(user.Postcards);
        return dto;
    }
}