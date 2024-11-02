using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanciero.Modelo
{
    public class TipoPrestamo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        [Display(Name = "Nombre de Prestamo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Tasa intereses es requerido")]
        [Display(Name = "Tasa Interes Anual")]
        public decimal TasaInteresAnual { get; set; } // en porcentaje

        [Required(ErrorMessage = "Plazo maximo es requerido")]
        [Display(Name = "Plazo Maximo Meses")]
        public int PlazoMaximoMeses { get; set; }

        [Required(ErrorMessage = "Monto maximo es requerido")]
        [Display(Name = "Monto Maximo")]
        public decimal MontoMaximo { get; set; }

        [Required(ErrorMessage = "Porcentaje refinanciamiento es requerido")]
        [Display(Name = "Porcentaje Refinanciamiento")]
        public decimal PorcentajeRefinanciamiento { get; set; } // en porcentaje
    }
}
