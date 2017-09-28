using RecordsManager;
using System;
using Xunit;

namespace ElasticSearchFixture
{
    public class ElasticSearchFixture
    {
        [Fact]
        public void ESShouldConnectToIp()
        {
            ElasticSearch elasticSearch = new ElasticSearch();
        }

        [Fact]
        public void ESShouldReturnADefaultString()
        {
            ElasticSearch elasticSearch = new ElasticSearch();
            string s = elasticSearch.GetInitialString();
            Assert.Contains("cluster_name", s);
            Assert.Contains("cluster_uuid", s);
            Assert.Contains("version", s);
        }

        [Fact]
        public void ExecuteQueryFixture()
        {
            ElasticSearch elasticSearch = new ElasticSearch();
            string query = "{\"query\": { }}";
            string result = elasticSearch.ExecuteQuery(query);
        }

        [Fact]
        public void AddDocumentFixture()
        {
            ElasticSearch elasticSearch = new ElasticSearch();
            string result = elasticSearch.AddDocument("testing", "external", "{\"data1\":\"somedata\"}");
            Assert.Contains("_id", result);
        }
    }
}
