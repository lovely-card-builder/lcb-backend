using Lcb.BLL.MediatR.CreatePostcard;
using Lcb.BLL.MediatR.GetMyPostcards;
using Lcb.BLL.MediatR.GetPostcard;
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
    public async Task<ActionResult<Guid>> Create([FromBody] CreatePostcard.Command command, CancellationToken ct)
    {
        var userId = User.TryGetId();
        command.UserId = userId;
        return Ok(await _mediator.Send(command, ct));
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ICollection<GetMyPostcards.Response>>> GetMy(CancellationToken ct)
    {
        var userId = User.TryGetId();
        return Ok(await _mediator.Send(new GetMyPostcards.Command(userId), ct));
    }

    [HttpGet]
    [Route("~/[controller]/{id:guid}")]
    public async Task<ActionResult<GetPostcard.Response>> Get(Guid id, CancellationToken ct)
    {
        return Ok(await _mediator.Send(new GetPostcard.Command(id), ct));
    }
}