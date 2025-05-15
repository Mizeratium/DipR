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

namespace AgentPortal.PageApp
{
    /// <summary>
    /// Логика взаимодействия для QueryListPage.xaml
    /// </summary>
    public partial class QueryListPage : Page
    {
        public static List<Queries> queries { get; set; }
        public QueryListPage()
        {
            InitializeComponent();
            queries = new List<DB.Queries>(ClassDB.connection.Queries.ToList());
            this.DataContext = this;
        }
    }
}
