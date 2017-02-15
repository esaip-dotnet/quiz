using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api_core.net.Models
{
    /*
     * Entity Quiz
     * 
     * @attr Questions : IEnumerable<Question>
     * 
     */
    public class Quiz : BaseQuiz
    {
        [BsonElement("questions")]
        public IEnumerable<Question> Questions { get; set; }
    }
}