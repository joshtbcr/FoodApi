using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FoodApi
{
    public class Producto
    {
         //   "id": 227687,
         //   "title": "Garlic Dill New Potatoes",
         //   "restaurantChain": "Boston Market",
         //   "servingSize": null,
         //   "readableServingSize": null,
         //   "image": "https://images.spoonacular.com/file/wximages/227687-312x231.png",
         //   "imageType": "png"

        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Titulo{ get; set; }

        [JsonPropertyName("restaurantChain")]
        public string Restaurante{ get; set; }

        [JsonPropertyName("image")]
        public Uri Imagen{ get; set; }

        [JsonPropertyName("servingSize")]
        public string TamanoPorcion { get; set; }

        [JsonPropertyName("imageType")]
        public string TipoImagen { get; set; }

        //public string LastPush => LastPushUtc.ToLocalTime();
    }
}
