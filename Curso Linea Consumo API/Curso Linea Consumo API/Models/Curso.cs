namespace Curso_Linea_Consumo_API.Models
{
    public class Curso
    {
        public int CursoId { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public int? DuracionHoras { get; set; }

        public int? ProfesorId { get; set; }

        public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

        public virtual Profesor? Profesor { get; set; }

    }
}
