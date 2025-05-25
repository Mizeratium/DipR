using AgentPortal.DB;
using AgentPortal.WindowsApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для SaleListPage.xaml
    /// </summary>
    public partial class SaleListPage : Page
    {
        public static List<Queries> sales { get; set; }
        public static List<Employee> agents { get; set; }
        public static List<Status> status { get; set; }
        public SaleListPage()
        {
            InitializeComponent();
            sales = new List<DB.Queries>(ClassDB.connection.Queries.ToList());
            agents = new List<DB.Employee>(ClassDB.connection.Employee.ToList());
            status = new List<DB.Status>(ClassDB.connection.Status.ToList());
            SaleList.ItemsSource = ClassDB.connection.Queries.ToList();
            this.DataContext = this;
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        public void Refresh()
        {
            var status = cmbStatus.SelectedItem as Status;
            sales = new List<DB.Queries>(ClassDB.connection.Queries.ToList());
            //поиск по строке
            if (txbSearch.Text != "")
            {
                int searchID = int.Parse(txbSearch.Text);
                SaleList.ItemsSource = ClassDB.connection.Queries.Where(z => z.ID == searchID).ToList();
                //SaleList.ItemsSource = ClassDB.connection.Queries.Where(z => z.ID == int.Parse(txbSearch.Text)).ToList();
            }
            //Обнуление поиска по условиям
            else
            {
                SaleList.ItemsSource = ClassDB.connection.Queries.ToList();
            }
            //фильтрация по агенту
            if (cmbAgent.SelectedItem != null)
            {
                SaleList.ItemsSource = ClassDB.connection.Queries.Where(z => z.employee_id == cmbAgent.SelectedIndex + 1).ToList();
            }
            //сортировка по статусу заявки
            if (cmbStatus.SelectedItem != null)
            {
                SaleList.ItemsSource = sales.Where(z => z.status_id == status.ID).ToList();
            }
            if (cmbAgent.SelectedItem != null && cmbStatus.SelectedItem != null)
            {
                SaleList.ItemsSource = ClassDB.connection.Queries.Where(z => z.employee_id == cmbAgent.SelectedIndex + 1 && z.status_id == status.ID).ToList();
            }
        }

        private void cmbAgent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void cmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        //Редактирование существующей заявки
        private void SaleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var query = SaleList.SelectedItem as Queries;
            EditStatusQueryWindow win = new EditStatusQueryWindow(query);
            win.Show();
        }
    }
}
