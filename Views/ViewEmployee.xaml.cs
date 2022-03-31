using System.Windows;
using EMS.ViewModel;

namespace EMS.Views
{
    /// <summary>
    /// Interaction logic for ViewEmployee.xaml
    /// </summary>

    public partial class ViewEmployee : Window
    {
        ViewEmployeeViewModel viewEmployee;
        public ViewEmployee()
        {
            InitializeComponent();
            viewEmployee = new ViewEmployeeViewModel();
            this.DataContext = viewEmployee;
        }
        public ViewEmployeeViewModel getViewModel()
        {
            return viewEmployee;
        }
    }
}
