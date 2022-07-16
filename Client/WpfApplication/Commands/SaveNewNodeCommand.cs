using DoWpfApplication.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApplication.NetServices;
using WpfApplication.ViewModels;

namespace WpfApplication.Commands
{
    public class SaveNewNodeCommand : CommandBase
    {
        private AddNodeViewModel viewModel;

        public SaveNewNodeCommand(AddNodeViewModel viewModel)
        {
            this.viewModel = viewModel;
            this.CanExecuteChanged += SaveNewNodeCommand_CanExecuteChanged;
        }

        private void SaveNewNodeCommand_CanExecuteChanged(object sender, EventArgs e)
        {
            base.OnCanExecuteChanged();
        }

        public override void Execute(object parameter)
        {
            if (!viewModel.NewNode.IsValid())
            {
                MessageBox.Show("Node didn't pass validation");
                return;
            }
            new ServerApi(new Uri("http://localhost:5250/api/node")).PostData(viewModel.NewNode);
        }
    }
}
