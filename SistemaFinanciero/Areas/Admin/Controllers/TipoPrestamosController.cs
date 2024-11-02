using Microsoft.AspNetCore.Mvc;
using SistemaFinanciero.AccesoDatos.Repositorio.IRepositorio;
using SistemaFinanciero.Modelo;

namespace SistemaFinanciero.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TipoPrestamosController : Controller
    {
        private readonly IUnidadTrabajo unidadTrabajo;

        public TipoPrestamosController(IUnidadTrabajo unidadTrabajo)
        {
            this.unidadTrabajo = unidadTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(TipoPrestamo tipoPrestamo)
        {
            if (ModelState.IsValid)
            {
                await unidadTrabajo.TipoPrestamo.Agregar(tipoPrestamo);
                await unidadTrabajo.Guardar();
                TempData["success"] = "Tipo Prestamo Creado";
                return RedirectToAction("Index");
            }
            return View(tipoPrestamo);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var obj = await unidadTrabajo.TipoPrestamo.Get(id);

            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(TipoPrestamo tipoPrestamo)
        {
            if (ModelState.IsValid)
            {
                await unidadTrabajo.TipoPrestamo.Actualizar(tipoPrestamo);
                await unidadTrabajo.Guardar();
                TempData["success"] = "Tipo Prestamo Actualizado";
                return RedirectToAction("Index");
            }
            return View(tipoPrestamo);
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodo()
        {
            return Json(new { data = await unidadTrabajo.TipoPrestamo.GetAll() });
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            var obj = await unidadTrabajo.TipoPrestamo.Get(id);

            if (obj is null)
            {
                return Json(new { success = false, message = "Error al eliminar" });
            }

            unidadTrabajo.TipoPrestamo.Remover(obj);
            await unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Eliminado" });
        }
        #endregion
    }
}
