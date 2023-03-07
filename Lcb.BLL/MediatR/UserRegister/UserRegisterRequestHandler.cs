using AutoMapper;
using MediatR;
using Template.DAL.Models;
using Template.Infrastructure;

namespace Lcb.BLL.MediatR.UserRegister;

public class UserRegisterRequestHandler : IRequestHandler<UserRegisterRequest>
{
    private readonly IRepository<User> _repository;
    private readonly IMapper _mapper;

    public UserRegisterRequestHandler(IRepository<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UserRegisterRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        await _repository.Add(user);
        return Unit.Value;
    }
}