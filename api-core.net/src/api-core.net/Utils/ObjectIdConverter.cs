using MongoDB.Bson;
using Newtonsoft.Json;
using System;

namespace api_core.net.Utils
{
    /**
     * JsonConverter ObjectIdConverter
     * Util class containing methods to read and write Json while converting ObjectId attributes into String ones
     **/
    public class ObjectIdConverter : JsonConverter
    {
        /**
         * Function CanConvert
         * Returns True if the Object type is ObjectId, otherwise returns False
         * 
         * @param objectType : Type
         * @return bool
         **/
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ObjectId);
        }

        /**
         * Function ReadJson
         * 
         * @param reader : JsonReader
         * @param objectType : Type
         * @param existingValue : object
         * @param JsonSerializer : serializer
         * @return ObjectId
         **/
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
                throw new Exception($"Unexpected token parsing ObjectId. Expected String, got {reader.TokenType}.");

            var value = (string)reader.Value;
            return string.IsNullOrEmpty(value) ? ObjectId.Empty : new ObjectId(value);
        }

        /**
         * Function WriteJson
         * 
         * @param writer : JsonWriter
         * @param value : object
         * @param JsonSerializer : serializer
         * @return void
         **/
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is ObjectId)
            {
                var objectId = (ObjectId)value;
                writer.WriteValue(objectId != ObjectId.Empty ? objectId.ToString() : string.Empty);
            }
            else
            {
                throw new Exception("Expected ObjectId value.");
            }
        }
    }
}
