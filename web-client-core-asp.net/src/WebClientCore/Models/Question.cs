using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebClientCore.Models
{
    public class Question
    {
        //Nécessaire
        //Avec la propriété json : title
        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }
        //Avec la propriété json : picture
        [JsonProperty("picture")]
        public string Picture { get; set; }
        //Nécessaire
        //Avec la propriété json : answers
        [Required]
        [JsonProperty("answers")]
        public List<Answer> Answers { get; set; }
    }
}
