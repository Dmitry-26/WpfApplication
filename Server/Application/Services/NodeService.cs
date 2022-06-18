using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Domain.Repository;

namespace Application.Services
{
    public class NodeService : INodeService
    {
        private INodeRepository repository;
        public NodeService(INodeRepository repository)
        {
            this.repository = repository;
        }
        public List<NodeDtoResponse> GetAll()
        {
            return repository.GetAll().Select(node => new NodeDtoResponse(node)).ToList();
        }

        public NodeDtoResponse Get(int id)
        {
            return new NodeDtoResponse(repository.Get(id));
        }

        public int Add(NodeDtoPostRequest node)
        {
            return repository.Add(node.ToModel());
        }

        public void Edit(NodeDtoPutRequest node)
        {
            repository.Edit(node.ToModel());
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}