using Curso_Linea_Consumo_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Curso_Linea_Consumo_API.Servicios;

namespace Curso_Linea_Consumo_API.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiciosAPI _servicioApi;

        public HomeController(IServiciosAPI servicioApi)
        {
            _servicioApi = servicioApi;
        }

        public async Task<IActionResult> Index()
        {
            List<Curso> lista = await _servicioApi.Listado();
            return View(lista);
        }

        public async Task<IActionResult> Curso(int idCurso)
        { 
            Curso curso = new Curso();
            ViewBag.Accion = "Agregar nuevo curso";
            if (idCurso != 0)
            {
                curso = await _servicioApi.ObtenerCurso(idCurso);
                ViewBag.Accion = "Editar curso";
            }
            return View(curso);

        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Curso curso){
            bool respuesta ;
            if(curso.CursoId == 0)
            {
                respuesta = await _servicioApi.Agregar(curso);
            }
            else
            {
                respuesta = await _servicioApi.Editar(curso);
            }
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NoContent();
            }
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
