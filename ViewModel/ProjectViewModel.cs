using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
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

        private Entities.Project alterproject = new Entities.Project();
        public Entities.Project AlterProject
        {
            get { return alterproject; }
            set { alterproject = value; OnPropertyChanged("AlterProject"); }
        }

        private Entities.Project getproject1;
        public Entities.Project GetProject1
        {
            get { return getproject1; }
            set { getproject1 = value; OnPropertyChanged("GetProject1"); }
        }


        private Entities.Project currentproject;
        public Entities.Project CurrentProject
        {
            get { return currentproject; }
            set { currentproject = value; OnPropertyChanged("CurrentProject"); }
        }

        private Entities.Technology currentTechnology;
        public Entities.Technology CurrentTechnology
        {
            get { return currentTechnology; }
            set { currentTechnology = value; OnPropertyChanged("CurrentTechnology"); }
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
        private ObservableCollection<Entities.Technology> projecttechnologies;
        public ObservableCollection<Entities.Technology> ProjectTechnologies
        {
            get
            {
                return projecttechnologies;
            }
            set
            {
                projecttechnologies = value;
                OnPropertyChanged("ProjectTechnologies");
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
                case "Search":
                    Projects = new ObservableCollection<Entities.Project>();
                    SearchProject();
                    break;
                case "Clear":
                    Projects = new ObservableCollection<Entities.Project>();
                    GetProject();
                    CurrentProject = new Entities.Project();
                    break;
                case "edit":
                    ProjectMain = Visibility.Collapsed;
                    ProjectAdd = Visibility.Visible;
                    MappedTechnologyName();
                    CurrentProject.ProjectCode = AlterProject.ProjectCode;
                    CurrentProject.ProjectName = AlterProject.ProjectName;
                    CurrentProject.StartDate = AlterProject.StartDate;
                    CurrentProject.EndDate = AlterProject.EndDate;
                    CurrentProject.ProjectId = AlterProject.ProjectId;
                    OnPropertyChanged("CurrentProject");
                    break;
                case "Remove":
                    MessageBoxResult d;
                    d = MessageBox.Show("Do you want to delete " + AlterProject.ProjectName + " ? ", "Warning", MessageBoxButton.YesNo);
                    if (d == MessageBoxResult.Yes)
                    {
                        RemoveProject(AlterProject);
                        Projects = new ObservableCollection<Entities.Project>();
                        GetProject();
                    }
                    CurrentProject = new Entities.Project();

                    break;
                case "employeeMapping":
                    EmployeeMapping employeeMapping = new EmployeeMapping();
                    GetProject1.ProjectId = AlterProject.ProjectId;
                    GetProject1.ProjectCode = AlterProject.ProjectCode;
                    GetProject1.ProjectName = AlterProject.ProjectName;
                    GetProject1.StartDate = AlterProject.StartDate;
                    GetProject1.EndDate = AlterProject.EndDate;
                    EmploeeMappingViewModel obj = employeeMapping.getemployeemapping();
                    obj.GetProjectObj(GetProject1);
                    obj.GetMappedEmployee(GetProject1);
                    employeeMapping.ShowDialog();
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
                        Entities.Project project = new Entities.Project();
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
                        //Projects.Add(new Entities.Project() { ProjectCode = Convert.ToString(reader[1]), ProjectName = Convert.ToString(reader[2]), StartDate = Convert.ToDateTime(reader[3]), EndDate = Convert.ToDateTime( reader[4]) }) ;
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

        public void MappedTechnologyName()
        {
            //int rowcount = 0;
            string strConn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                // Settings.  
                sqlCommand.CommandText = "MappedTechnologyName";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandTimeout = 108; //// Setting timeeout for longer queries to 12 hours.  
                sqlCommand.Parameters.AddWithValue("@ProjectID", AlterProject.ProjectId);
                // Open.  
                sqlConnection.Open();

                // Result.  
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        CurrentTechnology.TechnologyName = Convert.ToString(reader[0]);
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

        public void SearchProject()

        {
            //int rowcount = 0;
            string strConn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                // Settings.  
                sqlCommand.CommandText = "SearchProject";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandTimeout = 108; //// Setting timeeout for longer queries to 12 hours.  
                sqlCommand.Parameters.AddWithValue("@ProjectName", CurrentProject.ProjectName ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@StartDate", CurrentProject.StartDate.ToString() ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@EndDate", CurrentProject.EndDate.ToString() ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@ProjectCode", CurrentProject.ProjectCode ?? string.Empty);

                // Open.  
                sqlConnection.Open();

                // Result.  
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {


                        Entities.Project project = new Entities.Project();

                        project.ProjectCode = Convert.ToString(reader[0]);
                        project.ProjectName = Convert.ToString(reader[1]);
                        project.StartDate = Convert.ToDateTime(reader[2]);
                        if (reader[3] == DBNull.Value)
                        {
                            project.EndDate = null;
                        }
                        else
                        {

                            project.EndDate = Convert.ToDateTime(reader[3]);
                        }
                        Projects.Add(project);
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


                string strConn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(strConn);
                SqlCommand sqlCommand = new SqlCommand();

                try
                {

                    // Settings.  
                    sqlCommand.CommandText = "SaveEditProjectu";
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
                        sqlCommand.Parameters.AddWithValue("@ProjectCode", CurrentProject.ProjectCode ?? string.Empty);

                        if (CurrentProject.EndDate == null)
                        {
                            sqlCommand.Parameters.AddWithValue("@Enddate", DBNull.Value);
                        }
                        else
                        {
                            sqlCommand.Parameters.AddWithValue("@EndDate", CurrentProject.EndDate);
                        }

                        // Open.  
                        sqlConnection.Open();

                        // Result.

                        SqlDataReader reader = sqlCommand.ExecuteReader();
                        //SqlDataReader reader= sqlCommand.ExecuteReader();
                        if (reader.HasRows)
                            while (reader.Read())
                            {
                                CurrentProject.ProjectId = Convert.ToInt32(reader[0]);
                            }
                        // Close.  
                        sqlConnection.Close();
                        TechnologyMappingAdd();

                        if (CurrentProject.ProjectCode != null)
                        {
                            MessageBox.Show("Project updated successfully", "Congratulations", MessageBoxButton.OK);
                        }
                        else
                        {

                            MessageBox.Show("Project added successfully", "Congratulations", MessageBoxButton.OK);
                        }
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


        public void TechnologyMappingAdd()
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
                    sqlCommand.CommandText = "TechnologyMappingAdd";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = 180;

                    sqlCommand.Parameters.AddWithValue("@ProjectID", CurrentProject.ProjectId);
                    sqlCommand.Parameters.AddWithValue("@TechnologyID", CurrentTechnology.TechnologyID);

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
        public void RemoveProject(Entities.Project obj)
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
                    sqlCommand.CommandText = "RemoveProject";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = 180;

                    sqlCommand.Parameters.AddWithValue("@ProjectCode", obj.ProjectCode);
                    RemoveMappedTechnology();


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

        public void RemoveMappedTechnology()
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
                    sqlCommand.CommandText = "RemoveMappedTechnology";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = 180;

                    sqlCommand.Parameters.AddWithValue("@ProjectCode", AlterProject.ProjectCode);



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

                        ProjectTechnologies.Add(new Entities.Technology() { TechnologyID = Convert.ToInt32(reader[0]), TechnologyName = Convert.ToString(reader[1]) });
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


        public ProjectViewModel()
        {
            CurrentProject = new Entities.Project();
            GetProject1 = new Entities.Project();
            CurrentTechnology = new Entities.Technology();
            Projects = new ObservableCollection<Entities.Project>();
            ProjectTechnologies = new ObservableCollection<Entities.Technology>();
            GetTechnology();
            GetProject();
            ProjectOperations = new RelayCommand(Operations);
        }

    }
}

