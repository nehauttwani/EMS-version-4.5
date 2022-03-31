using System;
using System.Windows.Input;
using LiveCharts;
using LiveCharts.Wpf;

namespace EMS.ViewModel
{
    public class DashboardViewmodel : ViewModelBase
    {
        public Func<ChartPoint, string> PointLabel { get; set; }
        public ICommand DrillDownCommand
        {
            get
            {
                return new RelayCommand<ChartPoint>(this.OnDrillDownCommand);
            }
        }

        //public SeriesCollection MySeries
        //{
        //    get
        //    {
        //        var seriesCollection = new SeriesCollection(mapper);

        //        seriesCollection.Add(new PieSeries()
        //        {
        //            Title = "My display name",
        //            Values = new ChartValues<YourObjectHere>(new[] { anInstanceOfYourObjectHere })
        //        });

        //        return seriesCollection;
        //    }
        //}
        private void OnDrillDownCommand(ChartPoint chartPoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartPoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartPoint.SeriesView;
            selectedSeries.PushOut = 8;
        }


        public DashboardViewmodel()
        {
            PointLabel = chartPoint =>
             string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            //DashboardOperations = new RelayCommand(Operations);
        }

        private class RelayCommand<T> : ICommand
        {
            private Action<ChartPoint> onDrillDownCommand;

            public RelayCommand(Action<ChartPoint> onDrillDownCommand)
            {
                this.onDrillDownCommand = onDrillDownCommand;
            }

#pragma warning disable CS0067 // The event 'DashboardViewmodel.RelayCommand<T>.CanExecuteChanged' is never used
            public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067 // The event 'DashboardViewmodel.RelayCommand<T>.CanExecuteChanged' is never used

            public bool CanExecute(object parameter)
            {
                throw new NotImplementedException();
            }

            public void Execute(object parameter)
            {
                throw new NotImplementedException();
            }
        }
    }
}
