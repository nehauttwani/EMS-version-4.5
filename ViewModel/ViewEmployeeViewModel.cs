using System;
using EMS.Entities;

namespace EMS.ViewModel
{
    public class ViewEmployeeViewModel : ViewModelBase
    {
        private int experience = 0;
        public int Experience
        {
            get
            {

                if (Employee.ReleaseDate == null)
                {

                    experience = (DateTime.Now.Year - Employee.JoiningDate.Value.Year) * 12 + DateTime.Now.Month - Employee.JoiningDate.Value.Month;
                }
                else
                {
                    experience = (Employee.ReleaseDate.Value.Year - Employee.JoiningDate.Value.Year) * 12 + Employee.ReleaseDate.Value.Month - Employee.JoiningDate.Value.Month;
                }
                return experience;
            }
            set
            {
                if (Employee.ReleaseDate == null)
                {

                    experience = (DateTime.Now.Year - Employee.JoiningDate.Value.Year) * 12 + DateTime.Now.Month - Employee.JoiningDate.Value.Month;
                }
                else
                {
                    experience = (Employee.ReleaseDate.Value.Year - Employee.JoiningDate.Value.Year) * 12 + Employee.ReleaseDate.Value.Month - Employee.JoiningDate.Value.Month;
                }; OnPropertyChanged("Experience");
            }
        }

        private EmployeeDetails _employee = new EmployeeDetails();
        public EmployeeDetails Employee
        {
            get { return _employee; }
            set { _employee = value; OnPropertyChanged("Employee"); }
        }
        public void GetEmployeeObj(EmployeeDetails obj)
        {
            //Employee.EmployeeID = obj.EmployeeID;
            //Employee.EmployeeCode = obj.EmployeeCode;
            //Employee.FirstName = obj.FirstName;
            //Employee.LastName = obj.LastName;
            Employee = obj;
            Employee.JoiningDate = Employee.JoiningDate.Value.Date;

        }
        public ViewEmployeeViewModel()
        {


        }
    }
}
