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
using Word_Skills_Desktop.Models;

namespace Word_Skills_Desktop.Pages
{
    public partial class PageListOfPatients : Page
    {
        public PageListOfPatients()
        {
            InitializeComponent();
            DataGridSorting();
        }

        private void DataGridSorting()
        {
            var listOfPatients = MainClass.Context.Patients.ToList();
            SurnameSorting(ref listOfPatients);
            PassportSorting(ref listOfPatients);
            DataGridPatients.ItemsSource = listOfPatients;
        }

        private void SurnameSorting(ref List<Patients> patients)
        {
            if(!string.IsNullOrEmpty(TextBoxSurnameFilter.Text))
                patients = patients.Where(x => x.last_name.ToLower().Contains(TextBoxSurnameFilter.Text.ToLower()))
                    .ToList();            
        }

        private void PassportSorting(ref List<Patients> patients)
        {
            if (!string.IsNullOrEmpty(TextBoxPassportFilter.Text))
                patients = patients.Where(x => x.passport.ToLower().Contains(TextBoxPassportFilter.Text.ToLower())).
                    ToList();
        }

        private void ButtonAboutPatient_Click(object sender, RoutedEventArgs e)
        {
            var patient = (sender as Button).DataContext as Patients;
            if (patient is null)
                return;

            MainClass.FrameMainStruct.Navigate(new PagePatientMedicalCard(patient));
        }

        private void TextBoxesFilter_TextChanged(object sender, TextChangedEventArgs e) =>
            DataGridSorting();

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            TextBoxPassportFilter.Text = string.Empty;
            TextBoxSurnameFilter.Text = string.Empty;
        }
    }
}
