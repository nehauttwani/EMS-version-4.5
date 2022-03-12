using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_sample.Model
{
    public class EmployeeDetails: ModelBase

    {
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

        private int departmentid;
        public int DepartmentId
        {
            get
            {
                return departmentid;
            }
            set
            {
                departmentid = value;
                OnPropertyChanged("DepartmentId");
            }
        }

        private int designationid;
        public int DesignationId
        {
            get
            {
                return designationid;
            }
            set
            {
                designationid = value;
                OnPropertyChanged("DesignationId");
            }
        }

        private DateTime joiningdate;
        public DateTime JoiningDate
        {
            get
            {
                return joiningdate;
            }
            set
            {
                joiningdate = value;
                OnPropertyChanged("JoiningDate");
            }
        }

        private DateTime releasedate;
        public DateTime ReleaseDate
        {
            get
            {
                return releasedate;
            }
            set
            {
                releasedate = value;
                OnPropertyChanged("ReleaseDate");
            }
        }

        private DateTime dob;
        public DateTime DOB
        {
            get
            {
                return dob;
            }
            set
            {
                dob = value;
                OnPropertyChanged("DOB");
            }
        }

        private int contactnumber;
        public int ContactNumber
        {
            get
            {
                return contactnumber;
            }
            set
            {
                contactnumber = value;
                OnPropertyChanged("ContactNumber");
            }
        }

        private int genderid;
        public int GenderId
        {
            get
            {
                return genderid;
            }
            set
            {
                genderid = value;
                OnPropertyChanged("GenderId");
            }
        }

        private int statusid;
        public int StatusId
        {
            get
            {
                return statusid;
            }
            set
            {
                statusid = value;
                OnPropertyChanged("StatusId");
            }
        }

        private string presentaddress;
        public string PresentAddress
        {
            get
            {
                return presentaddress;
            }
            set
            {
                presentaddress = value;
                OnPropertyChanged("PresentAddress");
            }
        }

        private string permanentaddress;
        public string PermanentAddress
        {
            get
            {
                return permanentaddress;
            }
            set
            {
                permanentaddress = value;
                OnPropertyChanged("PermanentAddress");
            }
        }

    }
}
