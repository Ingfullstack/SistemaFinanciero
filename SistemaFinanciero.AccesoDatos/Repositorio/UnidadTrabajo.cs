using SistemaFinanciero.AccesoDatos.Data;
using SistemaFinanciero.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanciero.AccesoDatos.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext dbContext;

        public IClienteRepositorio Cliente { get; private set; }
        public ITipoPrestamoRepositorio TipoPrestamo { get; private set; }
        public IPrestamoRepositorio Prestamo { get; private set; }

        public UnidadTrabajo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            Cliente = new ClienteRepositorio(dbContext);
            TipoPrestamo = new TipoPrestamoRepositorio(dbContext);
            Prestamo = new PrestamoRepositorio(dbContext);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public async Task Guardar()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
