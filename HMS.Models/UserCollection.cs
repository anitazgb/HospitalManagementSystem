using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HMS.Models
{
    // Model for describing the user collection
    public class UserCollection : IModel
    {
        [BsonId]
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
