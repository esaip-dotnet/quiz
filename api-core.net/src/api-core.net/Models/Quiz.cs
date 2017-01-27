using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api_core.net.Models
{
    public class Quiz : BaseQuiz
    {
        [BsonElement("questions")]
        public IEnumerable<Question> Questions { get; set; }
    }
}