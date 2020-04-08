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
        private static readonly string foodApiUrl = "https://api.spoonacular.com";
        private static readonly string foodApiKey = "526b75f54f3e4e96b467622e7413e503";

        [FunctionName("Main")]
        public static async void Run([QueueTrigger("monjoshqueue", Connection = "AzureWebJobsStorage")]string mensaje, ILogger log)
        {
            logger = log;
            logger.LogInformation($"Procesando mensaje de queue: {mensaje}");


            var productos = await contactarFoodApi(mensaje);
        }

        private static async Task<string> enviarRespuesta(string mensaje)
        {
            logger.LogInformation($"\tEnviando respuesta a Web Api: {mensaje}"); 




            return "";
        }

        private static async Task<List<Producto>> contactarFoodApi(string query)
        {
            logger.LogInformation($"\tContactando Food Api con el query: {query}"); 
            client = prepararHttpClient(client);


            var streamTask = client.GetStreamAsync($"{foodApiUrl}/food/menuItems/search?query={query}&apiKey={foodApiKey}&number=10");
            var menuProductos = await JsonSerializer.DeserializeAsync<MenuProductos>(await streamTask);
            var productos = menuProductos.Productos;

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


    }



}
