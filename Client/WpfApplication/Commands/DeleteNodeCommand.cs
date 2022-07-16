using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication.Models;
using WpfApplication.NetServices;
using WpfApplication.ViewModels;

namespace WpfApplication.Commands
{
    public class DeleteNodeCommand : CommandBase
    {
        private NodeViewModel viewModel;
        public DeleteNodeCommand(NodeViewModel nodeViewModel)
        {
            this.viewModel = nodeViewModel;
            this.viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object parameter)
        {
            Node node = parameter as Node ?? throw new Exception("node for deleting is null");
            new ServerApi(new Uri("http://localhost:5250/api/node")).Delete(node.Id);
            this.viewModel.Nodes = new ObservableCollection<Node>(new ServerApi(new Uri("http://localhost:5250/api/node")).GetData());
        }
        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
