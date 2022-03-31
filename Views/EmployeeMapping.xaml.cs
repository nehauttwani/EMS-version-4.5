using System.Windows;
using EMS.ViewModel;

namespace EMS.Views
{
    /// <summary>
    /// Interaction logic for ViewEmployee.xaml
    /// </summary>
    public partial class EmployeeMapping : Window
    {
        //ProjectViewModel projectViewModel;
        EmploeeMappingViewModel employeeMappingviewModel;
        public EmployeeMapping()
        {
            InitializeComponent();
            employeeMappingviewModel = new EmploeeMappingViewModel();
            this.DataContext = employeeMappingviewModel;
        }

        public EmploeeMappingViewModel getemployeemapping()
        {
            return employeeMappingviewModel;
        }
    }
}
