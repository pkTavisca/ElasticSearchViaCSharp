using Elasticsearch.Net;
using Nest;
using System;

namespace RecordsManager
{
    public class NestElasticSearch
    {
        private string[] _ips = { "172.16.14.171", "172.16.14.148", "172.16.14.90" };
        private ElasticClient _client;

        public void InitializeConnection()
        {
            string preUri = "http://";
            Uri[] nodes = new Uri[_ips.Length];
            for (int i = 0; i < _ips.Length; i++)
            {
                nodes[i] = new Uri(preUri + _ips[i]);
            }
            var pool = new StaticConnectionPool(nodes);
            var settings = new ConnectionSettings(pool);
            _client = new ElasticClient(settings);
        }


    }
}
