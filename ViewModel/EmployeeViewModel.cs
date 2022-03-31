using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

using EMS.Entities;
using EMS.Views;

namespace EMS.ViewModel
{
    public class EmployeeViewModel : ViewModelBase
    {
        // ------------------ Objects ------------------

        SqlConnectionMethod method = new SqlConnectionMethod();

        // ------------------ Declarations -----------------
        public int result = -1;
        public enum Gender
        {
            Male,
            Female
        }
        public enum MaritalStatus
        {
            Married,
            Unmarried,
            Divorced
        }
        private int selectedIndex = 0;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; OnPropertyChanged("SelectedIndex"); }
        }

        private List<string> maritalState;
        public List<string> MaritalState
        {
            get
            {
                Enum.GetValues(typeof(MaritalStatus)).Cast<MaritalStatus>().Select(v => v.ToString()).ToList();
                return maritalState;
            }
            set
            {
                maritalState = Enum.GetValues(typeof(MaritalStatus)).Cast<MaritalStatus>().Select(v => v.ToString()).ToList();
                OnPropertyChanged("MaritalState");
            }
        }


        private Visibility employeeMain = Visibility.Visible;
        public Visibility EmployeeMain
        {
            get
            {
                return employeeMain;
            }
            set
            {
                employeeMain = value;
                OnPropertyChanged("EmployeeMain");
            }
        }
        private Visibility employeeadd = Visibility.Collapsed;
        public Visibility EmployeeAdd
        {
            get
            {
                return employeeadd;
            }
            set
            {
                employeeadd = value;
                OnPropertyChanged("EmployeeAdd");
            }
        }
        private ObservableCollection<Department> departments;
        public ObservableCollection<Department> Departments
        {
            get { return departments; }
            set { departments = value; OnPropertyChanged("Departments"); }
        }
        private ObservableCollection<Designation> designations;
        public ObservableCollection<Designation> Designations
        {
            get { return designations; }
            set { designations = value; OnPropertyChanged("Designations"); }
        }


        private int _radiobutton;
        public int RadioButton { get { return _radiobutton; } set { _radiobutton = value; OnPropertyChanged("RadioButton"); } }


        private string _selectedMaritalState;
        public string SelectedMaritalState { get { return _selectedMaritalState; } set { _selectedMaritalState = value; OnPropertyChanged("SelectedMaritalState"); } }


        private bool _address;
        public bool Address { get { return _address; } set { _address = value; OnPropertyChanged("Address"); } }


        private int? _selectedTab;

        public int? SelectedTab
        {
            get { return _selectedTab; }
            set
            {
                _selectedTab = value;
                OnPropertyChanged("SelectedTab");
            }
        }

        private EmployeeQualifications currentQual;
        public EmployeeQualifications CurrentQual
        {
            get { return currentQual; }
            set { currentQual = value; OnPropertyChanged("CurrentQual"); }
        }

        private EmployeeQualifications alterQual;
        public EmployeeQualifications AlterQual
        {
            get { return alterQual; }
            set { alterQual = value; OnPropertyChanged("AlterQual"); }
        }


        private EmployeeExperience currentexp;
        public EmployeeExperience CurrentExp
        {
            get { return currentexp; }
            set { currentexp = value; OnPropertyChanged("CurrentExp"); }
        }

        private EmployeeExperience alterexp;
        public EmployeeExperience AlterExp
        {
            get
            {
                return alterexp;
            }
            set { alterexp = value; OnPropertyChanged("AlterExp"); }
        }

        private Model.Employee currentemployee;
        public Model.Employee CurrentEmployee
        {
            get { return currentemployee; }
            set { currentemployee = value; OnPropertyChanged("CurrentEmployee"); }
        }
        private EmployeeDetails alteremployee;
        public EmployeeDetails AlterEmployee
        {
            get { return alteremployee; }
            set { alteremployee = value; OnPropertyChanged("AlterEmployee"); }
        }

        private ObservableCollection<EmployeeDetails> employees;
        public ObservableCollection<EmployeeDetails> Employees
        {
            get { return employees; }
            set { employees = value; OnPropertyChanged("Employees"); }
        }

        public RelayCommand EmployeeOperations { get; set; }

        private EmployeeDetails getEmployee1;
        public EmployeeDetails GetEmployee1
        {
            get { return getEmployee1; }
            set { getEmployee1 = value; OnPropertyChanged("GetEmployee1"); }
        }


        // --------------- Operations --------------------

        void Operations(object parameter)
        {
            switch (parameter)
            {
                case "AddEmployee":
                    EmployeeMain = Visibility.Collapsed;
                    EmployeeAdd = Visibility.Visible;
                    //string i = Convert.ToString(Enum.ToObject(typeof(Gender), RadioButton));

                    break;
                case "EmployeeMain":
                    EmployeeMain = Visibility.Visible;
                    EmployeeAdd = Visibility.Collapsed;

                    break;
                case "SaveEmployee":

                    SaveEmployee();
                    SelectedTab++;
                    break;
                case "SameAddress":
                    if (Address)
                    {
                        CurrentEmployee.PersonalDetails.PermanentAddress = CurrentEmployee.PersonalDetails.PresentAddress;
                        OnPropertyChanged("PermanentAddress");
                    }
                    else
                    {
                        CurrentEmployee.PersonalDetails.PermanentAddress = string.Empty;
                    }
                    break;
                case "SecondTab":
                    if(CurrentEmployee.EmployeeDetails.Password == CurrentEmployee.EmployeeDetails.ConfirmPassword)
                    {

                        SelectedTab++;
                    }
                    else
                    {
                        MessageBox.Show("Password and Confirm Password are not same!", "Warning", MessageBoxButton.OK);
                    }
                    break;
                case "Search":
                    Employees = new ObservableCollection<EmployeeDetails>();
                    SearchEmployee();
                    break;
                case "Clear":
                    Employees = new ObservableCollection<EmployeeDetails>();
                    GetEmployee();
                    CurrentEmployee = new Model.Employee();
                    break;
                case "AddRow":
                    AlterQual = new EmployeeQualifications();
                    CurrentQual = new EmployeeQualifications();
                    CurrentQual.IsEditable = true;
                    CurrentEmployee.EmployeeQualifications.Add(CurrentQual);
                    //CurrentQual.IsEditable = true;

                    break;
                case "AddRowEx":
                    AlterExp = new EmployeeExperience();
                    AlterExp.Designations = new ObservableCollection<Designation>();
                    CurrentExp = new EmployeeExperience();
                    CurrentExp.Designations = new ObservableCollection<Designation>();
                    CurrentExp.IsEditable = true;
                    GetDeptDesg();
                    CurrentEmployee.EmployeeExperience.Add(CurrentExp);
                    
                    //CurrentQual.IsEditable = true;

                    break;
                case "saveQual":
                    if (result == -1)
                    {

                        CurrentQual = AlterQual;
                        OnPropertyChanged("CurrentQual");

                        AlterQual.IsEditable = false;
                        AlterQual.SaveVisible = Visibility.Collapsed;
                        AlterQual.EditVisible = Visibility.Visible;
                        //CurrentEmployee.EmployeeQualifications.Add(AlterQual);
                        CurrentQual = new EmployeeQualifications();
                        AlterQual = new EmployeeQualifications();

                    }
                    else
                    {
                        AlterQual.IsEditable = false;
                        AlterQual.SaveVisible = Visibility.Collapsed;
                        AlterQual.EditVisible = Visibility.Visible;
                        CurrentEmployee.EmployeeQualifications[result] = AlterQual;
                        result = -1;
                        //CurrentEmployee.EmployeeQualifications.Add(AlterQual);
                        CurrentQual = new EmployeeQualifications();
                    }
                    break;
                case "saveEx":
                    if (result == -1)
                    {
                        AlterExp.Duration = (AlterExp.ToDate.Value.Year - AlterExp.DateFrom.Value.Year) * 12 + AlterExp.ToDate.Value.Month - AlterExp.DateFrom.Value.Month;
                        CurrentExp = AlterExp;
                        OnPropertyChanged("CurrentExp");

                        AlterExp.IsEditable = false;
                        AlterExp.SaveVisible = Visibility.Collapsed;
                        AlterExp.EditVisible = Visibility.Visible;
                        //CurrentEmployee.EmployeeQualifications.Add(AlterQual);
                        CurrentExp = new EmployeeExperience();
                        AlterExp = new EmployeeExperience();

                    }
                    else
                    {
                        AlterExp.IsEditable = false;
                        AlterExp.SaveVisible = Visibility.Collapsed;
                        AlterExp.EditVisible = Visibility.Visible;
                        CurrentEmployee.EmployeeExperience[result] = AlterExp;
                        result = -1;
                        //CurrentEmployee.EmployeeQualifications.Add(AlterQual);
                        CurrentExp = new EmployeeExperience();
                    }
                    break;
                case "editEx":
                    AlterExp.IsEditable = true;
                    AlterExp.SaveVisible = Visibility.Visible;
                    AlterExp.EditVisible = Visibility.Collapsed;
                    AlterExp.Designations = new ObservableCollection<Designation>();
                    GetDeptDesg();
                    result = CurrentEmployee.EmployeeExperience.IndexOf(AlterExp);
                    break;
                case "editQual":
                    AlterQual.IsEditable = true;
                    AlterQual.SaveVisible = Visibility.Visible;
                    AlterQual.EditVisible = Visibility.Collapsed;
                    result = CurrentEmployee.EmployeeQualifications.IndexOf(AlterQual);
                    break;

                case "deleteQual":

                    MessageBoxResult d;
                    d = MessageBox.Show("Do you want to delete this record", "Warning", MessageBoxButton.YesNo);
                    if (d == MessageBoxResult.Yes)
                    {
                        CurrentEmployee.EmployeeQualifications.Remove(AlterQual);
                        AlterQual = new EmployeeQualifications();
                    }

                    break;
                case "deleteEx":

                    MessageBoxResult e;
                    e = MessageBox.Show("Do you want to delete this record", "Warning", MessageBoxButton.YesNo);
                    if (e == MessageBoxResult.Yes)
                    {
                        CurrentEmployee.EmployeeExperience.Remove(AlterExp);
                        AlterQual = new EmployeeQualifications();
                    }

                    break;

                case "Save":
                    SaveQual();
                    SelectedTab++;
                    break;
                case "submit":
                    SaveEx();
                    EmployeeMain = Visibility.Visible;
                    EmployeeAdd = Visibility.Collapsed;
                    GetEmployee();
                    break;
                case "viewEmployee":
                    //GetEmployee1.EmployeeID = AlterEmployee.EmployeeID;
                    //GetEmployee1.EmployeeCode = AlterEmployee.EmployeeCode;
                    //GetEmployee1.FirstName = AlterEmployee.FirstName;
                    //GetEmployee1.LastName = AlterEmployee.LastName;
                    ViewEmployee viewEmployee = new ViewEmployee();
                    GetEmployee1 = AlterEmployee;
                    ViewEmployeeViewModel model = viewEmployee.getViewModel();
                    model.GetEmployeeObj(GetEmployee1);
                    viewEmployee.ShowDialog();
                    break;
                case "projectMapping":
                    ProjectMapping projectMapping = new ProjectMapping();
                    GetEmployee1.EmployeeID = AlterEmployee.EmployeeID;
                    GetEmployee1.EmployeeCode = AlterEmployee.EmployeeCode;
                    GetEmployee1.FirstName = AlterEmployee.FirstName;
                    GetEmployee1.LastName = AlterEmployee.LastName;

                    ProjectMappingViewModel obj = projectMapping.getprojectmapping();
                    obj.GetEmployeeObj(GetEmployee1);
                    obj.GetMappedProject(GetEmployee1);
                    projectMapping.ShowDialog();
                    break;

                case "ClearEntry":
                    CurrentEmployee = new Model.Employee();
                    CurrentEmployee.EmployeeDetails = new EmployeeDetails();
                    Employees = new ObservableCollection<EmployeeDetails>();
                    GetEmployee();
                    break;

                    



            }
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
                        
                        AlterExp.Designations.Add(new Designation() { DesignationId = Convert.ToInt32(reader[0]), DesignationValue = Convert.ToString(reader[1]) });
                       CurrentExp.Designations.Add(new Designation() { DesignationId = Convert.ToInt32(reader[0]), DesignationValue = Convert.ToString(reader[1]) });

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

        public void SearchEmployee()

        {
            //int rowcount = 0;
            string strConn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                // Settings.  
                sqlCommand.CommandText = "SearchEmployee";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandTimeout = 108; //// Setting timeeout for longer queries to 12 hours.  
                sqlCommand.Parameters.AddWithValue("@FirstName", CurrentEmployee.EmployeeDetails.FirstName ?? string.Empty);
                
                sqlCommand.Parameters.AddWithValue("@Email", CurrentEmployee.EmployeeDetails.Email ?? string.Empty);
                if (CurrentEmployee.EmployeeDetails.Department.DepartmentId != null)
                {
                    sqlCommand.Parameters.AddWithValue("@DepartmentId", CurrentEmployee.EmployeeDetails.Department.DepartmentId);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@DepartmentId", -1);
                }
                if (CurrentEmployee.EmployeeDetails.Designation.DesignationId != null)
                {
                    sqlCommand.Parameters.AddWithValue("@DesignationId", CurrentEmployee.EmployeeDetails.Designation.DesignationId);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@DesignationId", -1);
                }


                // Open.  
                sqlConnection.Open();

                // Result.  
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {


                        EmployeeDetails details = new EmployeeDetails();
                        details.Designation = new Designation();
                        details.Department = new Department();
                        details.EmployeeCode = reader[0].ToString();
                        details.FirstName = reader[1].ToString();
                        details.LastName = reader[2].ToString();
                        details.Email = reader[3].ToString();
                        details.Department.DepartmentId = Convert.ToInt32(reader[4]);
                        details.Designation.DesignationId = Convert.ToInt32(reader[5]);
                        details.JoiningDate = Convert.ToDateTime(reader[6]);
                        if (reader[7] == DBNull.Value)
                        {
                            details.ReleaseDate = null;
                        }
                        else
                        {

                            details.ReleaseDate = Convert.ToDateTime(reader[7]);
                        }
                        foreach (Designation item in Designations)
                        {
                            if (item.DesignationId == details.Designation.DesignationId)
                            {
                                details.Designation.DesignationValue = item.DesignationValue;
                            }
                        }
                        foreach (Department item in Departments)
                        {
                            if (item.DepartmentId == details.Department.DepartmentId)
                            {
                                details.Department.DepartmentValue = item.DepartmentValue;
                            }
                        }
                        Employees.Add(details);
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
        public void SaveEmployee()
        {
            try
            {

                List<object> parameters = method.Command("SaveEmployee");
                SqlConnection sqlConnection = (SqlConnection)parameters[1];
                //MyConverter myConverter = new MyConverter();

                SqlCommand sqlCommand = (SqlCommand)parameters[0];



                try
                {

                    GetDeptId();
                    GetDesg();

                    sqlCommand.Parameters.AddWithValue("@FirstName", CurrentEmployee.EmployeeDetails.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", CurrentEmployee.EmployeeDetails.LastName);
                    sqlCommand.Parameters.AddWithValue("@Email", CurrentEmployee.EmployeeDetails.Email);
                    sqlCommand.Parameters.AddWithValue("@Password", "lalala");
                    sqlCommand.Parameters.AddWithValue("@DepartmentId", CurrentEmployee.EmployeeDetails.Department.DepartmentId);
                    sqlCommand.Parameters.AddWithValue("@DesignationId", CurrentEmployee.EmployeeDetails.Designation.DesignationId);
                    sqlCommand.Parameters.AddWithValue("@JoiningDate", CurrentEmployee.EmployeeDetails.JoiningDate);
                    sqlCommand.Parameters.AddWithValue("@DOB", CurrentEmployee.PersonalDetails.DOB);
                    sqlCommand.Parameters.AddWithValue("@ContactNumber", CurrentEmployee.PersonalDetails.ContactNumber);
                    sqlCommand.Parameters.AddWithValue("@Gender", RadioButton);
                    sqlCommand.Parameters.AddWithValue("@MaritalStatus", (int)Enum.Parse(typeof(MaritalStatus), SelectedMaritalState));
                    sqlCommand.Parameters.AddWithValue("@PresentAddress", CurrentEmployee.PersonalDetails.PresentAddress);
                    sqlCommand.Parameters.AddWithValue("@PermanentAddress", CurrentEmployee.PersonalDetails.PermanentAddress);


                    if (CurrentEmployee.EmployeeDetails.ReleaseDate == null)
                    {
                        sqlCommand.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@ReleaseDate", CurrentEmployee.EmployeeDetails.ReleaseDate);
                    }

                    // Open.  
                    sqlConnection.Open();

                    // Result.

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    //SqlDataReader reader= sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            CurrentEmployee.EmployeeDetails.EmployeeID = Convert.ToInt32(reader[0]);
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
            catch
            {
                string message = "The required field cannot be empty!";
                MessageBox.Show(message, "Warning", MessageBoxButton.OK);
            }

        }

        public void SaveQual()
        {
            int rowCount = 0;

            try
            {
                foreach (EmployeeQualifications item in CurrentEmployee.EmployeeQualifications)
                {
                    List<object> parameters = method.Command("SaveQual");
                    SqlConnection sqlConnection = (SqlConnection)parameters[1];
                    //MyConverter myConverter = new MyConverter();

                    SqlCommand sqlCommand = (SqlCommand)parameters[0];






                    try
                    {


                        sqlCommand.Parameters.AddWithValue("@Qualification", item.Quailification);
                        sqlCommand.Parameters.AddWithValue("@Board", item.Board);
                        sqlCommand.Parameters.AddWithValue("@Institute", item.Institute);
                        sqlCommand.Parameters.AddWithValue("@InstituteState", item.InstituteState);
                        sqlCommand.Parameters.AddWithValue("@PassingYear", item.PassingYear);
                        sqlCommand.Parameters.AddWithValue("@PercentageObtained", item.PercentageObtained);
                        sqlCommand.Parameters.AddWithValue("@EmployeeiD", CurrentEmployee.EmployeeDetails.EmployeeID);



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
            }
            catch
            {
                string message = "The required field cannot be empty!";
                MessageBox.Show(message, "Warning", MessageBoxButton.OK);
            }

        }

        public void SaveEx()
        {
            int rowCount = 0;

            try
            {
                foreach (EmployeeExperience item in CurrentEmployee.EmployeeExperience)
                {
                    List<object> parameters = method.Command("SaveEx");
                    SqlConnection sqlConnection = (SqlConnection)parameters[1];
                    //MyConverter myConverter = new MyConverter();

                    SqlCommand sqlCommand = (SqlCommand)parameters[0];

                    try
                    {


                        sqlCommand.Parameters.AddWithValue("@LastOrganization", item.LastOrganization);
                        if (item.ToDate == null)
                        {
                            sqlCommand.Parameters.AddWithValue("@ToDate", DBNull.Value);
                        }
                        else
                        {
                            sqlCommand.Parameters.AddWithValue("@ToDate", item.ToDate);
                        }
                        if (item.DateFrom == null)
                        {
                            sqlCommand.Parameters.AddWithValue("@DateFrom", DBNull.Value);
                        }
                        else
                        {
                            sqlCommand.Parameters.AddWithValue("@DateFrom", item.DateFrom);
                        }

                       
                        sqlCommand.Parameters.AddWithValue("@DesignationId", item.Designation.DesignationId);
                        
                        sqlCommand.Parameters.AddWithValue("@EmployeeiD", CurrentEmployee.EmployeeDetails.EmployeeID);



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
            }
            catch
            {
                string message = "The required field cannot be empty!";
                MessageBox.Show(message, "Warning", MessageBoxButton.OK);
            }

        }
        public void GetDeptId()
        {
            //int rowcount = 0;
            List<object> parameters = method.Command("GetDeptId");
            SqlConnection sqlConnection = (SqlConnection)parameters[1];
            SqlCommand sqlCommand = (SqlCommand)parameters[0];

            try
            {
                sqlCommand.Parameters.AddWithValue("@Department", CurrentEmployee.EmployeeDetails.Department.DepartmentValue);
                // Open.  
                sqlConnection.Open();

                // Result.  
                SqlDataReader reader = sqlCommand.ExecuteReader();



                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        CurrentEmployee.EmployeeDetails.Department.DepartmentId = Convert.ToInt32(reader[0]);
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
        public void GetDesg()
        {
            //int rowcount = 0;
            List<object> parameters = method.Command("GetDesg");
            SqlConnection sqlConnection = (SqlConnection)parameters[1];
            SqlCommand sqlCommand = (SqlCommand)parameters[0];

            try
            {
                sqlCommand.Parameters.AddWithValue("@Designation", CurrentEmployee.EmployeeDetails.Designation.DesignationValue);
                // Open.  
                sqlConnection.Open();

                // Result.  
                SqlDataReader reader = sqlCommand.ExecuteReader();



                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        CurrentEmployee.EmployeeDetails.Designation.DesignationId = Convert.ToInt32(reader[0]);
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

        //public void RemoveEmployee(EmployeeDetails obj)
        //{
        //    try
        //    {

        //        int rowCount = 0;
        //        string strConn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        //        SqlConnection sqlConnection = new SqlConnection(strConn);
        //        SqlCommand sqlCommand = new SqlCommand();

        //        try
        //        {

        //            // Settings.  
        //            sqlCommand.CommandText = "RemoveProject";
        //            sqlCommand.CommandType = CommandType.StoredProcedure;
        //            sqlCommand.Connection = sqlConnection;
        //            sqlCommand.CommandTimeout = 180;

        //            sqlCommand.Parameters.AddWithValue("@ProjectCode", obj.ProjectCode);
        //            RemoveMappedTechnology();


        //            // Open.  
        //            sqlConnection.Open();

        //            // Result.

        //            rowCount = sqlCommand.ExecuteNonQuery();

        //            // Close.  
        //            sqlConnection.Close();

        //        }
        //        catch (Exception ex)
        //        {
        //            // Close.  
        //            sqlConnection.Close();

        //            throw ex;
        //        }

        //    }
        //    catch
        //    {
        //        string message = "The required field cannot be empty!";
        //        MessageBox.Show(message, "Warning", MessageBoxButton.OK);
        //    }
        //}
        public EmployeeViewModel()
        {
            //MessageBox.Show(Convert.ToString(Address), "warning", MessageBoxButton.OK);
            MaritalState = new List<string>();
            EmployeeOperations = new RelayCommand(Operations);
            CurrentEmployee = new Model.Employee();
            GetEmployee1 = new EmployeeDetails();

            AlterEmployee = new EmployeeDetails();

            CurrentEmployee.EmployeeDetails = new EmployeeDetails();
            CurrentEmployee.PersonalDetails = new EmployeePersonalDetails();
            Employees = new ObservableCollection<EmployeeDetails>();
            Departments = new ObservableCollection<Department>();
            Designations = new ObservableCollection<Designation>();
            AlterQual = new EmployeeQualifications();
            CurrentQual = new EmployeeQualifications();
            CurrentExp = new EmployeeExperience();
            AlterExp = new EmployeeExperience();
            AlterExp.Designations = new ObservableCollection<Designation>();
            CurrentExp.Designations = new ObservableCollection<Designation>();
            CurrentEmployee.EmployeeQualifications = new ObservableCollection<EmployeeQualifications>();
            CurrentEmployee.EmployeeExperience = new ObservableCollection<EmployeeExperience>();
            CurrentEmployee.EmployeeDetails.Designation = new Designation();
            CurrentEmployee.EmployeeDetails.Department = new Department();
            GetDeptDesg();
           
            GetEmployee();
            //GetQual();

        }

    }
}
