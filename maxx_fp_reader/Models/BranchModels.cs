using System.Collections.Generic;
using Newtonsoft.Json;

namespace maxx_pos.Models
{
    public class BranchResponse
    {
        public string status { get; set; }
        [JsonProperty("branches")]
        public List<Branch> data { get; set; }
    }

    public class Branch
    {
        public string code { get; set; }
        public string description { get; set; }
    }
}