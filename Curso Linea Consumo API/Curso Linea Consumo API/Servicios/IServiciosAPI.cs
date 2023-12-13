using Curso_Linea_Consumo_API.Models;

namespace Curso_Linea_Consumo_API.Servicios
{
    public interface IServiciosAPI
    {
        Task<bool> Agregar(Curso curso);
        Task<List<Curso>> Listado();
        Task<List<Profesor>> ObtenerProfesores();
        Task<Profesor> ObtenerProfesor(int idProfesor);
        Task<bool> Editar(Curso curso);
        Task<Curso> ObtenerCurso(int idCurso);
        Task<bool> AsignarProfesor(int idCurso, Profesor profesor);

    }
}
