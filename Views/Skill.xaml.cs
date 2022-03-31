using System.Windows.Controls;
using EMS.ViewModel;

namespace EMS.Views
{
    /// <summary>
    /// Interaction logic for Skill.xaml
    /// </summary>
    public partial class Skill : UserControl
    {
        SkillViewModel skillViewModel;
        public Skill()
        {
            InitializeComponent();
            skillViewModel = new SkillViewModel();
            this.DataContext = skillViewModel;
        }
    }
}
