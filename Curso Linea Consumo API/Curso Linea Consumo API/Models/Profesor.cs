namespace Curso_Linea_Consumo_API.Models
{
    public class Profesor
    {
        public int ProfesorId { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Especialidad { get; set; }

        public int? ExperienciaYears { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
    }
}
