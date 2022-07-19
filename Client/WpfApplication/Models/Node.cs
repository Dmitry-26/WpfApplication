namespace WpfApplication.Models
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using WpfApplication.Models.DtoModels;
    using WpfApplication.NetServices;

    /// <summary>
    /// Model of Node.
    /// </summary>
    public class Node : ModelBase
    {
        private int id;
        private string name;
        private string description;
        private int? parentId;
        private Node? parent;

        /// <inheritdoc/>
        public override event PropertyChangedEventHandler PropertyChanged;

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
        /// Gets or sets description of Node.
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
        /// Gets or sets parent Id of Node.
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
        /// Gets or sets Parent of Node.
        /// </summary>
        public Node? Parent
        {
            get => this.parent;
            set
            {
                this.parent = value;
                this.OnPropertyChanged(nameof(this.Parent));
            }
        }

        /// <summary>
        /// Gets or sets collection of Nodes.
        /// </summary>
        public ObservableCollection<Node> Children { get; set; }

        /// <inheritdoc/>
        public override void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                NodeDtoPutRequest nodeDto = new NodeDtoPutRequest(this);
                new ServerApi(new Uri("http://localhost:5250/api/node")).Update(nodeDto);
            }
        }
    }
}
