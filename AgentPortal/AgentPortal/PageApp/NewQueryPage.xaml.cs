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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AgentPortal.PageApp
{
    /// <summary>
    /// Логика взаимодействия для NewQueryPage.xaml
    /// </summary>
    public partial class NewQueryPage : Page
    {
        public NewQueryPage()
        {
            InitializeComponent();
        }

        private void ClEventCreateClient(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageApp.NewClientPage());
        }
    }
}
