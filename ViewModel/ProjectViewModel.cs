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
using System.Windows.Controls;
using EMS.Entities;
using EMS.Views;

namespace EMS.ViewModel
{
    public class ProjectViewModel : ViewModelBase
    {
        private Visibility projectMain = Visibility.Visible;
        public Visibility ProjectMain
        {
            get
            {
                return projectMain;
            }
            set
            {
                projectMain = value;
                OnPropertyChanged("ProjectMain");
            }
        }
        private Visibility projectadd = Visibility.Collapsed;
        public Visibility ProjectAdd
        {
            get
            {
                return projectadd;
            }
            set
            {
                projectadd = value;
                OnPropertyChanged("ProjectAdd");
            }
        }



        private Entities.Project currentproject;

        public Entities.Project CurrentProject
        {
            get { return currentproject; }
            set { currentproject = value; OnPropertyChanged("CurrentProject"); }
        }
        private ObservableCollection<Entities.Project> projects;
        public ObservableCollection<Entities.Project> Projects
        {
            get
            {
                return projects;
            }
            set
            {
                projects = value;
                OnPropertyChanged("Projects");
            }

        }
        public RelayCommand ProjectOperations { get; set; }

        void Operations(object parameter)
        {
            switch (parameter)
            {
                case "AddProject":
                    ProjectMain = Visibility.Collapsed;
                    ProjectAdd = Visibility.Visible;
                    break;
                case "SaveProject":
                    SaveEditProject();
                    
                    Projects = new ObservableCollection<Entities.Project>();
                    GetProject();
                    CurrentProject = new Entities.Project();
                    break;
                case "Cancel":
                    ProjectMain = Visibility.Visible;
                    ProjectAdd = Visibility.Collapsed;
                    break;

            }
        }



        /////PROJECT MAIN WINDOW CONTENT///
        public void GetProject()
        {
            //int rowcount = 0;
            string strConn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                // Settings.  
                sqlCommand.CommandText = "GetProject";
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

                        Projects.Add(new Entities.Project() { ProjectCode = Convert.ToString(reader[1]), ProjectName = Convert.ToString(reader[2]), StartDate = Convert.ToDateTime(reader[3]), EndDate = Convert.ToDateTime(reader[4]) });
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

        public void SaveEditProject()
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
                    sqlCommand.CommandText = "SaveEditProject";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = 180;
                    if (CurrentProject.ProjectName == "")
                    {
                        string message = "The Project Name cannot be empty!";
                        MessageBox.Show(message, "Warning", MessageBoxButton.OK);

                    }
                    else
                    {
                        
                        sqlCommand.Parameters.AddWithValue("@ProjectName", CurrentProject.ProjectName);
                        sqlCommand.Parameters.AddWithValue("@StartDate", CurrentProject.StartDate);
                        sqlCommand.Parameters.AddWithValue("@EndDate", CurrentProject.EndDate);



                        // Open.  
                        sqlConnection.Open();

                        // Result.

                        rowCount = sqlCommand.ExecuteNonQuery();

                        // Close.  
                        sqlConnection.Close();
                        MessageBox.Show("Project added successfully", "Congratulations", MessageBoxButton.OK);
                        ProjectMain = Visibility.Visible;
                        ProjectAdd = Visibility.Collapsed;
                    }
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

        public ProjectViewModel()
        {
            CurrentProject = new Entities.Project();

            Projects = new ObservableCollection<Entities.Project>();

            GetProject();
            ProjectOperations = new RelayCommand(Operations);
        }

    }
}

