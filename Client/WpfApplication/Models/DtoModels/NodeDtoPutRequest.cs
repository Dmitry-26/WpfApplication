namespace WpfApplication.Models.DtoModels
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Dto model of Node for Put requests.
    /// </summary>
    [DataContract]
    public class NodeDtoPutRequest : ModelBase
    {
        [DataMember]
        private int id;
        [DataMember]
        private string name;
        [DataMember]
        private string description;
        [DataMember]
        private int? parentId;

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeDtoPutRequest"/> class.
        /// </summary>
        /// <param name="node">Node.</param>
        public NodeDtoPutRequest(Node node)
        {
            this.Id = node.Id;
            this.Name = node.Name;
            this.Description = node.Description;
            this.ParentId = node.ParentId;
        }

        /// <summary>
        /// Gets or sets id of Node.
        /// </summary>
        public int Id
        {
            get => this.id;
            set
            {
                this.id = value;
                this.OnPropertyChanged(nameof(this.Id));
            }
        }

        /// <summary>
        /// Gets or sets name of Node.
        /// </summary>
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
                this.OnPropertyChanged(nameof(this.Name));
            }
        }

        /// <summary>
        /// Gets or sets id of Node.
        /// </summary>
        public string Description
        {
            get => this.description;
            set
            {
                this.description = value;
                this.OnPropertyChanged(nameof(this.Description));
            }
        }

        /// <summary>
        /// Gets or sets id of Node.
        /// </summary>
        public int? ParentId
        {
            get => this.parentId;
            set
            {
                this.parentId = value;
                this.OnPropertyChanged(nameof(this.ParentId));
            }
        }
    }
}
