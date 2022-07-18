using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication.Models;

namespace WpfApplication.DtoModels
{
    public class NodeDtoPutRequest
    {
        public int id;
        public string name;
        public string description;
        public int? parentId;
        public NodeDtoPutRequest(Node node)
        {
            this.id = node.Id;
            this.name = node.Name;
            this.description = node.Description;
            this.parentId = node.ParentId;
        }
    }
}
