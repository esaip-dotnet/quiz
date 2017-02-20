using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api_core.net.Models
{
    /**
     * Modélisation d'une réponse :
     * - Un titre (texte de la réponse)
     * - Un booléen indiquant si la réponse est une bonne réponse
     * - Une image, si la réponse est en image 
     * - Un booléen indiquant si cette réponse à été choisie par le joueur
     **/
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