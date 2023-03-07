using Lcb.BLL.MediatR.AuthorizeUser;
using Lcb.BLL.MediatR.CreateUser;
using Lcb.Web.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lcb.Web.Controllers
{
    [Controller]
    [Route("[controller]/[action]")]
    [ResponseCache(NoStore = true)]
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;
        private readonly AuthoriserService _authoriserService;

        public AccountController(IMediator mediator, AuthoriserService authoriserService)
        {
            _authoriserService = authoriserService;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody] CreateUser.Command command)
        {
            var result = await _mediator.Send(command);

            var token = await _authoriserService.GenerateToken(result.Id.ToString());

            return Ok(token);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login([FromBody] AuthorizeUser.Command command)
        {
            var result = await _mediator.Send(command);

            var token = await _authoriserService.GenerateToken(result.Id.ToString());

            return Ok(token);
        }
    }
}