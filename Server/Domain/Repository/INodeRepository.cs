using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Repository
{
    public interface INodeRepository
    {
        public IQueryable<Node> GetAll();
        public Node Get(int id);
        public void Add(Node node);
        public void Edit(Node node);
        public void Delete(int id);
    }
}