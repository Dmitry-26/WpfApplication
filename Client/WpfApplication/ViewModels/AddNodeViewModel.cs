namespace WpfApplication.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using WpfApplication.Commands;
    using WpfApplication.Models;
    using WpfApplication.Models.DtoModels;
    using WpfApplication.NetServices;

    /// <summary>
    /// View model of new model adding.
    /// </summary>
    public class AddNodeViewModel : ViewModelBase
    {
        private Node parentNode;

        private NodeDtoPostRequest newNode;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddNodeViewModel"/> class.
        /// </summary>
        /// <param name="parentNode">Node which will parent of new Node.</param>
        public AddNodeViewModel(Node parentNode = null)
        {
            this.ParentNode = parentNode;
            this.NewNode = new NodeDtoPostRequest();
            this.NewNode.ParentId = this.ParentNode?.Id;
            this.NewNode.Children = new ObservableCollection<NodeDtoPostRequest>();
        }

        /// <summary>
        /// Gets or initializes ParentNode.
        /// </summary>
        public Node ParentNode
        {
            get => this.parentNode;
            init => this.parentNode = value;
        }

        /// <summary>
        /// Gets or sets new Node.
        /// </summary>
        public NodeDtoPostRequest NewNode
        {
            get => this.newNode;
            set
            {
                this.newNode = value;
                this.OnPropertyChanged(nameof(this.NewNode));
            }
        }

        /// <summary>
        /// Gets Command for saving of new Node.
        /// </summary>
        public ICommand SaveCommand
        {
            get => new RelayCommand(
                    parameter => this.SaveCommandExecute(),
                    parameter => this.SaveCommandCanExecute());
        }

        /// <summary>
        /// Saves new Node on server.
        /// </summary>
        public void SaveCommandExecute()
        {
            new ServerApi(new Uri("http://localhost:5250/api/node")).PostData(this.NewNode);
        }

        /// <summary>
        /// Determines whether new node may be saved.
        /// </summary>
        /// <returns>New Node is valid or not.</returns>
        public bool SaveCommandCanExecute()
        {
            return this.NewNode.IsValid();
        }
    }
}
