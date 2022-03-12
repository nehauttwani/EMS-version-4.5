using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_sample.Model
{
    public class EmployeeQualifications: ModelBase
    {
        EmployeeDetails employeeDetails = new EmployeeDetails();


        private string fkemployeecode;
        public string FK_EmployeeCode
        {
            set
            {
                fkemployeecode = employeeDetails.EmployeeCode;
            }
        }

        private string qualification;
        public string Quailification
        {
            get
            {
                return qualification;
            }
            set
            {
                qualification = value;
                OnPropertyChanged("Quailification");
            }
        }

        private string board;
        public string Board
        {
            get
            {
                return board;
            }
            set
            {
                board = value;
                OnPropertyChanged("Board");
            }
        }

        private string institute;
        public string Institute
        {
            get
            {
                return institute;
            }
            set
            {
                institute = value;
                OnPropertyChanged("Institute");
            }
        }

        private string institutestate;
        public string InstituteState
        {
            get
            {
                return institutestate;
            }
            set
            {
                institutestate = value;
                OnPropertyChanged("InstituteState");
            }
        }

        private int passingyear;
        public int PassingYear
        {
            get
            {
                return passingyear;
            }
            set
            {
                passingyear = value;
                OnPropertyChanged("PassingYear");
            }
        }

        private string percentageobtained;
        public string PercentageObtained
        {
            get
            {
                return percentageobtained;
            }
            set
            {
                percentageobtained = value;
                OnPropertyChanged("PercentageObtained");
            }
        }
    }
}
