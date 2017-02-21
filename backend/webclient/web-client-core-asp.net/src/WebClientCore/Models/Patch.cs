using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClientCore.Models
{
    //Object pour créer le patch
    public class Patch
    {
        //Avec la propriété json : op
        [JsonProperty("op")]
        public string Operation { get; set; }
        //Avec la propriété json : path
        [JsonProperty("path")]
        public string Path { get; set; }
        //Avec la propriété json : value
        [JsonProperty("value")]
        public Question Question { get; set; }

        //Constructeur
        public Patch(string Operation, string Path, Question Question) {
            this.Operation = Operation;
            this.Path = Path;
            this.Question = Question;
        }
    }
}
