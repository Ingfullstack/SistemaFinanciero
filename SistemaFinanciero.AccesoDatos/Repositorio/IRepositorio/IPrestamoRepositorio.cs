using SistemaFinanciero.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanciero.AccesoDatos.Repositorio.IRepositorio
{
    public interface IPrestamoRepositorio : IRepositorio<Prestamo>
    {
        Task Actualizar(Prestamo prestamo);
    }
}
