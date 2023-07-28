using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlightsApi.Model
{
    [BsonIgnoreExtraElements] 
    public class Flight
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("dateTime")]
        public DateTime DateTime { get; set; }

        [BsonElement("delay")]
        public int Delay { get; set; }

        [BsonElement("distance")]
        public int Distance { get; set; }

        [BsonElement("origin")]
        public string Origin { get; set; } = string.Empty;

        [BsonElement("destination")]
        public string Destination { get; set; } = string.Empty;

    }
}
