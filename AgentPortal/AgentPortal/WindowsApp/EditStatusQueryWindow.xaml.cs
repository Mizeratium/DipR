using AgentPortal.DB;
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
using System.Windows.Shapes;

namespace AgentPortal.WindowsApp
{
    /// <summary>
    /// Логика взаимодействия для EditStatusQueryWindow.xaml
    /// </summary>
    public partial class EditStatusQueryWindow : Window
    {
        public int queryID {  get; set; }
        public string client {  get; set; }
        public EditStatusQueryWindow(Queries query)
        {
            InitializeComponent();
            queryID = query.ID;
            //ссылка не указывает на экземпляр объекта
            //lbClient.Content = ClassDB.connection.Client.Where(z => z.application_id == queryID).FirstOrDefault().surname.ToString();
            lbCity.Content = "г. " + query.city + " ул. " + query.street + " д. " + query.house + " кв. " + query.apartment;
        }

        private void ClEventSave(object sender, RoutedEventArgs e)
        {
            Queries query = ClassDB.connection.Queries.Where(z => z.ID == queryID).FirstOrDefault();
            query.comment = txbComment.Text;
            this.Close();
        }

        private void ClEventGoBack(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
