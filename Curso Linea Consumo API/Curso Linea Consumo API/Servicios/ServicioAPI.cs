using Curso_Linea_Consumo_API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

    }
}
