using System.Windows.Controls;
using EMS.ViewModel;

namespace EMS.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        DashboardViewmodel dashboardViewmodel;
        public Dashboard()
        {
            InitializeComponent();


            dashboardViewmodel = new DashboardViewmodel();
            this.DataContext = dashboardViewmodel;
        }


        
    }
}
