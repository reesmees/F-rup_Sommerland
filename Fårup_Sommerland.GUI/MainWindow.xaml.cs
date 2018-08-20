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
using Fårup_Sommerland.Entities;
using Fårup_Sommerland.DBAccess;

namespace Fårup_Sommerland.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DataAccess DataAccess = new DataAccess(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Fårup_SommerlandDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public MainWindow()
        {
            InitializeComponent();
            dgRides.ItemsSource = DataAccess.GetAllRides();
        }

        private void dgRides_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tblkBreakdownNumber.Text = "";
            tblkCategory.Text = "";
            tblkDaysSinceBreakdown.Text = "";
            tblkName.Text = "";
            tblkStatus.Text = "";

            Ride r = (dgRides.SelectedItem as Ride);
            tblkName.Text = r.Name;
            tblkStatus.Text = r.Status.ToString();
            tblkCategory.Text = r.Category.ToString();
            tblkBreakdownNumber.Text = r.NumberOfShutdowns().ToString();
            tblkDaysSinceBreakdown.Text = r.DaysSinceLastShutdown().ToString();
        }
    }
}
