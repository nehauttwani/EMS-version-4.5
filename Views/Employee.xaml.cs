using System.Windows.Controls;
using EMS.ViewModel;

namespace EMS.Views
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : UserControl
    {
        EmployeeViewModel employeeViewModel;

        public Employee()
        {
            InitializeComponent();

            employeeViewModel = new EmployeeViewModel();
            this.DataContext = employeeViewModel;

        }

    }
}
