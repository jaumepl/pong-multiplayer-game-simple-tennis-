using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using personal.Hubs;
using tennis1.Data;
using tennis1.Models;

namespace tennis1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly IHubContext<tennisHub> _hubContext;
        //private readonly Game game;

        public HomeController(ApplicationDbContext context, IHubContext<tennisHub> hubContext)
        {
            //_hubContext = hubContext;
            _context = context;
            Program.GlobalHubContext = hubContext;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        [Authorize]
        public IActionResult StartGame()
        {
            Program.SharedObj.inicialized = true;

            return RedirectToAction(nameof(Index));
        }
    }
}
