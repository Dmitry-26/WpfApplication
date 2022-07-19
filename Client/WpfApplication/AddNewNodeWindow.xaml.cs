namespace WpfApplication
{
    using System;
    using System.Windows;
    using WpfApplication.Models;
    using WpfApplication.ViewModels;

    /// <summary>
    /// AddNewNodeWindow.xaml.
    /// </summary>
    public partial class AddNewNodeWindow : Window
    {
        private AddNodeViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddNewNodeWindow"/> class.
        /// </summary>
        /// <param name="parentNode">Parent node for new node.</param>
        public AddNewNodeWindow(Node parentNode)
        {
            this.InitializeComponent();
            this.viewModel = parentNode == null ? new AddNodeViewModel() : new AddNodeViewModel(parentNode);
            this.DataContext = this.viewModel;
        }

        /// <summary>
        /// Handler of saving button click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event parameters.</param>
        public void SaveClicked(object sender, EventArgs e)
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
