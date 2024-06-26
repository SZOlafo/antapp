﻿using antapp.Chat.Builders;
using antapp.Chat.Models;
using antapp.Chat.Services;
using antapp.Shared.Auth.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace antapp.Chat.Controllers;

[Authorize]
public class ChatController : Controller
{
    private readonly IChatViewModelBuilder _builder;
    private readonly IChatService _chatService;

    public ChatController(IChatViewModelBuilder builder, IChatService chatService)
    {
        _builder = builder;
        _chatService = chatService;
    }

    [HttpGet]
    //[Route("[Controller]/[Action]")]
    public async Task<IActionResult> Index([FromQuery] int chatId)
    {
        var viewModel = await _builder.Build(chatId);
        return View(viewModel);
    }

    [HttpPost]
    //[Route("[Controller]/[Action]")]
    public async Task<IActionResult> AddComment([FromBody] Comment request)
    {
        var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await _chatService.AddChatEntry(request, user);
        return Json(new { success = true });
    }
}
