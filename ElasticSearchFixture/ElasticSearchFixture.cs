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
            string s = elasticSearch.GetInititalString();
            Assert.Contains("pps", s);
        }
    }
}
