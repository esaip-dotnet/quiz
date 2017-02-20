using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebClientCore.Models
{
    //Objet answer
    public class Answer
    {
        //Nécessaire
        //Avec la propriété json : title
        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }
        //Nécessaire
        //Avec la propriété json : correct
        [Required]
        [JsonProperty("correct")]
        public bool Correct { get; set; }
        //Avec la propriété json : picture
        [JsonProperty("picture")]
        public string Picture { get; set; }
    }
}
