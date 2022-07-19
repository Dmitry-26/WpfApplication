namespace Domain.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Models;

    /// <summary>
    /// Methods for Node repository.
    /// </summary>
    public interface INodeRepository
    {
        /// <summary>
        /// Gets Nodes from Database.
        /// </summary>
        /// <returns>List of Node.</returns>
        public List<Node> GetAll();

        /// <summary>
        /// Gets Node.
        /// </summary>
        /// <param name="id">Id of Node.</param>
        /// <returns>Node.</returns>
        public Node Get(int id);

        /// <summary>
        /// Adds new Node and its children into database.
        /// </summary>
        /// <param name="node">New node.</param>
        /// <returns>Ids of Added nodes.</returns>
        public List<int> Add(Node node);

        /// <summary>
        /// Updates node.
        /// </summary>
        /// <param name="node">Node.</param>
        public void Edit(Node node);

        /// <summary>
        /// Deletes node from database.
        /// </summary>
        /// <param name="id">Id of node.</param>
        public void Delete(int id);
    }
}