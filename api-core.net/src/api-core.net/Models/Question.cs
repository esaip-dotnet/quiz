using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace api_core.net.Models
{
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