using System.ComponentModel.DataAnnotations;

namespace Web_API_Jueves.DAL.Entities
{
    public class AuditBase
    {
        [Key] //PK
        [Required] //Siginifica que este campo es Obligatorio
        public virtual Guid Id { get; set; }  //Esta será la el PK de todas las tablas

        public virtual DateTime? CreatedDate { get; set; }  // Para guardar todo registro con nuevo date

        public virtual DateTime? ModifiedDate { get; set; } // Para guardar todo registro que se modificó con su date
    }
}
