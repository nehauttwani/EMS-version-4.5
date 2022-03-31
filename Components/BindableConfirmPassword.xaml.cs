using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EMS.Components
{
    /// <summary>
    /// Interaction logic for BindableConfirmPassword.xaml
    /// </summary>
    public partial class BindableConfirmPassword : UserControl
    {
        public string ConfirmPassword
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("ConfirmPassword", typeof(string), typeof(BindableConfirmPassword), new PropertyMetadata(string.Empty));

        public BindableConfirmPassword()
        {
            InitializeComponent();
        }
        private void PasswordBox_Passwordchanged(object sender, RoutedEventArgs e)
        {
            ConfirmPassword = passwordBox.Password;
        }
    }
}
