using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Empleados.Models.AreasViewModels
{
    public class Areas
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        [StringLength(150, ErrorMessage = "El {0} debe ser mínimo de {2} y un máximo de {1} caracteres", MinimumLength = 3)]
        public string Descripcion { get; set; }
    }
}
