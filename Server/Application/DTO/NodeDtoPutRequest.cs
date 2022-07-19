namespace Application.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Interfaces;
    using Domain.Models;

    /// <summary>
    /// Node Dto model for put requests.
    /// </summary>
    public class NodeDtoPutRequest : IDtoMapper<Node>
    {
        /// <summary>
        /// Gets or sets Node Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Node Name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets Node Description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets Node ParentId.
        /// </summary>
        public int? ParentId { get; set; }

        public Node ToModel()
        {
            return new Node
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                ParentId = this.ParentId
            };
        }
    }
}