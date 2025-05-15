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
    /// Логика взаимодействия для NewClientPage.xaml
    /// </summary>
    public partial class NewClientPage : Page
    {
        public NewClientPage()
        {
            InitializeComponent();
            // Устанавливаем начальное значение для текстового поля с номером телефона
            txbPhone.Text = "+79";
            txbPhone.SelectionStart = txbPhone.Text.Length;
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
        }

        // Метод для получения полного номера телефона
        public string GetPhoneNumber()
        {
            return txbPhone.Text;
        }
         
        private void ClEventSave(object sender, RoutedEventArgs e)
        {

        }
    }
}
