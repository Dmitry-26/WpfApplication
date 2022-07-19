namespace WpfApplication.Models.DtoModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.Serialization;
    using WpfApplication.Models;

    /// <summary>
    /// Dto model of node for post requests.
    /// </summary>
    [DataContract]
    public class NodeDtoPostRequest : ModelBase, IDataErrorInfo
    {
        [DataMember]
        private string name;

        [DataMember]
        private string description;

        [DataMember]
        private int? parentId;

        [DataMember]
        private ObservableCollection<NodeDtoPostRequest> children;

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeDtoPostRequest"/> class.
        /// </summary>
        /// <param name="node">Instance of node.</param>
        public NodeDtoPostRequest(Node node)
        {
            this.Name = node.Name;
            this.Description = node.Description;
            this.ParentId = node.ParentId;
            this.Children = new ObservableCollection<NodeDtoPostRequest>(node.Children.Select(child => new NodeDtoPostRequest(child)).ToList<NodeDtoPostRequest>());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeDtoPostRequest"/> class.
        /// </summary>
        public NodeDtoPostRequest()
        {
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
        /// Gets or sets Description of Node.
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
        /// Gets or sets ParentId of Node.
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

        /// <summary>
        /// Gets or sets collection of Nodes.
        /// </summary>
        public ObservableCollection<NodeDtoPostRequest> Children
        {
            get => this.children;
            set
            {
                this.children = value;
                this.OnPropertyChanged(nameof(this.Children));
            }
        }

        /// <inheritdoc/>
        public string Error => null;

        /// <inheritdoc/>
        public string this[string columnName]
        {
            get
            {
                string result = null;
                switch (columnName)
                {
                    case nameof(this.Name):
                        if (string.IsNullOrWhiteSpace(this.Name))
                        {
                            result = $"{nameof(this.Name)} mustn't be empty string";
                        }

                        break;
                    case nameof(this.Description):
                        if (string.IsNullOrWhiteSpace(this.Description))
                        {
                            result = $"{nameof(this.Description)} mustn't be empty string";
                        }

                        break;
                }

                return result;
            }
        }

        /// <summary>
        /// Returns valid instance or not.
        /// </summary>
        /// <returns>Instance of node is valid or not.</returns>
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(this.Name) && !string.IsNullOrWhiteSpace(this.Description);
        }
    }
}
