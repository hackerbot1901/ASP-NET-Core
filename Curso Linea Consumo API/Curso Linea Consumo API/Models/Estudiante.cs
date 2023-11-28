namespace Curso_Linea_Consumo_API.Models
{
    public class Estudiante
    {
        public int EstudianteId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public int? Edad { get; set; }

        public int? CursoId { get; set; }

        public virtual Curso? Curso { get; set; }
    }
}