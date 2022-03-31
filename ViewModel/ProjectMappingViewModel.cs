using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using EMS.Entities;

namespace EMS.ViewModel
{
    public class ProjectMappingViewModel : ViewModelBase
    {
        SqlConnectionMethod method = new SqlConnectionMethod();
        private ObservableCollection<Project> _projects;
        public ObservableCollection<Project> Projects
        {
            get { return _projects; }
            set { _projects = value; OnPropertyChanged("Projects"); }
        }

        private ObservableCollection<Project> filteredprojects;
        public ObservableCollection<Project> FilteredProjects
        {
            get { return filteredprojects; }
            set { filteredprojects = value; OnPropertyChanged("FilteredProjects"); }
        }

        private ObservableCollection<Project> mappedProjects;
        public ObservableCollection<Project> MappedProjects
        {
            get { return mappedProjects; }
            set { mappedProjects = value; OnPropertyChanged("MappedProjects"); }
        }

        private Project currentProject;
        public Project CurrentProject
        {
            get { return currentProject; }
            set { currentProject = value; OnPropertyChanged("CurrentProject"); }
        }

        private Project selectedProject;
        public Project SelectedProject
        {
            get { return selectedProject; }
            set { selectedProject = value; OnPropertyChanged("SelectedProject"); }
        }
        private EmployeeDetails _employee = new EmployeeDetails();
        public EmployeeDetails Employee
        {
            get { return _employee; }
            set { _employee = value; OnPropertyChanged("Employee"); }
        }

        private string _SearchText;
        public string SearchText
        {
            get { return _SearchText; }
            set
            {
                if (CurrentProject.ProjectName != null)
                {
                    _SearchText = CurrentProject.ProjectName;
                    FilteredProjects = Projects;
                    //GetEmployee();
                    CurrentProject.ProjectName = null;
                    return;
                }
                FilteredProjects.Clear();
                this._SearchText = value;
                OnPropertyChanged("SearchText");
                foreach (Project obj in Projects)
                {

                    if (obj.ProjectName.ToLower().Contains(SearchText.ToLower()))
                    {
                        FilteredProjects.Add(obj);
                    }
                }

            }
        }
        public RelayCommand MappingOperations { get; set; }

        void Operations(object parameter)
        {
            switch (parameter)
            {
                case "EmployeeMap":
                    EmployeeMap();
                    MappedProjects = new ObservableCollection<Project>();
                    GetMappedProject(Employee);

                    break;
                case "deleteEx":
                    MessageBoxResult d;
                    d = MessageBox.Show("Do you want to deallocate " + SelectedProject.ProjectName + " from " + Employee.FullName + " ?", "Warning", MessageBoxButton.YesNo);
                    if (d == MessageBoxResult.Yes)
                    {

                        RemoveMapping();
                        MappedProjects = new ObservableCollection<Project>();
                        GetMappedProject(Employee);
                    }

                    break;
            }
        }
        public void GetEmployeeObj(EmployeeDetails obj)
        {
            Employee.EmployeeID = obj.EmployeeID;
            Employee.EmployeeCode = obj.EmployeeCode;
            Employee.FirstName = obj.FirstName;
            Employee.LastName = obj.LastName;


        }
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
                        Project project = new Project();
                        project.ProjectId = Convert.ToInt32(reader[0]);
                        project.ProjectCode = Convert.ToString(reader[1]);
                        project.ProjectName = Convert.ToString(reader[2]);
                        project.StartDate = Convert.ToDateTime(reader[3]);
                        if (reader[4] == DBNull.Value)
                        {
                            project.EndDate = null;
                        }
                        else
                        {

                            project.EndDate = Convert.ToDateTime(reader[4]);
                        }
                        Projects.Add(project);
                        FilteredProjects.Add(project);

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

        public void GetMappedProject(EmployeeDetails employee)
        {

            //int rowcount = 0;
            List<object> parameters = method.Command("GetMappedProject");
            SqlConnection sqlConnection = (SqlConnection)parameters[1];
            SqlCommand sqlCommand = (SqlCommand)parameters[0];
            try
            {
                sqlCommand.Parameters.AddWithValue("@EmployeeiD", Employee.EmployeeID);
                // Open.  
                sqlConnection.Open();

                // Result.  
                SqlDataReader reader = sqlCommand.ExecuteReader();



                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        Project newproject = new Project();
                        {

                            newproject.ProjectId = Convert.ToInt32(reader[0]);
                            newproject.ProjectName = Convert.ToString(reader[1]);



                        };
                        MappedProjects.Add(newproject);



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
        public void EmployeeMap()
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
                    sqlCommand.CommandText = "EmployeeMap";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = 180;

                    sqlCommand.Parameters.AddWithValue("@ProjectID", CurrentProject.ProjectId);
                    sqlCommand.Parameters.AddWithValue("@EmployeeID", Employee.EmployeeID);

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
        public void RemoveMapping()
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
                    sqlCommand.CommandText = "RemoveMapping";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = 180;

                    sqlCommand.Parameters.AddWithValue("@ProjectID", SelectedProject.ProjectId);
                    sqlCommand.Parameters.AddWithValue("@EmployeeID", Employee.EmployeeID);

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

        public ProjectMappingViewModel()
        {
            CurrentProject = new Project();
            MappedProjects = new ObservableCollection<Project>();
            MappingOperations = new RelayCommand(Operations);
            Projects = new ObservableCollection<Project>();
            FilteredProjects = new ObservableCollection<Project>();

            GetProject();

        }
    }
}
