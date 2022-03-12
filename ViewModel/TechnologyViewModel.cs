using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EMS.Entities;

namespace EMS.ViewModel
{
    public class TechnologyViewModel : ViewModelBase
    {
        private Technology currenttechnology;
        public Technology CurrentTechnology
        {
            get { return currenttechnology; }
            set { currenttechnology = value; OnPropertyChanged("CurrentTechnology"); }
        }
        private Technology altertechnology;
        public Technology AlterTechnology
        {
            get { return altertechnology; }
            set { altertechnology = value; OnPropertyChanged("AlterTechnology"); }
        }
        
        private ObservableCollection<Technology> technologies;
        public ObservableCollection<Technology> Technologies
        {
            get
            {
                return technologies;
            }
            set
            {
                technologies = value;
                OnPropertyChanged("Technologies");
            }

        }

        public RelayCommand TechnologyOperations { get; set; }

        void Operations(object parameter)
        {
            if (parameter.ToString() == "SaveEditOperation")
            {

                    SaveEditOperation();
                    Technologies = new ObservableCollection<Technology>();
                    GetTechnology();
                    CurrentTechnology = new Technology();

                

            }
            else if(parameter.ToString() == "EditTechnology")
            {
                CurrentTechnology.TechnologyID = AlterTechnology.TechnologyID;
                CurrentTechnology.TechnologyName = AlterTechnology.TechnologyName;

                OnPropertyChanged("CurrentTechnology");
            }
            else if(parameter.ToString() == "DeleteTechnology")
            {
                MessageBoxResult d;
                d =MessageBox.Show("Do you want to delete this Technology?", "Warning", MessageBoxButton.YesNo);
                if(d== MessageBoxResult.Yes)
                {
                    DeleteTechnology(AlterTechnology);
                    Technologies = new ObservableCollection<Technology>();
                    GetTechnology();
                }
                CurrentTechnology = new Technology();

            }
            
        }

        public void GetTechnology()
        {
            //int rowcount = 0;
            string strConn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                // Settings.  
                sqlCommand.CommandText = "GetTechnology";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandTimeout = 108; //// Setting timeeout for longer queries to 12 hours.  

                // Open.  
                sqlConnection.Open();

                // Result.  
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Technologies.Add(new Technology() { TechnologyID = Convert.ToInt32(reader[0]), TechnologyName = Convert.ToString(reader[1]) });
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

        
        public void SaveEditOperation()
        {
            try
            {

            int rowCount = 0;
            string strConn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();

                try
                {

                    // Settings.  
                    sqlCommand.CommandText = "SaveEditOperation";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = 180;
                    if (CurrentTechnology.TechnologyName == "")
                    {
                        string message = "The required field cannot be empty!";
                        MessageBox.Show(message, "Warning", MessageBoxButton.OK);

                    }
                    else
                    {
                        SqlParameter technologyName = new SqlParameter("@TechnologyName", SqlDbType.VarChar, 50)
                        {
                            Value = CurrentTechnology.TechnologyName
                        };
                        SqlParameter technologyId = new SqlParameter("@TechnologyID", SqlDbType.Int)
                        {
                            Value = CurrentTechnology.TechnologyID
                        };
                        sqlCommand.Parameters.Add(technologyName);
                        sqlCommand.Parameters.Add(technologyId);


                        // Open.  
                        sqlConnection.Open();

                        // Result.

                        rowCount = sqlCommand.ExecuteNonQuery();

                        // Close.  
                        sqlConnection.Close();
                    }
                }
                catch (Exception ex)
                {
                    // Close.  
                    sqlConnection.Close();

                    throw ex;
                }

            }catch
            {
                string message = "The required field cannot be empty!";
                MessageBox.Show(message, "Warning", MessageBoxButton.OK);
            }
        }

      

        public void DeleteTechnology(Technology obj)
        {
            try
            {

                int rowCount = 0;
                string strConn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(strConn);
                SqlCommand sqlCommand = new SqlCommand();

                try
                {

                    // Settings.  
                    sqlCommand.CommandText = "RemoveTechnology";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = 180;
                    SqlParameter technologyName = new SqlParameter("@TechnologyName", SqlDbType.VarChar, 50)

                    {
                        Value = obj.TechnologyName
                    };
                    
                    sqlCommand.Parameters.Add(technologyName);



                    // Open.  
                    sqlConnection.Open();

                    // Result.

                    rowCount = sqlCommand.ExecuteNonQuery();

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
            catch
            {
                string message = "The required field cannot be empty!";
                MessageBox.Show(message, "Warning", MessageBoxButton.OK);
            }
        }
        public TechnologyViewModel()
        {
            CurrentTechnology = new Technology();
            AlterTechnology = new Technology();
            Technologies = new ObservableCollection<Technology>();
            TechnologyOperations = new RelayCommand(Operations);
            GetTechnology();
        }
    }
}
