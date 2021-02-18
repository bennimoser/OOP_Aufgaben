using Microsoft.Win32;
using PersonManager.Commands;
using PersonManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersonManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.txtBoxBirthday.Text = String.Empty;
        }

        private void OpenFileDia(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                ((PersonManagementVM)this.DataContext).SettingArgs.FilePath = dlg.FileName;
            }
        }

        public ICommand LoadCommand
        {
            get
            {
                return new Command((obj) =>
                {
                    try
                    {
                        ((PersonManagementVM)this.DataContext).LoadCommand.Execute(null);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                },
                
                (obj) => ((PersonManagementVM)this.DataContext).LoadCommand.CanExecute(null));
            }
        }
    }
}
