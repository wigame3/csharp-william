using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Empleados.Models.EmpleadosViewModels
{    
    public class Empleado
    {
     
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tipo Documento")]
        public string Tipo_documento { get; set; }

        [Required]
        [Display(Name = "# Documento")]
        [StringLength(20, ErrorMessage = "El {0} debe ser mínimo de {2} y un máximo de {1} caracteres", MinimumLength = 3)]
        public string Documento { get; set; }

        [Required]
        [Display(Name = "Nombres")]
        [StringLength(100, ErrorMessage = "El {0} debe ser mínimo de {2} y un máximo de {1} caracteres", MinimumLength = 3)]
        public string Nombres { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        [StringLength(100, ErrorMessage = "El {0} debe ser mínimo de {2} y un máximo de {1} caracteres", MinimumLength = 3)]
        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "Sub Área")]
        public int Id_Sub_Area { get; set; }

        [ForeignKey("Id_Sub_Area")]
        [Display(Name = "Sub Área", AutoGenerateField = false)]
        public virtual Empleados.Models.SubAreasViewModels.SubAreas SubArea { get; set; }


    }
}
