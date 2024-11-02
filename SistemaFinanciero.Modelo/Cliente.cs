using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanciero.Modelo
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        [Display(Name = "Nombre del cliente")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido es requerido")]
        [Display(Name = "Apellido del cliente")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Telefono es requerido")]
        [Display(Name = "Telefono del cliente")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Email es requerido")]
        [Display(Name = "Email del cliente")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Cedula es requerida")]
        [Display(Name = "Cedula del cliente")]
        public string Cedula { get; set; }
    }
}
