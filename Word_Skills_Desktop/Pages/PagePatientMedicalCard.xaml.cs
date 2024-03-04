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
    public partial class PagePatientMedicalCard : Page
    {
        private Patients patient;
        public PagePatientMedicalCard(Patients patient)
        {
            InitializeComponent();
            this.patient = patient;
            this.DataContext = patient;
            ComboBoxMedType.ItemsSource = MainClass.Context.MedicalActiveTypes.ToList();
        }

        private void ButtonAddDianose_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxDiagnose.Text))
                return;
            var medicalHistory = new MedicalHistories
            {
                medical_card_id = patient.MedicalCards.medical_card_id,
                diagnose = TextBoxDiagnose.Text
            };

            MainClass.Context.MedicalHistories.Add(medicalHistory);
            MainClass.Context.SaveChanges();
        }

        private bool ValidationMedActivities()
        {
            var validate = true;
            foreach(var item in StackPanelMedAct.Children)
            {
                if(item is TextBox textBox && string.IsNullOrEmpty(textBox.Text))
                    validate = false;
            }
            if(ComboBoxMedType.SelectedItem is null)
                validate = false;
            return validate;
        }

        private void ButtonAddMedActivity_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidationMedActivities())
                return;

            var medActivities = new MedicalActivites
            {
                patient_id = patient.patient_id,
                doctor_id = MainClass.Doctor.doctor_id,
                medical_type_id = Convert.ToInt32(ComboBoxMedType.SelectedValue),
                holding_date = DateTime.Now,
                title = TextBoxMedTitle.Text,
                result = TextBoxMedResults.Text,
                recomendation = TextBoxMedRecomendations.Text
            };

            MainClass.Context.MedicalActivites.Add(medActivities);
            MainClass.Context.SaveChanges();
        }
    }
}
