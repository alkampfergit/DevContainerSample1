using System;
using System.Threading.Tasks;

namespace DevContainerSample1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("C# MongoDB + Elasticsearch Sample");

            // Load configuration
            var config = Utils.ConfigHelper.GetConfiguration();
            var mongoConn = config["MongoDb:ConnectionString"];
            var mongoDb = config["MongoDb:Database"];
            var esUri = config["ElasticSearch:Uri"];

            // Initialize services
            var mongoService = new Data.MongoDbService(mongoConn, mongoDb);
            var esService = new Data.ElasticSearchService(esUri);

            // Create a sample person
            var person = new Models.Person
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Alice Smith",
                Email = "alice@example.com"
            };

            // Store in MongoDB
            await mongoService.InsertPersonAsync(person);
            Console.WriteLine("Inserted person into MongoDB.");

            // Store in Elasticsearch
            await esService.IndexPersonAsync(person);
            Console.WriteLine("Indexed person into Elasticsearch.");

            // Retrieve from MongoDB
            var mongoPeople = await mongoService.GetPeopleAsync();
            Console.WriteLine("People in MongoDB:");
            foreach (var p in mongoPeople)
            {
                Console.WriteLine($"- {p.Name} ({p.Email})");
            }

            // Retrieve from Elasticsearch
            //need to refresh the index
            await esService.RefreshIndexAsync();
            var esPeople = await esService.GetPeopleAsync();
            Console.WriteLine("People in Elasticsearch:");
            foreach (var p in esPeople)
            {
                Console.WriteLine($"- {p.Name} ({p.Email})");
            }
        }
    }
}
