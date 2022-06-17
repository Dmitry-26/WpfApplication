using System.Collections.Generic;
using Domain.Models;

namespace Application.DTO;
public class NodeDto
{
    public NodeDto()
    {
    }
    public NodeDto(Node node)
    {
        this.Id = node.Id;
        this.Name = node.Name;
        this.Description = node.Description;
        this.ParentId = node.ParentId;
        this.Children = node.Children.Select(node => new NodeDto(node)).ToList();
    }
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int? ParentId { get; set; }
    public List<NodeDto> Children { get; set; } = new List<NodeDto>();
}
