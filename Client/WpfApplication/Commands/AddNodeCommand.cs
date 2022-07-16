using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication.Models;
using WpfApplication.NetServices;
using WpfApplication.ViewModels;

namespace WpfApplication.Commands
{
    class AddNodeCommand : CommandBase
    {
        private NodeViewModel viewModel;

        public AddNodeCommand(NodeViewModel viewModel)
        {
            this.viewModel = viewModel;
            this.viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }

        public override void Execute(object parameter)
        {
            if (parameter is null)
            {
                ShowWindow();
                return;
            }
            Node node = parameter as Node ?? throw new Exception("parameter is not a Node");
            ShowWindow(node);
            void ShowWindow(Node parentNode = null)
            {
                AddNewNodeWindow newWindow = new AddNewNodeWindow();
                newWindow.Owner = Application.Current.MainWindow;
                newWindow.DataContext = parentNode == null ? new AddNodeViewModel() : new AddNodeViewModel(parentNode);
                newWindow.ShowDialog();
                viewModel.Nodes = new ObservableCollection<Node>(new ServerApi(new Uri("http://localhost:5250/api/Node")).GetData());
                newWindow.Close();
            }
        }
    }
}
