using AgentPortal.DB;
using Microsoft.Win32;
using System;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AgentPortal.WindowsApp;

namespace AgentPortal.PageApp
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public static byte[] _image { get; set; }
        Employee employee = new Employee();
        public ProfilePage()
        {
            InitializeComponent();
            this.DataContext = ClassDB.connection.Employee.Where(z => z.ID == ClassApp.ClassContext.CorrEmployee.ID).FirstOrDefault();
        }

        private void ClEventChangePhoto(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() != null)
            {
                _image = File.ReadAllBytes(dialog.FileName);
            }
            
        }

        private void ClEventChangePassword(object sender, RoutedEventArgs e)
        {
            NewPasswordWindow win = new NewPasswordWindow();
            win.Show();
        }

        private void ClEventShowInfo(object sender, RoutedEventArgs e)
        {
            //В разработке
        }
    }
}
