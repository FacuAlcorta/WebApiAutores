using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using WebApiAutores.Validaciones;

namespace WebApiAutores.DTOs
{
    public class LibroCreacionDTO
    {
        [Required]
        [PrimerLetraMayuscula]
        [StringLength(maximumLength: 255)]
        public string Titulo { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public List<int> AutoresIds { get; set; }
    }
}
