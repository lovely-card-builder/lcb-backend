using System.Security.Claims;

namespace Lcb.Web.Auth;

public static class Extensions
{
    public static Guid? TryGetId(this ClaimsPrincipal user)
    {
        var claim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
        if (Guid.TryParse(claim?.Value, out var result))
        {
            return result;
        }

        return null;
    }
}