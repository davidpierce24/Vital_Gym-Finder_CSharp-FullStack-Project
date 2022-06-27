using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Vital.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Vital.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly IConfiguration _config;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context, IConfiguration config)
    {
        _logger = logger;
        _context = context;
        _config = config;
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
