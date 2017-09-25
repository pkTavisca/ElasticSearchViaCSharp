using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RecordsManager
{
    public class ElasticSearch
    {
        private string _ip = "172.16.14.171";
        private int _port = 9200;

        TcpClient esService;

        public ElasticSearch()
        {
            esService = new TcpClient();
            esService.ConnectAsync(IPAddress.Parse(_ip), _port).GetAwaiter().GetResult();
        }

        public string GetInititalString()
        {
            WebRequest webRequest = HttpWebRequest.Create($"http://{_ip}:{_port}");
            WebResponse webResponse = webRequest.GetResponseAsync().GetAwaiter().GetResult();
            var streamReader = new StreamReader(webResponse.GetResponseStream());
            return streamReader.ReadToEnd();
        }
    }
}
