using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaFinanciero.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanciero.AccesoDatos.Repositorio.IRepositorio
{
    public interface ITipoPrestamoRepositorio : IRepositorio<TipoPrestamo>
    {
        Task Actualizar(TipoPrestamo tipoPrestamo);
        IEnumerable<SelectListItem> ListaTipoPrestamos();
        Task<bool> Existe(string nombre);
    }
}
