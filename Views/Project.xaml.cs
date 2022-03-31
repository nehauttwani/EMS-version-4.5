using System.Windows.Controls;
using EMS.ViewModel;

namespace EMS.Views
{
    /// <summary>
    /// Interaction logic for Project.xaml
    /// </summary>

    public partial class Project : UserControl
    {
        ProjectViewModel projectViewmodel;

        public Project()
        {

            InitializeComponent();
            projectViewmodel = new ProjectViewModel();
            this.DataContext = projectViewmodel;
        }


    }
}
