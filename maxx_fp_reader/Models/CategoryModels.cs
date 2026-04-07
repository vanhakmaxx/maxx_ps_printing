using System.Collections.Generic;
using Newtonsoft.Json;

namespace maxx_pos.Models
{
    public class CategoryResponse
    {
        public string status { get; set; }
        [JsonProperty("categories")]
        public List<Category> data { get; set; }
    }

    public class Category
    {
        public string code { get; set; }
        public string description { get; set; }
        public string description_2 { get; set; }
        public string inactived { get; set; }
        public int is_deleted { get; set; }
    }
}