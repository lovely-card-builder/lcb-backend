using Lcb.BLL.MediatR.AddUserPostcard;
using Lcb.BLL.MediatR.CreatePostcard;
using Lcb.BLL.MediatR.GetUserPosrcards;
using MediatR;
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
    public async Task<ICollection<GetUserPostcardResponse>> GetAll([FromBody] GetUserPostcardsRequest request, CancellationToken ct)
    {
        return await _mediator.Send(request, ct);
    }

    [HttpPost]
    public async Task<Unit> GetById([FromBody] AddUserPostcardRequest request, CancellationToken ct)
    {
        return await _mediator.Send(request, ct);
    }

    [HttpPost]
    public async Task<Guid> Create([FromBody] CreatePostcard.Command command, CancellationToken ct)
    {
        return await _mediator.Send(command, ct);
    }
}