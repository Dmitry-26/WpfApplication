using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WpfApplication.Commands;
using WpfApplication.Models;
using WpfApplication.NetServices;

namespace WpfApplication.ViewModels
{
    public class NodeViewModel : ViewModelBase
    {
        public NodeViewModel()
        {
            Nodes = new ObservableCollection<Node>(new ServerApi(new Uri("http://localhost:5250/api/node")).GetData());
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


        public ICommand DeleteNode
        {
            get => new RelayCommand
            (
                parameter => DeleteNodeExecute(parameter),
                parameter => DeleteNodeCanExecute(parameter)
            );
        }
        public ICommand OpenNewNodeCreatingWindow
        {
            get => new RelayCommand
            (
                parameter => OpenNewNodeCreatingWindowExecute(parameter)
            );
        }

        #region Commands
        public void DeleteNodeExecute(object parameter)
        {
            Node node = parameter as Node ?? throw new Exception("node for deleting is null");
            new ServerApi(new Uri("http://localhost:5250/api/node")).Delete(node.Id);
            Nodes = new ObservableCollection<Node>(new ServerApi(new Uri("http://localhost:5250/api/node")).GetData());

        }
        public bool DeleteNodeCanExecute(object parameter)
        {
            return parameter is Node;
        }
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
        #endregion

    }
}
