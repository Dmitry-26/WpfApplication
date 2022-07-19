namespace Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.DTO;
    using Application.Interfaces;
    using Domain.Repository;

    /// <summary>
    /// Node Service.
    /// </summary>
    public class NodeService : INodeService
    {
        private INodeRepository repository;

        public NodeService(INodeRepository repository)
        {
            this.repository = repository;
        }

        public List<NodeDtoResponse> GetAll()
        {
            return this.repository.GetAll().Select(node => new NodeDtoResponse(node)).ToList();
        }

        public NodeDtoResponse Get(int id)
        {
            return new NodeDtoResponse(this.repository.Get(id));
        }

        public List<int> Add(NodeDtoPostRequest node)
        {
            return this.repository.Add(node.ToModel());
        }

        public void Edit(NodeDtoPutRequest node)
        {
            this.repository.Edit(node.ToModel());
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }
    }
}