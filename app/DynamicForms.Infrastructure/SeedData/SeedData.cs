﻿using DynamicForms.Core.CompanyAggregator;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Reflection;

namespace DynamicForms.Infrastructure.SeedData
{
    public class SeedData
    {
        private readonly IMongoCollection<Company> _collection;

        public SeedData(IOptions<Configuration.MongoSettings> companySettings)
        {
            var client = new MongoClient(companySettings.Value.ConnectionString);
            var database = client.GetDatabase(companySettings.Value.DatabaseName);
            _collection = database.GetCollection<Company>(companySettings.Value.CollectionName);
        }

        public async Task SeedAsync()
        {
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string assemblyDirectory = Path.GetDirectoryName(assemblyLocation);

            string filePath = Path.Combine(assemblyDirectory, "SeedData", "seeddata.json");

            string json = File.ReadAllText(filePath);

            var companies = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Company>>(json);

            if (companies is null)
            {
                throw new ArgumentNullException(nameof(companies));
            }

            foreach (var company in companies)
            {
                var exists = await _collection.Find(x => x.Name == company.Name).AnyAsync();

                if (exists)
                {
                    continue;
                }

                company.SetNewId();
                await _collection.InsertOneAsync(company);
            }
        }
    }
}
