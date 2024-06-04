using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using antapp.Shared.Auth;
using antapp.Shared.Auth.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace antapp.Shared.Auth.Services;

public interface IAuthenticationService
{
    Task Register(RegisterRequestDto request);
    Task Login(LoginRequestDto request);
    Task Logout();
    bool IsAuth();
}

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _contextAccessor;

    public AuthenticationService(UserManager<User> userManager, IConfiguration configuration, IHttpContextAccessor contextAccessor)
    {
        _userManager = userManager;
        _configuration = configuration;
        _contextAccessor = contextAccessor;
    }

    public async Task Register(RegisterRequestDto request)
    {
        var userByEmail = await _userManager.FindByEmailAsync(request.Email);
        var userByUsername = await _userManager.FindByNameAsync(request.UserName);
        if (userByEmail is not null || userByUsername is not null)
        {
            throw new ArgumentException($"User with email {request.Email} or username {request.UserName} already exists.");
        }

        User user = new()
        {
            Email = request.Email,
            UserName = request.UserName,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new ArgumentException($"Unable to register user {request.UserName} errors: {GetErrorsText(result.Errors)}");
        }
        await Login(new LoginRequestDto { UserName = request.Email, Password = request.Password });
    }

    public async Task Login(LoginRequestDto request)
    {
        var user = await _userManager.FindByNameAsync(request.UserName);

        if (user is null)
        {
            user = await _userManager.FindByEmailAsync(request.UserName);
        }

        if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
        {
            throw new ArgumentException($"Unable to authenticate user {request.UserName}");
        }

        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.NameIdentifier, user.Id),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var token = GetToken(authClaims);
        var returnToken = new JwtSecurityTokenHandler().WriteToken(token);
        _contextAccessor.HttpContext?.Response.Cookies.Append("AuthToken", returnToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            Expires = DateTimeOffset.Now.AddHours(1),
            SameSite = SameSiteMode.Strict
        });
    }

    private JwtSecurityToken GetToken(IEnumerable<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(1),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

        return token;
    }

    private string GetErrorsText(IEnumerable<IdentityError> errors)
    {
        return string.Join(", ", errors.Select(error => error.Description).ToArray());
    }

    public bool IsAuth()
    {
        var context = _contextAccessor.HttpContext;
        return context?.User?.Identity?.IsAuthenticated ?? false;
    }

    public Task Logout()
    {
        var context = _contextAccessor.HttpContext;
        context?.Response.Cookies.Delete("AuthToken");
        return Task.CompletedTask;
    }
}