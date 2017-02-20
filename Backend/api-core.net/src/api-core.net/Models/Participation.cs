﻿using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api_core.net.Models
{
    public class Participation
    {
        public ObjectId Id { get; set; }
        [BsonElement("startTimestamp")]
        public DateTime StartTimestamp { get; set; }
        [BsonElement("idParticipant")]
        public String IdParticipant { get; set; }
        [BsonElement("score")]
        public Double Score { get; set; }
        [BsonElement("quiz")]
        public Quiz Quiz { get; set; }
    }
}
