namespace Infrastructure.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Exceptions;
    using Domain.Models;
    using Domain.Repository;
    using Domain.Validation;
    using Domain.ValidationErrors;
    using Infrastructure.EntityFramework;
    using Microsoft.EntityFrameworkCore;

    public class NodeRepository : INodeRepository
    {
        private DatabaseContext db;

        public NodeRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public List<Node> GetAll()
        {
            var nodes = this.db.Nodes.Include(x => x.Children).Where(node => node.ParentId == null).ToList();
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i] = Get(nodes[i].Id);
            }

            return nodes;
        }

        public Node Get(int id)
        {
            Node node = this.db.Nodes.Include(x => x.Children).SingleOrDefault(node => node.Id == id) ?? throw new NodeNotFoundException($"node with Id = {id} not found");
            for (int i = 0; i < node.Children.Count; i++)
            {
                node.Children[i] = Get(node.Children[i].Id);
            }

            return node;
        }

        public List<int> Add(Node node)
        {
            new NodeValidator().Validate(node);
            if (node.ParentId != null && db.Nodes.Find(node.ParentId) == null)
            {
                throw new NodeNotFoundException($"node with Id = {node.ParentId} not found");
            }

            this.db.Nodes.Add(node);
            this.db.SaveChanges();
            List<int> Ids = new List<int>() { node.Id };
            GetChildsId(node);
            void GetChildsId(Node node)
            {
                foreach (Node child in node.Children)
                {
                    Ids.Add(child.Id);
                    GetChildsId(child);
                }
            }

            return Ids;
        }

        public void Edit(Node node)
        {
            Node entity = this.db.Nodes.Find(node.Id) ?? throw new NodeNotFoundException($"node with Id = {node.Id} not found");
            new NodeValidator().Validate(node);
            if (node.ParentId == null)
            {
                entity.ParentId = node.ParentId;
            }
            else
            {
                if (this.db.Nodes.Find(node.ParentId) != null)
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
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            Node node = this.db.Nodes.Include(node => node.Children).SingleOrDefault(node => node.Id == id) ??
            throw new NodeNotFoundException($"node with id = {id} not found");
            while (node.Children.Count() > 0)
            {
                Delete(node.Children[0].Id);
            }

            this.db.Nodes.Remove(node);
            this.db.SaveChanges();
        }
    }
}