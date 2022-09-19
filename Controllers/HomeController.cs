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
    public IActionResult PreguntaInicial(string Nombre)
    {
        juegoQQSM.IniciarJuego(Nombre);
        ViewBag.Pregunta = juegoQQSM.ObtenerProximaPregunta();
        ViewBag.Respuesta = juegoQQSM.ObtenerRespuestas();
        ViewBag.Pozo = juegoQQSM.ListarPozo();
        return View("Pregunta");

    }
    public IActionResult Pregunta(string Nombre)
    {
        ViewBag.Pozo = juegoQQSM.ListarPozo();
        ViewBag.Pregunta = juegoQQSM.ObtenerProximaPregunta();
        ViewBag.Respuesta = juegoQQSM.ObtenerRespuestas();
        return View();
    }
    public IActionResult PreguntaRespondida(char opcion, char opcionComodin)
    {
        var acierto = juegoQQSM.respuestaUsuario(opcion, opcionComodin);
        ViewBag.Pozo = juegoQQSM.ListarPozo();
        var id = juegoQQSM.GetIDPreguntaActual();
        if (acierto == true && id != 20)
        {
            ViewBag.PozoAcumulado = juegoQQSM.DevolverImportePozoActual(true);

            return View("RespuestapreguntaOk");
        }
        else
        {
            ViewBag.PozoAcumulado = juegoQQSM.DevolverImportePozoActual(false);
            return View("PantallaFindelJuego");
        }
    }
    public IActionResult PantallaFindelJuego()
    {
        ViewBag.PozoAcumulado = juegoQQSM.DevolverImportePozoActualRetirado();
        return View();
    }
    public IActionResult DivisionDeOpciones()
    {
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
