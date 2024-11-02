using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanciero.Modelo
{
    public class Prestamo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Cliente es requerido")]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "Tipo prestamo es requerido")]
        public int TipoPrestamoId { get; set; }

        [ForeignKey("TipoPrestamoId")]
        public TipoPrestamo TipoPrestamo { get; set; }

        [Required(ErrorMessage = "Monto prestado es requerido")]
        [Display(Name = "Monto Prestado")]
        public decimal MontoPrestado { get; set; }

        [Required(ErrorMessage = "Plazo es requerido")]
        [Display(Name = "Plazo en Meses")]
        public int PlazoEnMeses { get; set; }

        [Required(ErrorMessage = "Interes compuesto es requerido")]
        [Display(Name = "Interes Compuesto")]
        public decimal InteresCompuesto { get; set; } // Calculado basado en la tasa de interés
    }
}
