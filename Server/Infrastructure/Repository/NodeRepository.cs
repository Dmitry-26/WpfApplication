using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.Models;
using Domain.Repository;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class NodeRepository : INodeRepository
    {
        private DatabaseContext db;
        public NodeRepository(DatabaseContext db)
        {
            this.db = db;
        }
        public IQueryable<Node> GetAll()
        {
            return db.Nodes.Where(node => node.ParentId == null).Include(x => x.Children).ThenInclude(x => x.Children).AsNoTracking();
        }

        public Node Get(int id)
        {
            return db.Nodes.Include(x => x.Children).ThenInclude(x => x.Children).SingleOrDefault(node => node.Id == id);
        }

        public void Add(Node node)
        {
            db.Nodes.Add(node);
            db.SaveChanges();
        }

        public void Edit(Node node)
        {
            Node entity = db.Nodes.Find(node.Id) ?? throw new NodeNotFoundException($"node with Id = {node.Id} not found");
            if (node.ParentId == null)
            {
                entity.ParentId = node.ParentId;
            }
            else
            {
                if (db.Nodes.Find(node.ParentId) != null)
                {
                    entity.ParentId = node.ParentId;
                }
                else
                {
                    throw new NodeNotFoundException($"node with Id = {node.Id} not found");
                }
            }
            entity.Name = node.Name;
            entity.Description = node.Description;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Node node = db.Nodes.Include(node => node.Children).SingleOrDefault(node => node.Id == id);
            if (node == null) throw new NodeNotFoundException($"node with id = {id} not found");
            while (node.Children.Count() > 0)
            {
                Delete(node.Children[0].Id);
            }
            db.Nodes.Remove(node);
            db.SaveChanges();
        }
    }
}