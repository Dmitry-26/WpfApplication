namespace WpfApplication.NetServices
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using Newtonsoft.Json;
    using WpfApplication.Models;
    using WpfApplication.Models.DtoModels;

    // TODO: Add exception handling

    /// <summary>
    /// Class for requesting to server.
    /// </summary>
    public class ServerApi
    {
        private Uri baseUri;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerApi"/> class.
        /// </summary>
        /// <param name="uri">Uri of server.</param>
        public ServerApi(Uri uri)
        {
            this.baseUri = uri;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerApi"/> class.
        /// </summary>
        /// <param name="uri">Uri of server.</param>
        public ServerApi(string uri)
            : this(new Uri(uri))
        {
        }

        /// <summary>
        /// Gets data from server.
        /// </summary>
        /// <returns>List of nodes.</returns>
        public List<Node> GetData()
        {
            WebClient client = new WebClient();
            return JsonConvert.DeserializeObject<List<Node>>(client.DownloadString(this.baseUri));
        }

        /// <summary>
        /// Gets data from server.
        /// </summary>
        /// <param name="id">Id of node.</param>
        /// <returns>Node.</returns>
        public Node GetData(int id)
        {
            WebClient client = new WebClient();
            return JsonConvert.DeserializeObject<Node>(client.DownloadString(this.baseUri + $"/{id}"));
        }

        /// <summary>
        /// Creates new node on server.
        /// </summary>
        /// <param name="node">Node.</param>
        public void PostData(NodeDtoPostRequest node)
        {
            string data = JsonConvert.SerializeObject(node, Formatting.Indented);
            WebClient client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            client.UploadString(this.baseUri, HttpMethod.Post.ToString(), data);
        }

        /// <summary>
        /// Updates node.
        /// </summary>
        /// <param name="node">Node.</param>
        public void Update(NodeDtoPutRequest node)
        {
            string data = JsonConvert.SerializeObject(node);
            WebClient client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            client.UploadString(this.baseUri, HttpMethod.Put.ToString(), data);
        }

        /// <summary>
        /// deletes node.
        /// </summary>
        /// <param name="id">Id of node.</param>
        public void Delete(int id)
        {
            WebClient client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            client.UploadString(this.baseUri.AbsoluteUri + $"/{id}", HttpMethod.Delete.ToString(), string.Empty);
        }
    }
}
