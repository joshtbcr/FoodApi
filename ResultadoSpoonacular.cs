using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FoodApi
{
    public class ResultadoSpoonacular
    {
        [JsonPropertyName("results")]
        //public string Productos { get; set; }
        public List<IdProducto> IdProductos { get; set; }
    }

    public class IdProducto
    {
        [JsonPropertyName("id")]
        //public string Productos { get; set; }
        public int Id { get; set; }
    }
}
