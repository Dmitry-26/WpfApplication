namespace Application.DTO
{
    using System.Collections.Generic;
    using Application.Interfaces;
    using Domain.Models;

    /// <summary>
    /// Node Dto model for responses.
    /// </summary>
    public class NodeDtoResponse
    {
        /// <summary>
        /// Initializes new instance of NodeDtoResponse.
        /// </summary>
        public NodeDtoResponse()
        {
        }

        /// <summary>
        /// Initializes new instance of NodeDtoResponse.
        /// </summary>
        /// <param name="node">Node</param>
        public NodeDtoResponse(Node node)
        {
            this.Id = node.Id;
            this.Name = node.Name;
            this.Description = node.Description;
            this.ParentId = node.ParentId;
            this.Children = node.Children.Select(node => new NodeDtoResponse(node)).ToList();
        }

        /// <summary>
        /// Gets or sets Id of node.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name of node.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets Description of node.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets Parent Id of node.
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets children of node.
        /// </summary>
        public List<NodeDtoResponse> Children { get; set; } = new List<NodeDtoResponse>();
    }
}