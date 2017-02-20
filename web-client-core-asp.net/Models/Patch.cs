using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClientCore.Models
{
    public class Patch
    {
        [JsonProperty("op")]
        public string Operation { get; set; }
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("value")]
        public Question Question { get; set; }
        public Patch(string Operation, string Path, Question Question) {
            this.Operation = Operation;
            this.Path = Path;
            this.Question = Question;
        }
    }
}
