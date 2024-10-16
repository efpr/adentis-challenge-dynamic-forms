
using MongoDB.Bson.Serialization.Attributes;

namespace DynamicForms.Core.Domain
{
    public class Company
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; private set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public void SetNewId()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
