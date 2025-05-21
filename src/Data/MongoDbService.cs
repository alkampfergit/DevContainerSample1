using DevContainerSample1.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevContainerSample1.Data
{
    public class MongoDbService
    {
        private readonly IMongoCollection<Person> _people;

        public MongoDbService(string connectionString, string dbName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dbName);
            _people = database.GetCollection<Person>("people");
        }

        public async Task InsertPersonAsync(Person person)
        {
            await _people.InsertOneAsync(person);
        }

        public async Task<List<Person>> GetPeopleAsync()
        {
            return await _people.Find(new BsonDocument()).ToListAsync();
        }
    }
}
