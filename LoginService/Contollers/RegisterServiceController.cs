﻿using antapp.Shared.Auth.Dtos;
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

    [HttpGet]
    //[Route("[Controller]/[Action]")]
    public IActionResult Index()
    {
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    //[Route("[Controller]/[Action]")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
    {
        await _authenticationService.Register(request);
        return Ok();
    }
}
