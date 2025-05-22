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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AgentPortal.DB;
using System.Data.Common;

namespace AgentPortal.PageApp
{
    /// <summary>
    /// Логика взаимодействия для QueryListPage.xaml
    /// </summary>
    public partial class QueryListPage : Page
    {
        public static List<Status> statuses { get; set; }
        public static List<Queries> queries { get; set; }
        public QueryListPage()
        {
            InitializeComponent();
            queries = new List<DB.Queries>(ClassDB.connection.Queries.ToList());
            statuses = new List<DB.Status>(ClassDB.connection.Status.ToList());
            this.DataContext = this;
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbSearch.Text != "")
            {
                int searchID = Convert.ToInt32(txbSearch.Text);
                QueryList.ItemsSource = ClassDB.connection.Queries.Where(z => z.ID == searchID).ToList();

            }
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            QueryList.ItemsSource = ClassDB.connection.Queries.Where(z => z.status_id == cmbSort.SelectedIndex + 1).ToList();
        }
    }
}
