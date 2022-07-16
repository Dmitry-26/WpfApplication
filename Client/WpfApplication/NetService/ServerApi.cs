using DoWpfApplication.DtoModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using WpfApplication.DtoModels;
using WpfApplication.Models;

namespace WpfApplication.NetServices
{
    // TODO: Add exception handling
    public class ServerApi
    {
        private Uri baseUri;
        public ServerApi(Uri uri)
        {
            this.baseUri = uri;
        }
        public ServerApi(string uri)
            :this(new Uri(uri))
        {
        }

        public List<Node> GetData()
        {
            WebClient client = new WebClient();
            return JsonConvert.DeserializeObject<List<Node>>(client.DownloadString(this.baseUri));
        }

        public Node GetData(int id)
        {
            WebClient client = new WebClient();
            return JsonConvert.DeserializeObject<Node>(client.DownloadString(this.baseUri));
        }

        public void PostData(NodeDtoPostRequest node)
        {
            string data = JsonConvert.SerializeObject(node, Formatting.Indented);
            WebClient client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            client.UploadString(this.baseUri, HttpMethod.Post.ToString(), data);
        }

        public void Update(NodeDtoPutRequest node)
        {
            string data = JsonConvert.SerializeObject(node);
            WebClient client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            client.UploadString(this.baseUri, HttpMethod.Put.ToString(), data);
        }

        public void Delete(int id)
        {
            WebClient client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            client.UploadString(baseUri.AbsoluteUri + $"/{id}", HttpMethod.Delete.ToString(), string.Empty);
        }
    }
}
