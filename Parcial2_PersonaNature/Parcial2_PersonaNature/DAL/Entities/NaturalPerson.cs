using System.ComponentModel.DataAnnotations;

namespace Parcial2_PersonaNature.DAL.Entities
{
    public class NaturalPerson : Entity


    {
        #region
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Nombre Completo")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Ingrese el Año de Nacimiento")]
        public int BirthYear { get; set; }

        
        public int Age { get; set; }


        #endregion

    }
}
