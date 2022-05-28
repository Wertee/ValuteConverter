using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using ValuteConverter.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ValuteConverter.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ValuteConverter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Converter _converter;
        public HomeController(ILogger<HomeController> logger, Converter converter)
        {
            _logger = logger;
            _converter = converter;
        }

        public IActionResult Index(CountValueModel model)
        {
            SelectList selectList = new SelectList(_converter.MoneyList.Select(x => x.CharCode).ToList());
            ViewBag.Valutes = selectList;
            return View(model);
        }

        public IActionResult CountValute(CountValueModel model)
        {
            model.Result = _converter.CountValute(model.FirstValuteName, model.FirstValuteCount, model.SecondValuteName);
            return RedirectToAction("Index", model);
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
