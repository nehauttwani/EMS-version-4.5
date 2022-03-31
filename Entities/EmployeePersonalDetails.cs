using System;

namespace EMS.Entities
{
    public class EmployeePersonalDetails : EntityBase
    {
        private DateTime? _dob;
        public DateTime? DOB
        {
            get
            {
                return _dob;
            }
            set
            {
                _dob = value;
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
