using System.Collections.Generic;
using Newtonsoft.Json;

namespace maxx_pos.Models
{
    public class DepartmentResponse
    {
        public string status { get; set; }
        [JsonProperty("departments")]
        public List<Department> data { get; set; }
    }

    public class Department
    {
        public string code { get; set; }
        public string finance_code { get; set; }
        public string description { get; set; }
        public string description_2 { get; set; }
        public string division_code { get; set; }
        public string inactived { get; set; }
        public int is_deleted { get; set; }
    }
}