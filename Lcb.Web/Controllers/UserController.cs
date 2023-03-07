using MediatR;

namespace Lcb.Web.Controllers;

public class UserController : LcbController
{

    private IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
}