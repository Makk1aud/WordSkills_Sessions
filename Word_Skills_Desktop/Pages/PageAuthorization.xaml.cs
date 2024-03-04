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
using Word_Skills_Desktop.Helpers;

namespace Word_Skills_Desktop.Pages
{
    public partial class PageAuthorization : Page
    {
        public PageAuthorization()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            var doctor = MainClass.Context.Doctors.FirstOrDefault(x => x.login_code == PasswordBoxLoginCode.Password);
            if (doctor is null)
                return;
            MainClass.Doctor = doctor;
            MainClass.FrameMainStruct.Navigate(new PageListOfPatients());
        }
    }
}
