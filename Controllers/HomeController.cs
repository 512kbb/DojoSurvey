using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurvey.Models;

namespace DojoSurvey.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("process")]
    public RedirectToActionResult Process(string Name, int Location, int FavoriteLanguage, string Comment)
    {
        string selectedLocation = "";
        string selectedLanguage = "";
        if (Location == 0)
        {
            selectedLocation = "San Jose";
        } else 
        {
            selectedLocation = "Santiago";
        }

        if (FavoriteLanguage == 0)
        {
            selectedLanguage = "C#";
        } else if (FavoriteLanguage == 1)
        {
            selectedLanguage = "Javascript";
        } else
        {
            selectedLanguage =  "Python";
        }

        return RedirectToAction("Result", new { 
            name = Name,
            location = selectedLocation,
            favoriteLanguage = selectedLanguage,
            comment = Comment
        });
    }

    public IActionResult Result(string name, string location, string favoriteLanguage, string comment)
    {
        Console.WriteLine(name);
        ViewBag.Name = name;
        ViewBag.Location = location;
        ViewBag.favoriteLanguage = favoriteLanguage;
        ViewBag.Comment = comment;
        return View("Result");
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
