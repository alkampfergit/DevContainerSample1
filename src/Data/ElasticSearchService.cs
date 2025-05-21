using DevContainerSample1.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevContainerSample1.Data
{
    public class ElasticSearchService
    {
        private readonly IElasticClient _client;
        private readonly string _indexName = "people";

        public ElasticSearchService(string uri)
        {
            var settings = new ConnectionSettings(new Uri(uri)).DefaultIndex(_indexName);
            _client = new ElasticClient(settings);
        }

        public async Task IndexPersonAsync(Person person)
        {
            await _client.IndexDocumentAsync(person);
        }

        public async Task<List<Person>> GetPeopleAsync()
        {
            var searchResponse = await _client.SearchAsync<Person>(s => s.MatchAll());
            return searchResponse.Documents as List<Person> ?? new List<Person>(searchResponse.Documents);
        }
    }
}
