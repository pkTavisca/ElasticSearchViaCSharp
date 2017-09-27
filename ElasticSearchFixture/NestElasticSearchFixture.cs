using RecordsManager;
using Xunit;

namespace ElasticSearchFixture
{
    public class NestElasticSearchFixture
    {
        [Fact]
        public void CheckingInitialConnection()
        {
            NestElasticSearch nestElasticSearch = new NestElasticSearch();
            nestElasticSearch.InitializeConnection();
        }

        [Fact]
        public void RetrievingDocuments()
        {
            NestElasticSearch nestElasticSearch = new NestElasticSearch();
            nestElasticSearch.InitializeConnection();
            var response = nestElasticSearch.GetDocuments("");
        }

        [Fact]
        public void PutDocument()
        {
            NestElasticSearch nestElasticSearch = new NestElasticSearch();
            nestElasticSearch.InitializeConnection();
            Document document = new Document() { Id = 2, Name = "qwqwqwqw" };
            var response = nestElasticSearch.Index(document);
        }
    }
}
