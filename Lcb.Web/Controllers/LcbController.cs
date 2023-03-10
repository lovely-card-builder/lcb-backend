using Microsoft.AspNetCore.Mvc;

namespace Lcb.Web.Controllers;

[Controller]
[Route("[controller]/[action]")]
public abstract class LcbController : Controller
{
}