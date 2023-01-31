using System.ComponentModel.DataAnnotations;

namespace WebApiAutores.Entidades
{
    public class Autor: IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [StringLength(maximumLength: 25, ErrorMessage ="El campo {0} no debe superar {1} carácteres")]
        public string Name { get; set; }
        public List<Libro> Libros { get; set; }
        public int Menor { get; set; }
        public int Mayor { get; set; }

        //     ------ Emula la validacion por atributo PrimeraLetraMayuscula
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                var primeraLetra = Name[0].ToString();

                if (primeraLetra != primeraLetra.ToUpper())
                {
                    yield return new ValidationResult("La primer letra debe ser mayúscula",
                        new string[] { nameof(Name) });
                }
            }
        //     ----- Valida  dos propiedades de la misma clase

            if (Menor > Mayor) {
                yield return new ValidationResult("El numero debe ser menor que el Mayor",
                    new string[] { nameof(Menor) });
            }
        }

        // [NotMapped] para campos no definidos previamente en la tabla.
        // [CreditCard] para validar Tarjeta de Credito.
        // [Url] para validar URL.
        // [Range] para validar rando numérico.

        //---------------------  Validacion personalizada  --------------------------------

        //     POR ATRIBUTO(clase aparte ValidationAttribute)     PrimeraLetraMayuscula
        //     POR MODELO(dentro de la clase IValidatableObject)        VALIDA SOLO SI SE CUMPLEN LAS VALIDACIONES DE ATRIBUTO PRIMER 



    }
}
