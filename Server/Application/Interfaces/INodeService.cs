using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.Interfaces
{
    public interface INodeService
    {
        public List<NodeDtoResponse> GetAll();
        public NodeDtoResponse Get(int id);
        public void Add(NodeDtoPostRequest node);
        public void Edit(NodeDtoPutRequest node);
        public void Delete(int id);

    }
}