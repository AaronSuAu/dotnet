using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shortLinkApp.Models;
using shortLinkApp.DTO;
using BitlyAPI;
using shortLinkApp.Services;

namespace shortLinkApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShortenURLService _shortenURLService;

        public HomeController(ILogger<HomeController> logger, IShortenURLService shortenURLService)
        {
            _logger = logger;
            _shortenURLService = shortenURLService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Shorten(LinkForm model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["error"] = "URL is not valid, must start with http, https...";
                return View("~/Views/Home/index.cshtml");
            }

            ViewData["url"] = await _shortenURLService.shortenUrl(model.url);
            return View("~/Views/Home/index.cshtml");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
