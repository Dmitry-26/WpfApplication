using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;

namespace Application.DTO
{
    public class NodeDtoPostRequest : IDtoMapper<Node>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? ParentId { get; set; }
        public List<NodeDtoPostRequest> Children {get;set;} = new List<NodeDtoPostRequest>();

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