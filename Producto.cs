using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FoodApi
{
    public class Producto
    {
        //"vegetarian": true,
        //"vegan": true,
        //"glutenFree": true,
        //"dairyFree": true,
        //"veryHealthy": true,
        //"cheap": false,
        //"veryPopular": false,
        //"pricePerServing": 288.63,
        //"extendedIngredients": [
        //"id": 26800,
        //"title": "Tomato Soup",
        //"servings": 2,
        //"image": "https://spoonacular.com/recipeImages/26800-556x370.jpg",
        //"imageType": "jpg",
        //"summary": "Tomato Soup might be just the soup you are searching for.",

        [JsonPropertyName("vegetarian")]
        public bool Vegetariano { get; set; }

        [JsonPropertyName("vegan")]
        public bool Vegano { get; set; }

        [JsonPropertyName("glutenFree")]
        public bool LibreGluten { get; set; }

        [JsonPropertyName("dairyFree")]
        public bool LibreLactosa { get; set; }

        [JsonPropertyName("veryHealthy")]
        public bool MuySano { get; set; }

        [JsonPropertyName("cheap")]
        public bool Barato{ get; set; }

        [JsonPropertyName("veryPopular")]
        public bool MuyPopular { get; set; }

        [JsonPropertyName("pricePerServing")]
        public double CostoPorcion{ get; set; }

        [JsonPropertyName("servings")]
        public int Porciones { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Titulo{ get; set; }

        [JsonPropertyName("extendedIngredients")]
        public List<Ingrediente> Ingredientes { get; set; }

        [JsonPropertyName("image")]
        public Uri Imagen{ get; set; }

        [JsonPropertyName("imageType")]
        public string TipoImagen { get; set; }

        [JsonPropertyName("summary")]
        public string Descripcion { get; set; }
    }
}
