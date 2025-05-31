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
using AgentPortal.ClassApp;
using AgentPortal.DB;
using static System.Net.Mime.MediaTypeNames;

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

        //Создание заявки, переход на страницу с добавлением контрагента
        private void ClEventCreateClient(object sender, RoutedEventArgs e)
        {
            if (txbCity.Text != "" && txbStreet.Text != "" && txbHouse.Text != "") //Проверка на ввод данных
            {
                Queries query = new Queries();
                query.city = txbCity.Text;
                query.street = txbStreet.Text;
                query.house = int.Parse(txbHouse.Text);
                query.tariff_id = (cmbTariff.SelectedItem as Tariff).ID;
                query.staff_id = (cmbStaff.SelectedItem as Staff).ID;
                //query.employee_id = Convert.ToInt32(ClassApp.CurrentClass.CurrentEmployee.user_id); //Заявка фиксируется за конкретным агентом и будет видна только ему
                query.employee_id = CurrentClass.CurrentEmployee.user_id; //Заявка фиксируется за конкретным агентом и будет видна только ему
                query.status_id = 1; //Автоматически задаем статус "Заявка создана"
                if (txbApartment.Text != "" && chkHouse.IsChecked == false) //Проверка на ввод
                {
                    query.apartment = int.Parse(txbApartment.Text);
                    ClassDB.connection.Queries.Add(query);
                    ClassDB.connection.SaveChanges();


                    NavigationService.Navigate(new PageApp.NewClientPage(query));
                }
                else //Если это частный дом, сохраняется заявка без квартиры
                {
                    ClassDB.connection.Queries.Add(query);
                    ClassDB.connection.SaveChanges();
                    NavigationService.Navigate(new PageApp.NewClientPage(query));
                }
            }
            else
            {
                MessageBox.Show("Неккоректный адрес", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
