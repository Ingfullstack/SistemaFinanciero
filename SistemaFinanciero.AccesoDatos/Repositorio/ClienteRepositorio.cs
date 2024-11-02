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
    public class ClienteRepositorio : Repositorio<Cliente>, IClienteRepositorio
    {
        private readonly ApplicationDbContext dbContext;

        public ClienteRepositorio(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Actualizar(Cliente cliente)
        {
            var obj = await dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == cliente.Id);

            if (obj != null)
            {
                obj.Nombre = cliente.Nombre;
                obj.Apellido = cliente.Apellido;
                obj.Telefono = cliente.Telefono;
                obj.Email = cliente.Email;
                obj.Cedula = cliente.Cedula;
            }
        }

        public async Task<bool> Existe(string nombre)
        {
            return await dbContext.Clientes.AnyAsync(x => x.Nombre == nombre);
        }

        public IEnumerable<SelectListItem> ListaCliente()
        {
            return dbContext.Clientes.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Id.ToString()
            });
        }
    }
}
