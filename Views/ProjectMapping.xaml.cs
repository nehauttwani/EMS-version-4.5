using System.Windows;
using EMS.ViewModel;

namespace EMS.Views
{
    /// <summary>
    /// Interaction logic for ProjectMapping.xaml
    /// </summary>
    public partial class ProjectMapping : Window
    {
        ProjectMappingViewModel projectMappingViewModel;
        public ProjectMapping()
        {
            InitializeComponent();
            projectMappingViewModel = new ProjectMappingViewModel();
            this.DataContext = projectMappingViewModel;
        }
        public ProjectMappingViewModel getprojectmapping()
        {
            return projectMappingViewModel;
        }
    }
}
