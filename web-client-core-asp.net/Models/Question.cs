using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebClientCore.Models
{
    //classe Question ayant pour attribut une liste de réponse
    public class Question
    {
        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("picture")]
        public string Picture { get; set; }
        [Required]
        [JsonProperty("title")]
        public List<Answer> Answers { get; set; }
    }
}
