using Lcb.DAL.Models;
using Lcb.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lcb.BLL.MediatR.AuthorizeUser;

public static partial class AuthorizeUser
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
            var user = await _repository
                .GetAll()
                .FirstOrDefaultAsync(x => x.Login == request.Login, cancellationToken: cancellationToken);

            if (user is null)
            {
                throw new BusinessException("User was not found");
            }

            if (user.Password != request.Password)
            {
                throw new BusinessException("Invalid password");
            }

            return new CommandResult(user.Id);
        }
    }
}