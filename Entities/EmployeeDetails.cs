using System;
using System.Security;

namespace EMS.Entities
{
    public class EmployeeDetails : EntityBase
    {
        private int employeeid;
        public int EmployeeID
        {
            get
            {
                return employeeid;
            }
            set
            {
                employeeid = value;
                OnPropertyChanged("EmployeeID");
            }
        }

        private string employeecode;
        public string EmployeeCode
        {
            get
            {
                return employeecode;
            }
            set
            {
                employeecode = value;
                OnPropertyChanged("EmployeeCode");
            }
        }

        private string firstname;
        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string lastname;
        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
                OnPropertyChanged("LastName");
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }


        private string confirmpassword;
        public string ConfirmPassword
        {
            get
            {
                return confirmpassword;
            }
            set
            {
                confirmpassword = value;
                OnPropertyChanged("ConfirmPassword");
            }
        }

        private Department department;
        public Department Department
        {
            get
            {
                return department;
            }
            set
            {
                department = value;
                OnPropertyChanged("Department");
            }
        }

        private Designation designation;
        public Designation Designation
        {
            get
            {
                return designation;
            }
            set
            {
                designation = value;
                OnPropertyChanged("Designation");
            }
        }

        private DateTime? _joiningdate;
        public DateTime? JoiningDate
        {
            get
            {
                return _joiningdate;
            }
            set
            {
                _joiningdate = value;
                OnPropertyChanged("JoiningDate");
            }
        }

        private DateTime? _releasedate;
        public DateTime? ReleaseDate
        {
            get
            {
                return _releasedate;
            }
            set
            {
                _releasedate = value;
                OnPropertyChanged("ReleaseDate");
            }
        }
        private string fullname;
        public string FullName
        {
            get { fullname = firstname + " " + lastname; return fullname; }
            set { fullname = firstname + " " + lastname; OnPropertyChanged("FullName"); }
        }

    }
}
