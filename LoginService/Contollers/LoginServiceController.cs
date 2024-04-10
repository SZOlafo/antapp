using antapp.Shared.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using antapp.Shared.Auth.Dtos;
using antapp.Shared.Auth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace antapp.LoginService.Contollers;

public class LoginServiceController : Controller
{
    private readonly IAuthenticationService _authenticationService;

    public LoginServiceController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public IActionResult Index()
    {
        //var userName = User.Identity.Name;
        //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
        var response = await _authenticationService.Login(request);

        Response.Cookies.Append("AuthToken", response, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            Expires = DateTimeOffset.Now.AddHours(1),
            SameSite = SameSiteMode.Strict
        });
        return Ok(response);
    }
}

