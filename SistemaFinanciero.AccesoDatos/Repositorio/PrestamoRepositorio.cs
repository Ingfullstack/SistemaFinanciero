using Microsoft.EntityFrameworkCore;
using SistemaFinanciero.AccesoDatos.Data;
using SistemaFinanciero.AccesoDatos.Repositorio.IRepositorio;
using SistemaFinanciero.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanciero.AccesoDatos.Repositorio
{
    public class PrestamoRepositorio : Repositorio<Prestamo>, IPrestamoRepositorio
    {
        private readonly ApplicationDbContext dbContext;

        public PrestamoRepositorio(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Actualizar(Prestamo prestamo)
        {
            var obj = await dbContext.Prestamos.FirstOrDefaultAsync(x => x.Id == prestamo.Id);

            if (obj != null)
            {
                obj.ClienteId = prestamo.ClienteId;
                obj.TipoPrestamoId = prestamo.TipoPrestamoId;
                obj.MontoPrestado = prestamo.MontoPrestado;
                obj.PlazoEnMeses = prestamo.PlazoEnMeses;
                obj.InteresCompuesto = prestamo.InteresCompuesto;
            }
        }
    }
}
