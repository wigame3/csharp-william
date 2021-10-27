using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Documento { get; set; }

        [Required]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "Área")]
        public string Area { get; set; }

        [Required]
        [Display(Name = "Sub Área")]
        public string Sub_area { get; set; }
        
    }
}
