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
using AgentPortal.DB;

namespace AgentPortal.PageApp
{
    /// <summary>
    /// Логика взаимодействия для NewQueryPage.xaml
    /// </summary>
    public partial class NewQueryPage : Page
    {
        public static List<Tariff> tarrifs { get; set; }
        public static List<Staff> staffs { get; set; }
        public NewQueryPage()
        {
            InitializeComponent();
            tarrifs = new List<Tariff>(ClassDB.connection.Tariff.ToList());
            staffs = new List<Staff>(ClassDB.connection.Staff.ToList());
            this.DataContext = this;
        }

        private void ClEventCreateClient(object sender, RoutedEventArgs e)
        {
            if (txbCity.Text != "" && txbStreet.Text != "" && txbHouse.Text != "") //Проверка на ввод данных
            {
                Queries query = new Queries();
                query.city = txbCity.Text;
                query.street = txbStreet.Text;
                query.house = int.Parse(txbHouse.Text);
                if (txbApartment.Text != "" && chkHouse.IsChecked == false) //Есть вписана кв
                {
                    query.apartment = int.Parse(txbApartment.Text);
                    NavigationService.Navigate(new PageApp.NewClientPage());
                }
                else
                {
                    NavigationService.Navigate(new PageApp.NewClientPage());
                }
            }
            else
            {
                MessageBox.Show("Неккоректный адрес", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
