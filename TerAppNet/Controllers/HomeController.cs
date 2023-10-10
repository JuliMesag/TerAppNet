using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TerAppNet.Models;

namespace TerAppNet.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _context;

        public HomeController(ILogger<HomeController> logger, MyDbContext? context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Pacientes != null ?
                          View(await _context.Pacientes.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.Pacientes'  is null.");
            //return View();
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