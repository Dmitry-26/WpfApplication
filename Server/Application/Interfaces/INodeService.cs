namespace Application.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.DTO;

    /// <summary>
    /// Node services.
    /// </summary>
    public interface INodeService
    {
        /// <summary>
        /// Gets Nodes.
        /// </summary>
        /// <returns>Nodes.</returns>
        public List<NodeDtoResponse> GetAll();

        /// <summary>
        /// Gets Node.
        /// </summary>
        /// <param name="id">Id of node.</param>
        /// <returns>Node.</returns>
        public NodeDtoResponse Get(int id);

        /// <summary>
        /// Adds new Node and its children.
        /// </summary>
        /// <param name="node">New node</param>
        /// <returns>List of Ids of added nodes.</returns>
        public List<int> Add(NodeDtoPostRequest node);

        /// <summary>
        /// Updates Node.
        /// </summary>
        /// <param name="node">Node Dto</param>
        public void Edit(NodeDtoPutRequest node);

        /// <summary>
        /// Deletes node.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id);
    }
}