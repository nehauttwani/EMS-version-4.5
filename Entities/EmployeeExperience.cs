using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_sample.Model
{
    public class EmployeeExperience: ModelBase
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
  
        
        private string lastorganization;
        public string LastOrganization
        {
            get
            {
                return lastorganization;
            }
            set
            {
                lastorganization = value;
                OnPropertyChanged("LastOrganization");
            }
        }

        private string lastdesignation;
        public string LastDesignation
        {
            get
            {
                return lastdesignation;
            }
            set
            {
                lastdesignation = value;
                OnPropertyChanged("LastDesignation");
            }
        }

        private DateTime datefrom;
        public DateTime DateFrom
        {
            get
            {
                return datefrom;
            }
            set
            {
                datefrom = value;
                OnPropertyChanged("DateFrom");
            }
        }

        private DateTime todate;
        public DateTime ToDate
        {
            get
            {
                return todate;
            }
            set
            {
                todate = value;
                OnPropertyChanged("ToDate");
            }
        }
    }
}
