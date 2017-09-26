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
    }
}
