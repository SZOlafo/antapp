using antapp.Chat.Builders;
using antapp.Chat.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace antapp.Chat.Controllers
{
    public class ChatListController : Controller
    {
        private readonly IChatListViewModelBuilder _builder;
        private readonly IChatListService _chatListService;

        public ChatListController(IChatListViewModelBuilder builder, IChatListService chatListService)
        {
            _builder = builder;
            _chatListService = chatListService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _builder.Build();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GetChat()
        {
            await _chatListService.GetChat();
            return Json(new {success = true});
        }
    }
}
