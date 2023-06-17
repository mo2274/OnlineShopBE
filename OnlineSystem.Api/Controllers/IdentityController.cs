using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineSystem.Core.Entities;
using OnlineSystem.Core.Requests;
using OnlineSystem.Core.Services;

namespace OnlineSystem.Api.Controllers;

public class IdentityController : ControllerBase
{
    private readonly IIdentityService _identityService;


    public IdentityController(IConfiguration configuration, IIdentityService identityService)
    {
        _identityService = identityService;
      
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SingIn(LoginPayload loginPayload)
    {
        // TODO
        // should validate the user here from the cred and if not valid we return bad request
        // if the cred is valid get a user
        // Mocking user
        var mockingUser = new User()
        {
            Id = 1,
            Name = "Mohamed",
            Email = "Mohamed@google.com"
        };

        var jwt = _identityService.GetToken(mockingUser);

        return Ok(new
        {
            token = jwt
        });
    }
    
    [HttpPost("signup")]
    public async Task<IActionResult> SingUp(LoginPayload loginPayload)
    {
        return Ok();
    }
    
    [HttpPost("signout")]
    public async Task<IActionResult> SingOut(string userName, string Password)
    {
        return Ok();
    }
}