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
    public class EmploeeMappingViewModel : ViewModelBase
    {
        SqlConnectionMethod method = new SqlConnectionMethod();

        private ObservableCollection<EmployeeDetails> employees;
        public ObservableCollection<EmployeeDetails> Employees
        {
            get { return employees; }
            set { employees = value; OnPropertyChanged("Employees"); }
        }

        private ObservableCollection<EmployeeDetails> mappedemployees;
        public ObservableCollection<EmployeeDetails> MappedEmployees
        {
            get { return mappedemployees; }
            set { mappedemployees = value; OnPropertyChanged("MappedEmployees"); }
        }

        private ObservableCollection<EmployeeDetails> filteredemployees;
        public ObservableCollection<EmployeeDetails> FilteredEmployees
        {
            get { return filteredemployees; }
            set { filteredemployees = value; OnPropertyChanged("FilteredEmployees"); }
        }
        private EmployeeDetails currentemployee;
        public EmployeeDetails CurrentEmployee
        {
            get { return currentemployee; }
            set { currentemployee = value; OnPropertyChanged("CurrentEmployee"); }
        }

        private EmployeeDetails selectedemployee;
        public EmployeeDetails SelectedEmployee
        {
            get { return selectedemployee; }
            set { selectedemployee = value; OnPropertyChanged("SelectedEmployee"); }
        }

        private string _SearchText;
        public string SearchText
        {
            get { return _SearchText; }
            set
            {
                if (CurrentEmployee.FullName != " ")
                {
                    _SearchText = CurrentEmployee.FullName;
                    FilteredEmployees = Employees;
                    //GetEmployee();
                    CurrentEmployee.FullName = " ";
                    return;
                }
                FilteredEmployees.Clear();
                this._SearchText = value;
                OnPropertyChanged("SearchText");

                foreach (EmployeeDetails employeeDetails in Employees)
                {

                    if (employeeDetails.FullName.ToLower().Contains(SearchText.ToLower()))
                    {
                        FilteredEmployees.Add(employeeDetails);
                    }
                }
                //CurrentEmployee.FullName = " ";



            }
        }
        private Project _project = new Project();
        public Project Project
        {
            get { return _project; }
            set { _project = value; OnPropertyChanged("Project"); }
        }


        // --------------------------------  functions ----------------------------------

        public RelayCommand MappingOperations { get; set; }

        void Operations(object parameter)
        {
            switch (parameter)
            {
                case "EmployeeMap":
                    EmployeeMap();
                    MappedEmployees = new ObservableCollection<EmployeeDetails>();
                    GetMappedEmployee(Project);

                    break;
                case "deleteQual":
                    MessageBoxResult d;
                    d = MessageBox.Show("Do you want to remove " + SelectedEmployee.FullName + " from " + Project.ProjectName + " ?", "Warning", MessageBoxButton.YesNo);
                    if (d == MessageBoxResult.Yes)
                    {

                        RemoveMapping();
                        MappedEmployees = new ObservableCollection<EmployeeDetails>();
                        GetMappedEmployee(Project);
                    }

                    break;
            }
        }
        public void GetProjectObj(Project obj)
        {
            Project.ProjectId = obj.ProjectId;
            Project.ProjectCode = obj.ProjectCode;
            Project.ProjectName = obj.ProjectName;
            Project.StartDate = obj.StartDate;
            Project.EndDate = obj.EndDate;
        }

        public void GetEmployee()
        {

            //int rowcount = 0;
            List<object> parameters = method.Command("GetEmployee");
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
                        EmployeeDetails employeedetails = new EmployeeDetails
                        {
                            Department = new Department(),
                            Designation = new Designation(),
                            EmployeeID = Convert.ToInt32(reader[0]),
                            EmployeeCode = Convert.ToString(reader[1]),
                            FirstName = Convert.ToString(reader[2]),
                            LastName = Convert.ToString(reader[3]),
                            Email = Convert.ToString(reader[4]),

                            JoiningDate = Convert.ToDateTime(reader[8])
                        };

                        if (reader[9] == DBNull.Value)
                        {
                            employeedetails.ReleaseDate = null;
                        }
                        else
                        {

                            employeedetails.ReleaseDate = Convert.ToDateTime(reader[9]);
                        }
                        employeedetails.Department.DepartmentValue = Convert.ToString(reader[11]);
                        employeedetails.Designation.DesignationValue = Convert.ToString(reader[13]);
                        Employees.Add(employeedetails);
                        FilteredEmployees.Add(employeedetails);

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

        public void GetMappedEmployee(Project project)
        {

            //int rowcount = 0;
            List<object> parameters = method.Command("GetMappedEmployee");
            SqlConnection sqlConnection = (SqlConnection)parameters[1];
            SqlCommand sqlCommand = (SqlCommand)parameters[0];
            try
            {
                sqlCommand.Parameters.AddWithValue("@ProjectID", project.ProjectId);
                // Open.  
                sqlConnection.Open();

                // Result.  
                SqlDataReader reader = sqlCommand.ExecuteReader();



                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        EmployeeDetails employeedetails = new EmployeeDetails
                        {

                            FirstName = Convert.ToString(reader[0]),
                            LastName = Convert.ToString(reader[1]),
                            EmployeeID = Convert.ToInt32(reader[3])


                        };
                        MappedEmployees.Add(employeedetails);



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

                    sqlCommand.Parameters.AddWithValue("@ProjectID", Project.ProjectId);
                    sqlCommand.Parameters.AddWithValue("@EmployeeID", CurrentEmployee.EmployeeID);

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

                    sqlCommand.Parameters.AddWithValue("@ProjectID", Project.ProjectId);
                    sqlCommand.Parameters.AddWithValue("@EmployeeID", SelectedEmployee.EmployeeID);

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

        public EmploeeMappingViewModel()
        {
            //Project = new Project();
            CurrentEmployee = new EmployeeDetails();
            MappedEmployees = new ObservableCollection<EmployeeDetails>();
            MappingOperations = new RelayCommand(Operations);
            Employees = new ObservableCollection<EmployeeDetails>();
            FilteredEmployees = new ObservableCollection<EmployeeDetails>();
            //GetProjectObj(Project);
            //GetMappedEmployee();
            GetEmployee();
        }
    }
}
