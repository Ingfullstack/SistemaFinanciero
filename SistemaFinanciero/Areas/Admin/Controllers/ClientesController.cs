using Microsoft.AspNetCore.Mvc;
using SistemaFinanciero.AccesoDatos.Repositorio.IRepositorio;
using SistemaFinanciero.Modelo;

namespace SistemaFinanciero.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClientesController : Controller
    {
        private readonly IUnidadTrabajo unidadTrabajo;

        public ClientesController(IUnidadTrabajo unidadTrabajo)
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
        public async Task<IActionResult> Crear(Cliente cliente)
        {
            if (await unidadTrabajo.Cliente.Existe(cliente.Nombre.Trim()))
            {
                TempData["error"] = "Cliente ya existe";
                return View();
            }

            if (ModelState.IsValid)
            {
                await unidadTrabajo.Cliente.Agregar(cliente);
                await unidadTrabajo.Guardar();
                TempData["success"] = "Cliente Agregado";
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var obj = await unidadTrabajo.Cliente.Get(id);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                await unidadTrabajo.Cliente.Actualizar(cliente);
                await unidadTrabajo.Guardar();
                TempData["success"] = "Cliente Actualizado";
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodo()
        {
            return Json(new { data = await unidadTrabajo.Cliente.GetAll(orderBy: x => x.OrderByDescending(x => x.Id)) });
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            var obj = await unidadTrabajo.Cliente.Get(id);

            if (obj is null)
            {
                return Json(new { success = false, message = "Error al eliminar" });
            }

            unidadTrabajo.Cliente.Remover(obj);
            await unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Eliminado" });
        }
        #endregion
    }
}
