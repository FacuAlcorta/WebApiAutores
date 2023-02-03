using System.ComponentModel.DataAnnotations;
using WebApiAutores.Validaciones;

namespace WebApiAutores.Entidades
{
    public class Libro
    {
        public int Id { get; set; }
        [Required]
        [PrimerLetraMayuscula]
        [StringLength(maximumLength: 255)]  
        public string Titulo { get; set; }
        public List<Comentario> Comentarios { get; set; }
    }
}
