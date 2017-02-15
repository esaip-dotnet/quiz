using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace api_core.net.Models
{
    /*
     * Base Entity BaseQuiz
     * 
     * @attr Id : ObjectId
     * @attr Summary : String
     * @attr Description : String
     * @attr Title : String
     * 
     */
    public class BaseQuiz
    {
        public ObjectId Id { get; set; }
        [BsonElement("summary")]
        public String Summary { get; set; }
        [BsonElement("description")]
        public String Description { get; set; }
        [BsonElement("title")]
        public String Title { get; set; }
    }
}
