using AgentPortal.DB;
using AgentPortal.WindowsApp;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
    /// Логика взаимодействия для AgentListPage.xaml
    /// </summary>
    public partial class AgentListPage : Page
    {
        public static List<Employee> agents {  get; set; }
        public AgentListPage()
        {
            InitializeComponent();
            agents = new List<DB.Employee>(ClassDB.connection.Employee.ToList());
            AgentList.ItemsSource = ClassDB.connection.Employee.ToList();
        }

        private void AgentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var employee = AgentList.SelectedItem as Employee;
            EditAgentWindow win = new EditAgentWindow(employee);
            win.Show();
        }

        private void ClEventAddNewAgent(object sender, RoutedEventArgs e)
        {
            NewAgentWindow win = new NewAgentWindow();
            win.Show();
        }

        private void ClEventDeleteAgent(object sender, RoutedEventArgs e)
        {
            var _sel = AgentList.SelectedItem as Employee;
            //реализовать удаление пользователя из бд
            //ClassDB.connection.User.Remove(ClassDB.connection.Employee.Where(z => z.ID == _sel.ID));
            ClassDB.connection.User.Remove(ClassDB.connection.User.Where(z => z.ID == _sel.ID).FirstOrDefault()); //должно сработать
            //удаление работника после удаления его аккаунта
            ClassDB.connection.Employee.Remove(_sel);
            ClassDB.connection.SaveChanges();
            AgentList.ItemsSource = ClassDB.connection.Employee.ToList();
        }
    }
}
