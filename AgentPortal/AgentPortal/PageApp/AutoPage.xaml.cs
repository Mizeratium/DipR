using AgentPortal.ClassApp;
using AgentPortal.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        public AutoPage()
        {
            InitializeComponent();
        }

        private void ClEventAuto(object sender, RoutedEventArgs e)
        {
            try
            {
                var _sel = ClassDB.connection.User.Where(z => z.login == txbLogin.Text && z.password == txbPassword.Text).FirstOrDefault();
                if (_sel != null)
                {
                    if (_sel.role_id == 1)
                    {
                        CurrentClass.CurrentEmployee = ClassDB.connection.Employee.Where(z => z.user_id == _sel.ID).FirstOrDefault(); //запоминаем пользователя который вошел в систему
                        NavigationService.Navigate(new PageApp.AppListPage()); //Agent
                    }
                    else if (_sel.role_id == 2)
                    {
                        NavigationService.Navigate(new PageApp.AdminPage()); //Admin
                    }

                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
