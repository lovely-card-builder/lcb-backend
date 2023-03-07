using MediatR;

namespace Lcb.BLL.MediatR.UserRegister;

public class UserRegisterRequest : IRequest
{
    public string Login { get; set; }
    
    public string Password { get; set; }
}