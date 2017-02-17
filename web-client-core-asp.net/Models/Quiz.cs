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
        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }
        [Required]
        [JsonProperty("description")]
        public string Description { get; set; }
        [Required]
        [JsonProperty("summary")]
        public string Summary { get; set; }
        [JsonProperty("questions")]
        public List<Question> Questions { get; set; }
    }
}
