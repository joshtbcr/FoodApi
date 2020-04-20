using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FoodApi
{
    public class Product
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
        public bool Vegetarian { get; set; }

        [JsonPropertyName("vegan")]
        public bool Vegan { get; set; }

        [JsonPropertyName("glutenFree")]
        public bool GlutenFree { get; set; }

        [JsonPropertyName("dairyFree")]
        public bool DairyFree { get; set; }

        [JsonPropertyName("veryHealthy")]
        public bool VeryHealthy { get; set; }

        [JsonPropertyName("cheap")]
        public bool Cheap { get; set; }

        [JsonPropertyName("veryPopular")]
        public bool VeryPopular { get; set; }

        [JsonPropertyName("pricePerServing")]
        public double PricePerServing { get; set; }

        [JsonPropertyName("servings")]
        public int Servings { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Name { get; set; }

        [JsonPropertyName("extendedIngredients")]
        public List<Ingrediente> Ingredients { get; set; }

        [JsonPropertyName("image")]
        public Uri Image{ get; set; }

        [JsonPropertyName("imageType")]
        public string ImageType { get; set; }

        [JsonPropertyName("summary")]
        public string Description { get; set; }
    }
}
