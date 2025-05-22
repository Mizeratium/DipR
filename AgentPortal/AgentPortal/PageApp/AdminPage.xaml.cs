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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void ClEventShowSales(object sender, RoutedEventArgs e)
        {
            NavigateFrame.NavigationService.Navigate(new PageApp.SaleListPage());
        }

        private void ClEventShowEmployeers(object sender, RoutedEventArgs e)
        {
            NavigateFrame.NavigationService.Navigate(new PageApp.AgentListPage());
        }

        private void ClEventGoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageApp.AutoPage());
        }
    }
}
