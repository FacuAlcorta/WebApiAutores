using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using WebApiAutores.Validaciones;

namespace WebApiAutores.DTOs
{
    public class LibroCreacionDTO
    {
        [PrimerLetraMayuscula]
        [StringLength(maximumLength: 255)]
        public string Titulo { get; set; }
    }
}
