using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApplication.Models;
using WpfApplication.ViewModels;

namespace WpfApplication
{
    /// <summary>
    /// Логика взаимодействия для AddNewNodeWindow.xaml
    /// </summary>
    public partial class AddNewNodeWindow : Window
    {
        private AddNodeViewModel viewModel;
        public AddNewNodeWindow(Node parentNode)
        {
            InitializeComponent();
            this.viewModel = parentNode == null ? new AddNodeViewModel() : new AddNodeViewModel(parentNode);
            this.DataContext = this.viewModel;
        }
        public void SaveClicked(object obj, EventArgs e)
        {
            if (this.viewModel.SaveCommandCanExecute())
            {
                this.viewModel.SaveCommandExecute();
            }
            else
            {
                MessageBox.Show("new Node didn't pass validation");
                return;
            }
            this.DialogResult = true;
            this.Close();
        }
    }
}
