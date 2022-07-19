namespace Application.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Interfaces;
    using Domain.Models;

    /// <summary>
    /// Dto model for post requests.
    /// </summary>
    public class NodeDtoPostRequest : IDtoMapper<Node>
    {
        /// <summary>
        /// Get or sets node Name. 
        /// </summary>
        /// <value>Name</value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets node Description.
        /// </summary>
        /// <value>Description</value>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets node parent Id.
        /// </summary>
        /// <value>Parent Id</value>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets children for node.
        /// </summary>
        public List<NodeDtoPostRequest> Children { get; set; } = new List<NodeDtoPostRequest>();

        public Node ToModel()
        {
            return new Node
            {
                Name = this.Name,
                Description = this.Description,
                ParentId = this.ParentId,
                Children = this.Children.Select(child => child.ToModel()).ToList()
            };
        }
    }
}