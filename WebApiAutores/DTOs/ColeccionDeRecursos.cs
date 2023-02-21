namespace WebApiAutores.DTOs
{
    public class ColeccionDeRecursos<T> : RecursoDTO where T : RecursoDTO
    {
        public List<T> Valores { get; set; }
    }
}
