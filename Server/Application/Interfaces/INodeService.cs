using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.Interfaces
{
    public interface INodeService
    {
        public List<NodeDto> GetAll();
        public NodeDto Get(int id);
        public void Add(NodeDto node);
        public void Edit(NodeDto node);
        public void Delete(int id);

    }
}