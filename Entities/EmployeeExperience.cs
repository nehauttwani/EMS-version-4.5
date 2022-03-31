using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace EMS.Entities
{
    public class EmployeeExperience : EntityBase
    {

        private int employeeid;
        public int EmployeeID
        {
            get { return employeeid; }
            set { employeeid = value; OnPropertyChanged("EmployeeID"); }
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

        private DateTime? _datefrom;
        public DateTime? DateFrom
        {
            get
            {
                return _datefrom;
            }
            set
            {
                _datefrom = value;
                OnPropertyChanged("DateFrom");
            }
        }

        private DateTime? _todate;
        public DateTime? ToDate
        {
            get
            {
                return _todate;
            }
            set
            {
                _todate = value;
                OnPropertyChanged("ToDate");
            }
        }

        private ObservableCollection<Designation> designations;
        public ObservableCollection<Designation> Designations
        {
            get { return designations; }
            set { designations = value; OnPropertyChanged("Designations"); }
        }

       
        private int? duration;
        public int? Duration
        {
            get
            {

                return duration;
            }
            set
            {
                duration = value;
                OnPropertyChanged("Duration");
            }
        }

        private bool isEditable = false;
        public bool IsEditable
        {
            get { return isEditable; }
            set { isEditable = value; OnPropertyChanged("IsEditable"); }
        }
        private Visibility savevisible = Visibility.Visible;
        public Visibility SaveVisible
        {
            get { return savevisible; }
            set { savevisible = value; OnPropertyChanged("SaveVisible"); }
        }

        private Visibility editvisible = Visibility.Collapsed;
        public Visibility EditVisible
        {
            get { return editvisible; }
            set { editvisible = value; OnPropertyChanged("EditVisible"); }
        }
    }
}
