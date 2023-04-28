using Newtonsoft.Json;
using RestSharp;
namespace HELPERS
{
    public class Certificador_FEL
    {
        public static ResponseNIT Get_Datos_Contribuyente(string nit = "")
        {
            RestClient consumoNit = new RestClient("https://consultareceptores.feel.com.gt/rest/action");
            RequestNIT itemNit = new RequestNIT
            {
                emisor_codigo = "74974327PRO",
                emisor_clave = "2E5BC7B58667334131F39B71E9640CC6",
                nit_consulta = nit
            };
            var peticionNit = new RestRequest();
            peticionNit.Method = Method.Post;
            peticionNit.AddJsonBody(itemNit);
            var responseNit = consumoNit.Execute(peticionNit);
            ResponseNIT DATOS_CONTRIBUYENTE = JsonConvert.DeserializeObject<ResponseNIT>(responseNit.Content);
            return DATOS_CONTRIBUYENTE;
        }
        public class ResponseNIT
        {
            public string nit { get; set; }
            public string nombre { get; set; }
            public string mensaje { get; set; }
        }
        public class RequestNIT
        {
            public string emisor_codigo { get; set; }
            public string emisor_clave { get; set; }
            public string nit_consulta { get; set; }
        }
    }
}