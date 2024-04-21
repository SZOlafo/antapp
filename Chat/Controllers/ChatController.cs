using antapp.Chat.Builders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antapp.Chat.Controllers
{
    public class ChatController : Controller
    {
        private readonly IChatViewModelBuilder _builder;

        public ChatController(IChatViewModelBuilder builder)
        {
            _builder = builder;
        }

        public async Task<IActionResult> Index([FromQuery] int chatId)
        {
            var viewModel = await _builder.Build(chatId);
            return View(viewModel);
        }
    }
}
