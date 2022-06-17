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
        public List<NodeDto> GetAll()
        {
            return repository.GetAll().Select(node => new NodeDto(node)).ToList();
        }

        public NodeDto Get(int id)
        {
            return new NodeDto(repository.Get(id));
        }

        public void Add(NodeDto node)
        {
            throw new NotImplementedException();
        }

        public void Edit(NodeDto node)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}