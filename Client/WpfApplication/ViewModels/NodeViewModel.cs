using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfApplication.Commands;
using WpfApplication.Models;
using WpfApplication.NetServices;

namespace WpfApplication.ViewModels
{
    public class NodeViewModel : INotifyPropertyChanged
    {
        public NodeViewModel()
        {
            Nodes = new ObservableCollection<Node>(new ServerApi(new Uri("http://localhost:5250/api/node")).GetData());
            DeleteNode = new DeleteNodeCommand(this);
            CreateNode = new AddNodeCommand(this);
        }
        private Node selectedNode;
        public Node SelectedNode
        {
            get => this.selectedNode;
            set
            {
                selectedNode = value;
                OnPropertyChanged(nameof(SelectedNode));
            }
        }

        private ObservableCollection<Node> nodes;
        public ObservableCollection<Node> Nodes
        {
            get => nodes;
            set
            {
                nodes = value;
                OnPropertyChanged(nameof(Nodes));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand DeleteNode { get; }
        public ICommand CreateNode { get; }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
