using System.Windows.Controls;
using EMS.ViewModel;

namespace EMS.Views
{
    /// <summary>
    /// Interaction logic for Technology.xaml
    /// </summary>
    public partial class Technology : UserControl
    {
        TechnologyViewModel technologyViewModel;
        public Technology()
        {

            InitializeComponent();
            technologyViewModel = new TechnologyViewModel();
            this.DataContext = technologyViewModel;
        }
    }
}
