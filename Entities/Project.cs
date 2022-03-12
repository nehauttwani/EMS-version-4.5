using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entities
{
    public class Project : EntityBase
    {
        private string projectcode;
        public string ProjectCode
        {
            get
            {
                return projectcode;
            }
            set
            {
                projectcode = value;
                OnPropertyChanged("ProjectCode");
            }
        }

        private string projectname;
        public string ProjectName
        {
            get
            {
                return projectname;
            }
            set
            {
                projectname = value;
                OnPropertyChanged("ProjectName");
            }
        }

        private DateTime startdate;
        public DateTime StartDate
        {
            get
            {
                return startdate;
            }
            set
            {
                startdate = value;
                OnPropertyChanged("StartDate");
            }
        }

        private DateTime enddate;
        public DateTime EndDate
        {
            get
            {
                return enddate;
            }
            set
            {
                enddate = value;
                OnPropertyChanged("EndDate");
            }
        }


    }
}
