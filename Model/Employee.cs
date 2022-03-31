using System.Collections.ObjectModel;
using EMS.Entities;

namespace EMS.Model
{
    public class Employee : ModelBase
    {
        private EmployeeDetails employeeDetails;
        public EmployeeDetails EmployeeDetails
        {
            get { return employeeDetails; }
            set
            {
                employeeDetails = value;
                OnPropertyChanged("EmployeeDetails");
            }
        }
        private ObservableCollection<EmployeeExperience> employeeExperience;
        public ObservableCollection<EmployeeExperience> EmployeeExperience
        {
            get { return employeeExperience; }
            set
            {
                employeeExperience = value;
                OnPropertyChanged("EmployeeExperience");
            }
        }
        private ObservableCollection<EmployeeQualifications> employeeQualifications;
        public ObservableCollection<EmployeeQualifications> EmployeeQualifications
        {
            get { return employeeQualifications; }
            set
            {
                employeeQualifications = value;
                OnPropertyChanged("EmployeeQualifications");
            }
        }
        private EmployeePersonalDetails personalDetails;
        public EmployeePersonalDetails PersonalDetails
        {
            get { return personalDetails; }
            set { personalDetails = value; OnPropertyChanged("PersonalDetails"); }
        }
    }
}
