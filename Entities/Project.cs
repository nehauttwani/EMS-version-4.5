using System;

namespace EMS.Entities
{
    public class Project : EntityBase
    {
        private int projectid;
        public int ProjectId
        {
            get
            {
                return projectid;
            }
            set
            {
                projectid = value;
                OnPropertyChanged("ProjectId");
            }
        }

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

        private DateTime? _startdate;
        public DateTime? StartDate
        {
            get { return _startdate; }
            set
            {
                _startdate = value;
                OnPropertyChanged("StartDate");
            }
        }

        private DateTime? _enddate;
        public DateTime? EndDate
        {
            get
            {
                return _enddate;
            }
            set
            {
                _enddate = value;
                OnPropertyChanged("EndDate");
            }
        }


    }
}
