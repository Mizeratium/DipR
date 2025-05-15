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
    /// Логика взаимодействия для AppListPage.xaml
    /// </summary>
    public partial class AppListPage : Page
    {
        public AppListPage()
        {
            InitializeComponent();
        }

        private void ClEventNewQuery(object sender, RoutedEventArgs e)
        {
            NavigateFrame.Navigate(new PageApp.NewQueryPage());
        }

        private void ClEventQueryList(object sender, RoutedEventArgs e)
        {
            NavigateFrame.Navigate(new PageApp.QueryListPage());
        }

        private void ClEventProfile(object sender, RoutedEventArgs e)
        {
            NavigateFrame.Navigate(new PageApp.ProfilePage());
        }

        private void ClEventLogout(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageApp.AutoPage());
        }
    }
}
