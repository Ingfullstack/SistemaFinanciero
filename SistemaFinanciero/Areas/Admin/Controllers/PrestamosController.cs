using Microsoft.AspNetCore.Mvc;
using SistemaFinanciero.AccesoDatos.Repositorio.IRepositorio;
using SistemaFinanciero.Modelo;
using SistemaFinanciero.Modelo.ViewsModels;

namespace SistemaFinanciero.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PrestamosController : Controller
    {
        private readonly IUnidadTrabajo unidadTrabajo;

        public PrestamosController(IUnidadTrabajo unidadTrabajo)
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
            PrestamoVM prestamoVM = new PrestamoVM()
            {
                Prestamo = new Prestamo(),
                ListaCliente = unidadTrabajo.Cliente.ListaCliente(),
                ListaTipoPrestamo = unidadTrabajo.TipoPrestamo.ListaTipoPrestamos()
            };
            return View(prestamoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(PrestamoVM prestamoVM)
        {
            if (ModelState.IsValid)
            {
                await unidadTrabajo.Prestamo.Agregar(prestamoVM.Prestamo);
                await unidadTrabajo.Guardar();
                TempData["success"] = "Prestamo Creado";
                return RedirectToAction("Index", "Prestamos");
            }
            prestamoVM.ListaCliente = unidadTrabajo.Cliente.ListaCliente();
            prestamoVM.ListaTipoPrestamo = unidadTrabajo.TipoPrestamo.ListaTipoPrestamos();
            return View(prestamoVM);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            PrestamoVM prestamoVM = new PrestamoVM()
            {
                Prestamo = new Prestamo(),
                ListaCliente = unidadTrabajo.Cliente.ListaCliente(),
                ListaTipoPrestamo = unidadTrabajo.TipoPrestamo.ListaTipoPrestamos()
            };

            if (id is null)
            {
                return NotFound();
            }

            prestamoVM.Prestamo = await unidadTrabajo.Prestamo.Get(id.GetValueOrDefault());
            return View(prestamoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(PrestamoVM prestamoVM)
        {
            if (ModelState.IsValid)
            {
                await unidadTrabajo.Prestamo.Actualizar(prestamoVM.Prestamo);
                await unidadTrabajo.Guardar();
                TempData["success"] = "Prestamo Actualizado";
                return RedirectToAction("Index", "Prestamos");
            }
            prestamoVM.ListaCliente = unidadTrabajo.Cliente.ListaCliente();
            prestamoVM.ListaTipoPrestamo = unidadTrabajo.TipoPrestamo.ListaTipoPrestamos();
            return View(prestamoVM);
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodo()
        {
            return Json(new { data = await unidadTrabajo.Prestamo.GetAll(incluirPropiedades:"Cliente,TipoPrestamo") });
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int? id)
        {
            var obj = await unidadTrabajo.Prestamo.Get(id.GetValueOrDefault());

            if (obj is null)
            {
                return Json(new { success = false, message = "Error al eliminar" });
            }

            unidadTrabajo.Prestamo.Remover(obj);
            await unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Prestamo Eliminado" });
        }
        #endregion
    }
}
