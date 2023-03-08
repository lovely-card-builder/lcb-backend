using Lcb.BLL.MediatR.CreatePostcard;
using Lcb.BLL.MediatR.GetMyPostcards;
using Lcb.Web.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Template.DAL.Models;

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
    public async Task<ActionResult<Guid>> Create([FromBody] CreatePostcard.Command command, CancellationToken ct)
    {
        var userId = User.TryGetId();
        command.UserId = userId;
        return Ok(await _mediator.Send(command, ct));
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ICollection<Postcard>>> GetMy(CancellationToken ct)
    {
        var userId = User.TryGetId();
        return Ok(await _mediator.Send(new GetMyPostcards.Command(userId), ct));
    }
}