using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanciero.Modelo.ViewsModels
{
    public class PrestamoVM
    {
        public Prestamo Prestamo { get; set; }
        public IEnumerable<SelectListItem> ListaCliente { get; set; }
        public IEnumerable<SelectListItem> ListaTipoPrestamo { get; set; }
    }
}
