namespace WpfApplication.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;
    using WpfApplication.Commands;
    using WpfApplication.Models;
    using WpfApplication.NetServices;

    /// <summary>
    /// MainWindow view model.
    /// </summary>
    public class NodeViewModel : ViewModelBase
    {
        private Node selectedNode;
        private ObservableCollection<Node> nodes;

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeViewModel"/> class.
        /// </summary>
        public NodeViewModel()
        {
            this.Nodes = new ObservableCollection<Node>(new ServerApi(new Uri("http://localhost:5250/api/node")).GetData());
        }

        /// <summary>
        /// Gets or sets value of selected node.
        /// </summary>
        public Node SelectedNode
        {
            get => this.selectedNode;
            set
            {
                this.selectedNode = value;
                this.OnPropertyChanged(nameof(this.SelectedNode));
            }
        }

        /// <summary>
        /// Gets or sets collection of nodes.
        /// </summary>
        public ObservableCollection<Node> Nodes
        {
            get => this.nodes;
            set
            {
                this.nodes = value;
                this.OnPropertyChanged(nameof(this.Nodes));
            }
        }

        /// <summary>
        /// Gets Delete node command.
        /// </summary>
        public ICommand DeleteNode
        {
            get => new RelayCommand(
                parameter => this.DeleteNodeExecute(parameter),
                parameter => this.DeleteNodeCanExecute(parameter));
        }

        /// <summary>
        /// Gets opening new window command.
        /// </summary>
        public ICommand OpenNewNodeCreatingWindow
        {
            get => new RelayCommand(parameter => this.OpenNewNodeCreatingWindowExecute(parameter));
        }

        /// <summary>
        /// Command of Deleting node.
        /// </summary>
        /// <param name="parameter">Command parameter.</param>
        public void DeleteNodeExecute(object parameter)
        {
            Node node = parameter as Node ?? throw new Exception("node for deleting is null");
            new ServerApi(new Uri("http://localhost:5250/api/node")).Delete(node.Id);
            this.Nodes = new ObservableCollection<Node>(new ServerApi(new Uri("http://localhost:5250/api/node")).GetData());
        }

        /// <summary>
        /// Determines Deleting of node may be executed or not.
        /// </summary>
        /// <param name="parameter">Command parameter.</param>
        /// <returns>Deleting of node may be executed or not.</returns>
        public bool DeleteNodeCanExecute(object parameter)
        {
            return parameter is Node;
        }

        /// <summary>
        /// Executes opening new window command. Opens new Window.
        /// </summary>
        /// <param name="parameter">Command parameter.</param>
        public void OpenNewNodeCreatingWindowExecute(object parameter)
        {
            if (parameter is null)
            {
                ShowWindow();
                return;
            }

            if (parameter is Node p)
            {
                ShowWindow(p);
            }
            else
            {
                throw new Exception("parameter is not a Node");
            }

            void ShowWindow(Node parentNode = null)
            {
                AddNewNodeWindow newWindow = new AddNewNodeWindow(parentNode);
                newWindow.Owner = Application.Current.MainWindow;
                if (newWindow.ShowDialog() == true)
                {
                    this.Nodes = new ObservableCollection<Node>(new ServerApi(new Uri("http://localhost:5250/api/Node")).GetData());
                    return;
                }
            }
        }
    }
}
