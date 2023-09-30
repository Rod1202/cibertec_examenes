using ExamT1_201914968.Database.EstudiantesContext;
using ExamT1_201914968.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ExamT1_201914968.Controllers
{
    public class HomeController : Controller
    {
        private readonly EstudiantesContext _estudiantescontext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, EstudiantesContext estudiantesContext)
        {
            _logger = logger;
            _estudiantescontext = estudiantesContext;
        }

        public IActionResult Index()
        {
            return View();
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
