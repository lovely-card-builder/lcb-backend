using MediatR;

namespace Lcb.BLL.MediatR.CreateUser;

public static partial class CreateUser
{
    public class Command : IRequest<CommandResult>
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public Command(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }

    public class CommandResult
    {
        public Guid Id { get; set; }

        public CommandResult(Guid id)
        {
            Id = id;
        }
    }
}