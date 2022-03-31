using System.Windows;

namespace EMS.Entities
{
    public class EmployeeQualifications : EntityBase
    {


        private int employeeid;
        public int EmployeeID
        {
            get { return employeeid; }
            set { employeeid = value; OnPropertyChanged("EmployeeCode"); }
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

        private decimal percentageobtained;
        public decimal PercentageObtained
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
