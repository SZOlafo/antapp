using antapp.Shared.Auth.Dtos;
using antapp.Shared.Auth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace antapp.LoginService.Contollers;

public class RegisterServiceController : Controller
{
    private readonly IAuthenticationService _authenticationService;

    public RegisterServiceController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
    {
        var response = await _authenticationService.Register(request);
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
