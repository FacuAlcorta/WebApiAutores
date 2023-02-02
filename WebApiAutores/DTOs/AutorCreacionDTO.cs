using Duende.IdentityServer.Models;
using System.ComponentModel.DataAnnotations;
using WebApiAutores.Validaciones;

namespace WebApiAutores.DTOs
{
    public class AutorCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 25, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        [PrimerLetraMayuscula]
        public string Nombre { get; set; }
    }
}
