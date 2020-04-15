using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.Azure.Storage; // Namespace for CloudStorageAccount
using Microsoft.Azure.Storage.Queue; // Namespace for Queue storage types
using System.Threading.Tasks;//http client
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Collections.Generic;

namespace FoodApi
{
    public static class Main
    {
        private static HttpClient client = new HttpClient();
        private static ILogger logger;
        private static readonly string spoonacularUrl = "https://api.spoonacular.com";
        private static readonly string webApiUrl = "http://127.0.0.1:5000/buscar";
        //Monga's 4d554dce52ee4426a73c6bb62720f8a7 // Josh's 526b75f54f3e4e96b467622e7413e503
        private static readonly string foodApiKey = "4d554dce52ee4426a73c6bb62720f8a7";
        private static readonly string foodApiKeyArg = $"apiKey={foodApiKey}";
        private static double puntosBusqueda;//N/A
        private static double puntosDia;

        [FunctionName("Main")]
        public static async void Run([QueueTrigger("monjoshqueue", Connection = "AzureWebJobsStorage")]string mensaje, ILogger log)
        {
            logger = log;
            logger.LogInformation($"Procesando mensaje de queue: {mensaje}");

            string busquedaId = mensaje.Split("$")[0];
            string query = mensaje.Split("$")[1];




            var productos = await buscarProductosSpoonacular(query);


            await enviarRespuesta(busquedaId, productos);
        }

        private static async Task<List<Producto>> buscarProductosSpoonacular(string query)
        {
            client = prepararHttpClient(client);

            //Possible arguments = query, diet, intolerances, includeIngredients, excludeIngredients,

            string url = $"{spoonacularUrl}/recipes/complexSearch?{query}" +
                "&number=10" +
                $"&{foodApiKeyArg}";

            logger.LogInformation($"\tContactando Food Api con el URL: {url}");

            var streamTask = client.GetStreamAsync(url);
            var resultadoSpoonacular = await JsonSerializer.DeserializeAsync<ResultadoSpoonacular>(await streamTask);
            logger.LogInformation($"\t\tResultado Spoonacular {resultadoSpoonacular.IdProductos}");
            string ids = "";
            foreach (var idProducto in resultadoSpoonacular.IdProductos)
            {
                logger.LogInformation($"\t\t\t IdProducto:  {idProducto.Id}");
                ids += idProducto.Id+",";
            }




            client = prepararHttpClient(client);


            url = $"{spoonacularUrl}/recipes/informationBulk?" +
                $"ids={ids}" +
                "&number=10" +
                $"&{foodApiKeyArg}";


            logger.LogInformation($"\t\t\t URL para ids de producto:  {url}");
            streamTask = client.GetStreamAsync(url);
            var productos = await JsonSerializer.DeserializeAsync<List<Producto>>(await streamTask);

            logger.LogInformation($"\t\tProductos obtenidos:");

            foreach(var producto in productos)
            {
                logger.LogInformation($"\t\t\t{producto.Titulo}");
            }

            return productos;
        }

        private static HttpClient prepararHttpClient(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            return httpClient;
        }


        private static async Task<bool> enviarRespuesta(string busquedaId, List<Producto> productos)
        {
            logger.LogInformation($"\tEnviando productos a Web Api de la busqueda con ID {busquedaId}");
            client = prepararHttpClient(client);

            string args = "busquedaId=" + busquedaId;
                //"&puntosBusqueda= " + puntosBusqueda +
                //"&puntosDia= " + puntosDia;



            var response = client.PostAsJsonAsync(webApiUrl + "?" + args, productos);
            
            //response.Result;
            logger.LogInformation($"\t\tRespuesta de WebApi: \"{response.Result.Content.ReadAsStringAsync().Result}\"");

            return true;
        }



    }



}
