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


        //private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        //{
        //    var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

        //    //clear selected slice.
        //    foreach (PieSeries series in chart.Series)
        //        series.PushOut = 0;

        //    var selectedSeries = (PieSeries)chartpoint.SeriesView;
        //    selectedSeries.PushOut = 8;
        //}
    }
}
