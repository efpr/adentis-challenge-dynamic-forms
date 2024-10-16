
using DynamicForms.Core.CompanyAggregator;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DynamicForms.Core.CompanyAggregator
{
    public class Company
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public IEnumerable<CompanyFields> FormFields { get; set; } = new List<CompanyFields>();

        public void SetNewId()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
