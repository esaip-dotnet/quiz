using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api_core.net.Models
{
    /**
     * Modélisation d'un quiz complet :
     * - Une base de quiz 
     * - Une liste de questions
     **/
    public class Quiz : BaseQuiz
    {
        [BsonElement("questions")]
        public IEnumerable<Question> Questions { get; set; }
    }
}