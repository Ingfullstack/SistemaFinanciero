using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class TipoPrestamoRepositorio : Repositorio<TipoPrestamo>, ITipoPrestamoRepositorio
    {
        private readonly ApplicationDbContext dbContext;

        public TipoPrestamoRepositorio(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Actualizar(TipoPrestamo tipoPrestamo)
        {
            var obj = await dbContext.TipoPrestamos.FirstOrDefaultAsync(x => x.Id == tipoPrestamo.Id);

            if (obj != null)
            {
                obj.Nombre = tipoPrestamo.Nombre;
                obj.TasaInteresAnual = tipoPrestamo.TasaInteresAnual;
                obj.PlazoMaximoMeses = tipoPrestamo.PlazoMaximoMeses;
                obj.MontoMaximo = tipoPrestamo.MontoMaximo;
                obj.PorcentajeRefinanciamiento = tipoPrestamo.PorcentajeRefinanciamiento;
            }
        }

        public async Task<bool> Existe(string nombre)
        {
            return await dbContext.TipoPrestamos.AnyAsync(x => x.Nombre == nombre);
        }

        public IEnumerable<SelectListItem> ListaTipoPrestamos()
        {
            return dbContext.TipoPrestamos.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Id.ToString()
            });
        }
    }
}
