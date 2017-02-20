using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace api_core.net.Models
{
    /**
     * Modélisation d'une question :
     * - Un titre
     * - Une image, si la question est en image
     * - Une liste de réponses
     **/
    public class Question
    {
        [BsonElement("title")]
        public String Title { get; set; }
        [BsonElement("picture")]
        public String Picture { get; set; }
        [BsonElement("answers")]
        public IEnumerable<Answer> Answers { get; set; }
    }
}