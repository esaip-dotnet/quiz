using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace api_core.net.Models
{
    /**
     * Modélisation de la base d'un quiz :
     * - Un id unique
     * - Un résumé court
     * - Une description
     * - Un titre
     **/
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
