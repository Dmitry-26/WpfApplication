using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;

namespace Application.DTO
{
    public class NodeDtoPutRequest : IDtoMapper<Node>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? ParentId { get; set; }

        public Node ToModel()
        {
            return new Node
            {
                Id= this.Id,
                Name = this.Name,
                Description = this.Description,
                ParentId = this.ParentId
            };
        }
    }
}