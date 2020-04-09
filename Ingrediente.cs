using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;


namespace FoodApi
{
    public class Ingrediente
    {
        //       "id": 11677,
        //       "image": "shallots.jpg",
        //       "name": "shallot",
        //       "amount": 140.0,
        //       "unit": "g"
        [JsonPropertyName("id")]
        public double Id { get; set; }

        [JsonPropertyName("image")]
        public Uri Imagen { get; set; }

        [JsonPropertyName("name")]
        public string Nombre { get; set; }

        [JsonPropertyName("amount")]
        public double Cantidad { get; set; }

        [JsonPropertyName("unit")]
        public string Unidad { get; set; }
    }
}
