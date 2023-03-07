using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Lcb.Infrastructure.Configs;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Lcb.Web.Auth;

public class AuthoriserService
{
    private JwtConfig _config;

    public AuthoriserService(IOptions<JwtConfig> options)
    {
        _config = options.Value;
    }

    public async Task<string> GenerateToken(string userIdentity)
    {
        var issuer = _config.Issuer;
        var audience = _config.Audience;

        // Now its ime to define the jwt token which will be responsible of creating our tokens
        // var jwtTokenHandler = new JwtSecurityTokenHandler();

        // We get our secret from the appsettings
        var key = Encoding.ASCII.GetBytes(_config.Key);

        var jwt = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            notBefore: null,
            claims: new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userIdentity),
                // the JTI is used for our refresh token which we will be convering in the next video
                new Claim(
                    JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid()
                        .ToString()
                )
            },
            expires: DateTime.UtcNow.AddHours(6),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        );

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return encodedJwt;
    }
}