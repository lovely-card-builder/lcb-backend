using Lcb.DAL.Models;
using Lcb.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lcb.BLL.MediatR.CreateUser;

public static partial class CreateUser
{
    public class Handler : IRequestHandler<Command, CommandResult>
    {
        private readonly IRepository<User> _repository;

        public Handler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(Command request, CancellationToken cancellationToken)
        {
            if (await _repository
                    .GetAll()
                    .AnyAsync(x => x.Login == request.Login, cancellationToken: cancellationToken))
            {
                throw new BusinessException("Login already exists");
            }

            var user = new User()
            {
                Login = request.Login,
                Password = request.Password
            };

            await _repository.Add(user);

            return new CommandResult(user.Id);
        }
    }
}