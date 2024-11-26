using System.ComponentModel.DataAnnotations;

namespace Web_API_Jueves.DAL.Entities
{
    public class State : AuditBase
    {
        [Display(Name = "Estado/Departamento")] // Para identificar el nombre más fácil
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")] // Longitud máx
        [Required(ErrorMessage = "Es campo {0} es obligatorio")] // Campo obligatorio
        public string Name { get; set; }

        [Display(Name = "País")]
        public Country? Country { get; set; }

        //FK
        [Display(Name = "Id País")]
        public Guid CountryId { get; set; }


    }
}
