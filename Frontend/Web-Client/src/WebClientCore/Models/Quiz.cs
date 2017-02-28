using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebClientCore.Models
{
    public class Quiz
    {
        //Nécessaire
        //Avec la propriété json : title
        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }
        //Nécessaire
        //Avec la propriété json : description
        [Required]
        [JsonProperty("description")]
        public string Description { get; set; }
        //Nécessaire
        //Avec la propriété json : summary
        [Required]
        [JsonProperty("summary")]
        public string Summary { get; set; }
        //Avec la propriété json : questions
        [JsonProperty("questions")]
        public List<Question> Questions { get; set; }
    }
}
