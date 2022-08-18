using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP7_Bursztyn_Witlis_Akselrad.Models;

namespace TP7_Bursztyn_Witlis_Akselrad.Controllers;

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

    public IActionResult Player()
    {
        return View();
    }
    public IActionResult Pregunta()
    {
        return View();
    }
    public IActionResult PantallaFindelJuego()
    {
        return View();
    }
    public IActionResult RespuestapreguntaOK()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
