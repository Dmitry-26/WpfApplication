using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Repository
{
    public interface INodeRepository
    {
        public List<Node> GetAll();
        public Node Get(int id);
        public List<int> Add(Node node);
        public void Edit(Node node);
        public void Delete(int id);
    }
}