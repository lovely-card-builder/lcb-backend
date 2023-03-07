using Lcb.BLL.MediatR.CreatePostcard;
using Lcb.Web.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lcb.Web.Controllers;

public class PostcardController : LcbController
{
    private readonly IMediator _mediator;

    public PostcardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize]
    [AllowAnonymous]
    public async Task<Guid> Create([FromBody] CreatePostcard.Command command, CancellationToken ct)
    {
        var userId = User.TryGetId();
        command.UserId = userId;
        return await _mediator.Send(command, ct);
    }

    [HttpPost]
    [Authorize]
    public async Task<Guid> GetMy([FromBody] CreatePostcard.Command command, CancellationToken ct)
    {
        var userId = User.TryGetId();
        command.UserId = userId;
        return await _mediator.Send(command, ct);
    }
}