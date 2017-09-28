using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;

namespace RecordsManager
{
    public class ElasticSearch
    {
        private string _ip = "172.16.14.171";
        private int _port = 9200;
        private string _uri;

        TcpClient esService;

        public ElasticSearch()
        {
            esService = new TcpClient();
            esService.ConnectAsync(IPAddress.Parse(_ip), _port).GetAwaiter().GetResult();
            _uri = $"http://{_ip}:{_port}";
        }

        public string GetInitialString()
        {
            WebRequest request = HttpWebRequest.Create($"http://{_ip}:{_port}");
            WebResponse response = request.GetResponseAsync().GetAwaiter().GetResult();
            var streamReader = new StreamReader(response.GetResponseStream());
            return streamReader.ReadToEnd();
        }

        public string ExecuteQuery(string query)
        {
            WebRequest request = HttpWebRequest.Create($"http://{_ip}:{_port}");
            request.Method = "GET";
            if (request.Method.ToUpperInvariant().Equals("POST"))
                request.ContentType = "application/json";
            Stream outgoingStream = request.GetRequestStreamAsync().GetAwaiter().GetResult();
            outgoingStream.Write(Encoding.ASCII.GetBytes(query), 0, query.Length);
            WebResponse response = request.GetResponseAsync().GetAwaiter().GetResult();
            var streamReader = new StreamReader(response.GetResponseStream());

            return streamReader.ReadToEnd();
        }

        public string AddDocument(string index, string type, string data, string id = "")
        {
            WebRequest request = HttpWebRequest.Create($"http://{_ip}:{_port}/{index}/{type}/{id}");
            request.Method = "POST";
            request.ContentType = "application/json";
            Stream outgoingStream = request.GetRequestStreamAsync().GetAwaiter().GetResult();
            outgoingStream.Write(Encoding.ASCII.GetBytes(data), 0, data.Length);
            WebResponse response = request.GetResponseAsync().GetAwaiter().GetResult();
            var streamReader = new StreamReader(response.GetResponseStream());
            return streamReader.ReadToEnd();
        }

        public string RemoveDocument(string index, string type, string id)
        {
            WebRequest request = HttpWebRequest.Create($"http://{_ip}:{_port}/{index}/{type}/{id}");
            request.Method = "DELETE";
            request.ContentType = "application/json";
            WebResponse response = request.GetResponseAsync().GetAwaiter().GetResult();
            var streamReader = new StreamReader(response.GetResponseStream());
            return streamReader.ReadToEnd();
        }

        public string UpdateDocument(string index, string type, string data, string id)
        {
            RemoveDocument(index, type, id);
            return AddDocument(index, type, data, id);
        }
    }
}
