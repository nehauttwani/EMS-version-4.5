using System.Windows.Controls;

namespace EMS.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private UserControl currentview = new Views.Dashboard();
        public UserControl CurrentView
        {
            get { return currentview; }
            set
            {
                currentview = value;
                OnPropertyChanged("CurrentView");
            }
        }
        public RelayCommand UpdateViewCommand { get; set; }


        void ShowUserControl(object parameter)
        {


            if (parameter.ToString() == "Technology")
            {
                CurrentView = new Views.Technology();
            }
            else if (parameter.ToString() == "Skill")
            {
                CurrentView = new Views.Skill();
            }
            else if (parameter.ToString() == "Dashboard")
            {
                CurrentView = new Views.Dashboard();
            }
            else if (parameter.ToString() == "Project")
            {
                CurrentView = new Views.Project();
            }
            else if (parameter.ToString() == "Employee")
            {
                CurrentView = new Views.Employee();
            }

        }
        public MainWindowViewModel()
        {

            UpdateViewCommand = new RelayCommand(ShowUserControl);
        }

    }
}
