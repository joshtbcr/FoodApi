using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FoodApi
{
    public class MenuProductos
    {
        [JsonPropertyName("menuItems")]
        //public string Productos { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
