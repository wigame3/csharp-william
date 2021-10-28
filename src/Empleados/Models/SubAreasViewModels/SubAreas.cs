using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Empleados.Models.SubAreasViewModels
{
    public class SubAreas
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        [StringLength(150, ErrorMessage = "El {0} debe ser mínimo de {2} y un máximo de {1} caracteres", MinimumLength = 3)]
        public string Descripcion { get; set; }

        [ForeignKey("Id")]
        [Display(Name = "Área", AutoGenerateField = false)]
        public virtual Empleados.Models.AreasViewModels.Areas Area { get; set; }
    }
}
