using Curso_Linea_Consumo_API.Models;

namespace Curso_Linea_Consumo_API.Servicios
{
    public interface IServiciosAPI
    {
        //Task<bool> Agregar(Curso curso);
        Task<List<Curso>> Listado();
        //Task<bool> Editar(Curso curso);
        //Task<bool> AsignarProfesor(Profesor profesor);
    }
}
