using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaFinanciero.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanciero.AccesoDatos.Repositorio.IRepositorio
{
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {
        Task Actualizar(Cliente cliente);
        IEnumerable<SelectListItem> ListaCliente();
        Task<bool> Existe(string nombre);
    }
}
