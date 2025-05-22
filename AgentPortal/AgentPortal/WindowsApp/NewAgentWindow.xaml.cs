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
using System.Windows.Shapes;

namespace AgentPortal.WindowsApp
{
    /// <summary>
    /// Логика взаимодействия для NewAgentWindow.xaml
    /// </summary>
    public partial class NewAgentWindow : Window
    {
        public NewAgentWindow()
        {
            InitializeComponent();
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

        private void ClEventAdd(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.login = txbLogin.Text;
            user.password = txbPassword.Text;
            user.role_id = 1;
            Employee employee = new Employee();
            employee.surname = txbSurname.Text;
            employee.name = txbName.Text;
            employee.patronymic = txbPatronymic.Text;
            employee.phone = txbPhone.Text;
            employee.user_id = user.ID;
             //добавить картинку по умолчанию
            MessageBox.Show("Агент успешно добавлен");
            this.Close();
        }

        private void ClEventGoBack(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
