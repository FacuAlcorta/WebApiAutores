using System.ComponentModel.DataAnnotations;
using WebApiAutores.Validaciones;

namespace WebApiAutores.DTOs
{
    public class LibroPatchDTO
    {
        [Required]
        [PrimerLetraMayuscula]
        [StringLength(maximumLength: 255)]
        public string Titulo { get; set; }
        public DateTime FechaPublicacion { get; set; }
    }
}
