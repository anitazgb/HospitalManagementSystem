using MongoDB.Bson.Serialization.Attributes;

namespace HMS.Models
{
    // Interface for defining MongoDB models
    public interface IModel
    {
        [BsonId]
        public Guid ID { get; set; }
    }
}
