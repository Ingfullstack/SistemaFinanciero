using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanciero.AccesoDatos.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        IClienteRepositorio Cliente {  get; }
        ITipoPrestamoRepositorio TipoPrestamo {  get; }
        IPrestamoRepositorio Prestamo {  get; }
        Task Guardar();
    }
}
