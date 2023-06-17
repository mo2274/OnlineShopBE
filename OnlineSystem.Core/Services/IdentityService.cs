using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineSystem.Core.Entities;

namespace OnlineSystem.Core.Services;

public class IdentityService : IIdentityService
{
    private readonly IConfiguration _configuration;
    private readonly string _key;
    private readonly string _issuer;
    private readonly string _audience;
    private readonly TimeSpan _tokenLifeTime = TimeSpan.FromHours(6);

    public IdentityService(IConfiguration configuration)
    {
        _configuration = configuration;
        _key = configuration["JwtSettings:Key"] ?? "";
        _issuer = configuration["JwtSettings:Issuer"] ?? "";
        _audience = configuration["JwtSettings:Audience"] ?? "";
    }
    public string GetToken(User user)
    {
        var handler = new JwtSecurityTokenHandler();
        
        var claims = new List<Claim>()
        {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Role, "admin"),
            new (ClaimTypes.Email, user.Email),
            new (ClaimTypes.Surname, user.Name),
        };

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.Add(_tokenLifeTime),
            Issuer = _issuer,
            Audience = _audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key)), 
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = handler.CreateToken(tokenDescriptor);

        return handler.WriteToken(token);
    }
}