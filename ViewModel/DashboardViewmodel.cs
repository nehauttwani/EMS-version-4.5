using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows.Input;
using System.Windows.Media;
using EMS.Entities;
using LiveCharts;
using LiveCharts.Wpf;

namespace EMS.ViewModel
{
    public class DashboardViewmodel : ViewModelBase
    {
        SqlConnectionMethod method = new SqlConnectionMethod();

        //public Func<ChartPoint, string> PointLabel { get; set; }


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
        private SeriesCollection _collection;
        public SeriesCollection Collection
        {
            get { return _collection; }
            set { _collection = value; OnPropertyChanged("Collection"); }
        }
        public string[] Labels { get; set; }

        private ObservableCollection<Designation> designations;
        public ObservableCollection<Designation> Designations
        {
            get { return designations; }
            set { designations = value; OnPropertyChanged("Designations"); }
        }

        private ObservableCollection<Department> departments;
        public ObservableCollection<Department> Departments
        {
            get { return departments; }
            set { departments = value; OnPropertyChanged("Departments"); }
        }

        public void GetDeptDesg()
        {
            //int rowcount = 0;
            List<object> parameters = method.Command("GetDeptDesg");
            SqlConnection sqlConnection = (SqlConnection)parameters[1];
            SqlCommand sqlCommand = (SqlCommand)parameters[0];

            try
            {


                // Open.  
                sqlConnection.Open();

                // Result.  
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Departments.Add(new Department() { DepartmentId = Convert.ToInt32(reader[2]), DepartmentValue = Convert.ToString(reader[3]) });
                        Designations.Add(new Designation() { DesignationId = Convert.ToInt32(reader[0]), DesignationValue = Convert.ToString(reader[1]) });

                        

                    }
                }

                // Close.  
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                // Close.  
                sqlConnection.Close();

                throw ex;
            }
        }
        public void DesgWiseEmp()
        {
            //int rowcount = 0;
            List<double> allValues = new List<double>();
            List<int> allLabels = new List<int>();
            Brush brush1 = new SolidColorBrush(Color.FromRgb(108, 196, 53));
            Brush brush2 = new SolidColorBrush(Color.FromRgb(60, 148, 4));
            List<Brush> allBrush = new List<Brush>{ brush1, brush2};
            int counter = 0;
            List<object> parameters = method.Command("DesgWiseEmp");
            SqlConnection sqlConnection = (SqlConnection)parameters[1];
            SqlCommand sqlCommand = (SqlCommand)parameters[0];

            try
            {


                // Open.  
                sqlConnection.Open();

                // Result.  
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        allLabels.Add(Convert.ToInt32(reader[0]));
                        allValues.Add(Convert.ToDouble(reader[1]));
                    }
                }
                
                
                    foreach (double item in allValues)
                    {
                        PieSeries obj = new PieSeries();

                    obj.Values = new ChartValues<double> { item };
                    foreach (Designation items in Designations)
                    {
                        if(items.DesignationId == allLabels[counter])
                        {
                            obj.Title = items.DesignationValue;
                            obj.Fill = allBrush[counter];
                            obj.Stroke = Brushes.DarkGreen;
                           
                        }
                        

                    }
                    //obj.Stroke = Brushes.Green;
                    //obj.Fill = Brushes.DarkGreen;
                    Collection.Add(obj);
                    counter++;
                }
                    
                    
          

                // Close.  
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                // Close.  
                sqlConnection.Close();

                throw ex;
            }
        }

        public DashboardViewmodel()
        {

            Departments = new ObservableCollection<Department>();
            Designations = new ObservableCollection<Designation>();
            GetDeptDesg();
            Collection = new SeriesCollection();
            DesgWiseEmp();
           

        }


        
    }
}
