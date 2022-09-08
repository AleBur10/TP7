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
    public IActionResult Pregunta(string Nombre)
    {
        juegoQQSM.IniciarJuego(Nombre);
        ViewBag.Pregunta = juegoQQSM.ObtenerProximaPregunta();
        ViewBag.Respuestas = juegoQQSM.ObtenerRespuestas();
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
    public IActionResult DivisionDeOpciones()
    {
        return View();
    }
  //  [HttpGet]
    /*public IActionResult PreguntaRespondida(char Opcion1, char Opcion2, char Opcion3, char Opcion4)
    {
        ViewBag.Opciones = juegoQQSM.ObtenerRespuestas(Opcion1, Opcion2, Opcion3, Opcion4);
        if(Opcion1 != null){
           return View("RespuestapreguntaOK");
        }
        else
        {
           return View("PantallaFindelJuego");
        }
        if(Opcion2 != null){
           return View("RespuestapreguntaOK");
        }
        else
        {
           return View("PantallaFindelJuego");
        }
        if(Opcion3 != null){
           return View("RespuestapreguntaOK");
        }
        else
        {
           return View("PantallaFindelJuego");
        }
        if(Opcion4 != null){
           return View("RespuestapreguntaOK");
        }
        else
        {
           return View("PantallaFindelJuego");
        }
    }*/
    // public IActionResult FinDelJuego()
    // {
    //     ViewBag.DetalleJugador = juegoQQSM.verInfoJugador(IdJugador);
    //     return View();
    // }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
