using Lcb.BLL.MediatR.UserRegister;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lcb.Web.Controllers;

public class UserController : LcbController
{

    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<Unit> Register([FromBody] UserRegisterRequest request, CancellationToken ct)
    {
        return await _mediator.Send(request, ct);
    }
}