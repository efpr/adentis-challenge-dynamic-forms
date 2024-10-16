using DynamicForms.Core.CompanyAggregator;
using DynamicForms.Core.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DynamicForms.Infrastructure.Persistence
{
    public class CompanyMongoRepository : ICompanyRepository
    {
        private readonly IMongoCollection<Company> _collection;

        public CompanyMongoRepository(IOptions<Configuration.MongoSettings> companySettings)
        {
            var client = new MongoClient(companySettings.Value.ConnectionString);
            var database = client.GetDatabase(companySettings.Value.DatabaseName);
            _collection = database.GetCollection<Company>(companySettings.Value.CollectionName);
        }

        public CompanyMongoRepository(IMongoDatabase database, string collection)
        {
            _collection = database.GetCollection<Company>(collection);
        }

        public async Task AddAsync(Company entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task<Company> GetByIdAsync(string id)
        {
            var document = await _collection.Find(Builders<Company>.Filter.Eq("_id", id)).FirstOrDefaultAsync();
            return document;
        }
    }
}
