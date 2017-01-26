using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api_core.net.Models
{
    public class Answer
    {
        [BsonElement("title")]
        public String Title { get; set; }
        [BsonElement("correct")]
        public bool Correct { get; set; }
        [BsonElement("picture")]
        public String Picture { get; set; }
        [BsonElement("checkedByPlayer")]
        public bool CheckedByPlayer { get; set; }
    }
}