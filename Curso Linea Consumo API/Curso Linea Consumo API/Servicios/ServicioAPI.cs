using Curso_Linea_Consumo_API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Curso_Linea_Consumo_API.Servicios
{
    public class ServicioAPI : IServiciosAPI
    {
        private static string _baseUrl;

        public ServicioAPI()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task<bool> Agregar(Curso curso)
        {
            var cursoCreado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(curso), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("/curso/agregar", content);
            if(response.IsSuccessStatusCode)
            {
                cursoCreado = true;
            }
            return cursoCreado;
        }

        public async Task<bool> Editar(Curso curso)
        {
            var cursoEditado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(curso), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"/curso/editar?id={curso.CursoId}", content);
            if (response.IsSuccessStatusCode)
            {
                cursoEditado = true;
            }
            return cursoEditado;
        }

        public async Task<List<Curso>> Listado()
        {
            List<Curso> listado = new List<Curso>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync("/curso/listado");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<dynamic>(json_respuesta);

                // Convertir el resultado a una lista de Curso
                listado = ((JArray)resultado.cursos).ToObject<List<Curso>>();
            }
            return listado;
        }

        public async Task<Curso> ObtenerCurso(int idCurso)
        {
            Curso curso = null;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync($"/curso/obtener?idCurso={idCurso}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeAnonymousType(json_respuesta, new { curso = new Curso(), message = "" });

                // El curso se encuentra en resultado.curso`
                curso = resultado.curso;
            }
            return curso;
        }

    }
}
