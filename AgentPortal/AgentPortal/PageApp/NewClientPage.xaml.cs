using AgentPortal.ClassApp;
using AgentPortal.DB;
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
using static System.Net.Mime.MediaTypeNames;

namespace AgentPortal.PageApp
{
    /// <summary>
    /// Логика взаимодействия для NewClientPage.xaml
    /// </summary>
    public partial class NewClientPage : Page
    {
        //public static Queries newQuery { get; set; }
        public int queryID = 0;
        public NewClientPage(Queries query)
        {
            InitializeComponent();
            queryID = query.ID;
            //newQuery = query;
            // Устанавливаем начальное значение для текстового поля с номером телефона
            txbPhone.Text = "+79";
            txbPhone.SelectionStart = txbPhone.Text.Length;

            this.DataContext = this;
        }

        private void txbPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, @"^[0-9]+$"))
            {
                e.Handled = true; // Отменяем ввод, если это не цифра
            }
        }

        private void txbPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!txbPhone.Text.StartsWith("+79"))
            {
                txbPhone.Text = "+79";
                txbPhone.SelectionStart = txbPhone.Text.Length;
            }
            if (txbPhone.Text.Length > 12)
            {
                // Обрезаем текст до 12 символов b gthtvtoftv rehcjh d rjytw cnhjrb
                txbPhone.Text = txbPhone.Text.Substring(0, 12);
                txbPhone.CaretIndex = txbPhone.Text.Length;
            }
        }

        // Метод для получения полного номера телефона
        public string GetPhoneNumber()
        {
            return txbPhone.Text;
        }
         
        private void ClEventSave(object sender, RoutedEventArgs e)
        {
            if (txbSurname.Text != "" && txbName.Text != "" && txbPatronymic.Text != "" && txbPhone.Text.Length <13) //Проверка на ввод данных
            { 
                Client client = new Client();
                client.surname = txbSurname.Text;
                client.name = txbName.Text;
                client.patronymic = txbPatronymic.Text;
                client.phone = GetPhoneNumber();
                client.application_id = queryID; //Требуется найти ID адреса и заменить единицу на него
                ClassDB.connection.Client.Add(client);
                ClassDB.connection.SaveChanges();
                MessageBox.Show($"Заявка успешно добавлена\nНомер заявки {queryID}");
                NavigationService.Navigate(new PageApp.NewQueryPage());

                //client.application_id = ClassApp.CurrentClass.CurrentAdress.ID;
                //client.application_id = ClassDB.connection.Queries.Where(z => z.ID == )
            }
        }
    }
}
