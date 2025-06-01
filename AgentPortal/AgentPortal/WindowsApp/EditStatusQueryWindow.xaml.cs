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
        public List<Client> clients {  get; set; }
        public EditStatusQueryWindow(Queries query)
        {
            InitializeComponent();
            queryID = query.ID;
            var client = ClassDB.connection.Client.FirstOrDefault(z => z.application_id == queryID);
            if (client != null)
            {
                lbClient.Content = $"{client.surname} {client.name} {client.patronymic}";
            }
            else
            {
                lbClient.Content = "Клиент не найден";
            }
            var comment = ClassDB.connection.Queries.FirstOrDefault(z => z.ID == queryID);
            if (comment != null)
            {
                txbComment.Text = $"{comment.comment}";
            }
            lbCity.Content = "г. " + query.city + " ул. " + query.street + " д. " + query.house + " кв. " + query.apartment;
        }

        private void ClEventSave(object sender, RoutedEventArgs e)
        {
            Queries query = ClassDB.connection.Queries.Where(z => z.ID == queryID).FirstOrDefault();
            query.comment = txbComment.Text;
            ClassDB.connection.SaveChanges();
            this.Close();
        }

        private void ClEventGoBack(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
