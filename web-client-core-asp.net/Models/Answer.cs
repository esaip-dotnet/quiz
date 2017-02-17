using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebClientCore.Models
{
    //classe Answer
    public class Answer
    {
        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }
        [Required]
        [JsonProperty("correct")]
        public bool Correct { get; set; }
        [JsonProperty("picture")]
        public string Picture { get; set; }
    }
}
