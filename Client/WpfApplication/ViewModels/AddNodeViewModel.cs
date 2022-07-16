using DoWpfApplication.DtoModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication.Commands;
using WpfApplication.Models;

namespace WpfApplication.ViewModels
{
    public class AddNodeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Node parentNode;
        public Node ParentNode { get => parentNode; init => parentNode = value; }

        private NodeDtoPostRequest newNode;
        public NodeDtoPostRequest NewNode { get => newNode; set { newNode = value; OnPropertyChanged(nameof(NewNode)); } }
        public AddNodeViewModel(Node parentNode = null)
        {
            this.SaveCommand = new SaveNewNodeCommand(this);
            this.ParentNode = parentNode;
            this.NewNode = new NodeDtoPostRequest();
            this.NewNode.ParentId = this.ParentNode?.Id;
            this.NewNode.Children = new ObservableCollection<NodeDtoPostRequest>();
        }

        public ICommand SaveCommand { get; }
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
