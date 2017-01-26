using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api_core.net.Models
{
    public class Quiz
    {
        [BsonIgnore]
        public ObjectId Id { get; set; }
        [BsonElement("quizId")]
        public String QuizId { get; set; }
        [BsonElement("summary")]
        public String Summary { get; set; }
        [BsonElement("description")]
        public String Description { get; set; }
        [BsonElement("title")]
        public String Title { get; set; }
        [BsonElement("questions")]
        public IEnumerable<Question> Questions { get; set; }
    }
}