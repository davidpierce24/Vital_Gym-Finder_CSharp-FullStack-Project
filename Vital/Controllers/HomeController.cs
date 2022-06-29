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

// Route to render welcome page where user can select it they are a gym owner or a gym goer
    public IActionResult Index()
    {
        return View();
    }

// Route to display the page for an owner to login or register------------
    [HttpGet("owner/loginreg")]
    public IActionResult OwnerLoginReg()
    {
        return View();
    }


// Route to display the page for a user to login or register-------------
    [HttpGet("user/loginreg")]
    public IActionResult UserLoginReg()
    {
        return View();
    }


// Route to display the main home page----------------------------------------
[HttpGet("home")]
public IActionResult Home()
{
    return View();
}


// Route to register a user ------------------------------------------
    [HttpPost("user/register")]
    public IActionResult RegisterUser(User newUser)
    {
        if(ModelState.IsValid){
            // validation for unique email
            if(_context.Users.Any(d => d.Email == newUser.Email)){
                // user email already in db
                ModelState.AddModelError("Email", "Email is already in use!");
                return View("Index");
            }
            // validation for unique username
            if(_context.Users.Any(d => d.Username == newUser.Username)){
                // username already in db
                ModelState.AddModelError("Username", "Username is already in use!");
                return View("Index");
            }
            // password hasing
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("user", newUser.UserId);
            return RedirectToAction("UserDashboard");
        } else {
            return View("Index");
        }
    }

// route to process a user login -------------------------------------------
    [HttpPost("user/login")]
    public IActionResult LoginUser(LogUser loginUser)
    {
        if(ModelState.IsValid){
            // check to see if email is in db
            User userInDb = _context.Users.FirstOrDefault(d => d.Email == loginUser.LogEmail);
            if(userInDb == null){
                // no email in database
                ModelState.AddModelError("LogEmail", "Invalid login attempt");
                return View("Index");
            }
            // check for hashed password
            PasswordHasher<LogUser> Hasher = new PasswordHasher<LogUser>();
            var result = Hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.LogPassword);
            // if password was incorrect
            if(result == 0){
                ModelState.AddModelError("LogEmail", "Invalid login attempt");
                return View("Index");
            }
            HttpContext.Session.SetInt32("user", userInDb.UserId);
            return RedirectToAction("UserDashboard");
        } else {
            return View("Index");
        }
    }

// route to process an owner registration -------------------------------------
    [HttpPost("owner/register")]
    public IActionResult RegisterOwner(Owner newOwner)
    {
        if(ModelState.IsValid){
            // validation for unique email
            if(_context.Owners.Any(d => d.Email == newOwner.Email)){
                // user email already in db
                ModelState.AddModelError("Email", "Email is already in use!");
                return View("Index");
            }
            // validation for unique username
            if(_context.Owners.Any(d => d.Username == newOwner.Username)){
                // username already in db
                ModelState.AddModelError("Username", "Username is already in use!");
                return View("Index");
            }
            // password hasing
            PasswordHasher<Owner> Hasher = new PasswordHasher<Owner>();
            newOwner.Password = Hasher.HashPassword(newOwner, newOwner.Password);
            _context.Add(newOwner);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("owner", newOwner.OwnerId);
            return RedirectToAction("OwnerDashboard");
        } else {
            return View("Index");
        }
    }

// route to process an owner login -------------------------------------------
    [HttpPost("owner/login")]
    public IActionResult LoginOwner(LogOwner loginOwner)
    {
        if(ModelState.IsValid){
            // check to see if email is in db
            Owner ownerInDb = _context.Owners.FirstOrDefault(d => d.Email == loginOwner.LogEmail);
            if(ownerInDb == null){
                // no email in database
                ModelState.AddModelError("LogEmail", "Invalid login attempt");
                return View("Index");
            }
            // check for hashed password
            PasswordHasher<LogOwner> Hasher = new PasswordHasher<LogOwner>();
            var result = Hasher.VerifyHashedPassword(loginOwner, ownerInDb.Password, loginOwner.LogPassword);
            // if password was incorrect
            if(result == 0){
                ModelState.AddModelError("LogEmail", "Invalid login attempt");
                return View("Index");
            }
            HttpContext.Session.SetInt32("owner", ownerInDb.OwnerId);
            return RedirectToAction("OwnerDashboard");
        } else {
            return View("Index");
        }
    }

// Route to display owner dashboard -----------------------------------------
    [HttpGet("owner/dashboard")]
    public IActionResult OwnerDashboard()
    {   
        ViewBag.Owner = _context.Owners.Include(d => d.GymsOwned).FirstOrDefault(d => d.OwnerId == HttpContext.Session.GetInt32("owner"));
        return View();
    }

// Route to process creating a gym -----------------------------------------
    [HttpPost("gym/process")]
    public IActionResult ProcessGym(Gym newGym)
    {
        if(ModelState.IsValid){
            _context.Add(newGym);
            _context.SaveChanges();
            return RedirectToAction("Gym");
        } else {
            ViewBag.Owner = _context.Owners.Include(d => d.GymsOwned).FirstOrDefault(d => d.OwnerId == HttpContext.Session.GetInt32("owner"));
            return View ("OwnerDashboard");
        }
    }


// Route to take owner to add a gym page -----------------------------------
    [HttpGet("gym")]
    public IActionResult Gym()
    {
        return View();
    }


// Route to display user dashboard ------------------------------------------
    [HttpGet("user/dashboard")]
    public IActionResult UserDashboard()
    {
        return View();
    }





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
