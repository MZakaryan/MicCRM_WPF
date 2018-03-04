using MicCRM.Info.Models;
using MicCRM.Logic.Controllers;
using MicCRM.Logic.Helpers;
using MicCRM.Logic.Mappers;
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

namespace MicCRM.View
{
    /// <summary>
    /// Interaction logic for AddEntityWindow.xaml
    /// </summary>
    public partial class AddEntityWindow : UserControl
    {
        public AddEntityWindow()
        {
            InitializeComponent();
            Loaded += AddEntityWindow_Loaded;
            Helpers.HelperMethodes.GetTechnologiesList(this.comboBoxLesson);
            
        } 
        private  void AddEntityWindow_Loaded(object sender, RoutedEventArgs e)
        {
            AddStartedatDatePicker.SelectedDate = DateTime.Today;
            TechnologyController ctrl = new TechnologyController();
        }

        private void AddApplicantBtn_Click(object sender, RoutedEventArgs e)
        {
            string FirstName = "undefined";
            string LastName = "undefined";
            string Phone = "undefined";
            string Email = "undefined"; 
            bool validilationPassed = true;
            if (Logic.Helpers.Validation.IsTextFormat(this.firstNametextbox.Text) && !String.IsNullOrEmpty(this.firstNametextbox.Text))
            {
                FirstName = this.firstNametextbox.Text;
            }
            else
            {
                this.firstNameBorder.Style = (Style)FindResource("WarrningBorder");
                validilationPassed = false;
            }
            if (Logic.Helpers.Validation.IsTextFormat(this.lastNametextbox.Text) && !String.IsNullOrEmpty(this.lastNametextbox.Text))
            {
                LastName = this.lastNametextbox.Text;
            }
            else
            {
                this.LastNameBorder.Style = (Style)FindResource("WarrningBorder");
                validilationPassed = false;
            }
            if (Logic.Helpers.Validation.IsPhoneFormat(this.phonetextbox.Text))
            {
                Phone = this.phonetextbox.Text;
            }
            else
            {
                this.PhoneBorder.Style = (Style)FindResource("WarrningBorder");
                validilationPassed = false;
            }
            if (Logic.Helpers.Validation.IsEmailFormat(this.emailtextbox.Text))
            {
                Email = this.emailtextbox.Text;
            }
            else
            {
                this.Emailborder.Style = (Style)FindResource("WarrningBorder");
                validilationPassed = false;
            }
            if (validilationPassed)
            {
                string desc = new TextRange(this.DescTextBox.Document.ContentStart, DescTextBox.Document.ContentEnd).Text;
                ApplicantController applicantctrl = new ApplicantController();
                ApplicantViewModel applicant = new ApplicantViewModel();
                applicant.FirstName = FirstName;
                applicant.LastName = LastName;
                applicant.Phone1 = Phone;
                applicant.Email = Email;
                applicant.Date = Helper.GetDate(this.AddStartedatDatePicker.Text);
                applicant.Description = desc;
                applicant.Technology = this.comboBoxLesson.SelectedItem as TechnologyViewModel; 
                applicantctrl.InsertOrUpdate(applicant); 
            }
            else return;

        } 
        private void FirstNametextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            firstNameBorder.Style = (Style)FindResource("notCalledBorder");
        }
        private void LastNametextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LastNameBorder.Style = (Style)FindResource("notCalledBorder");
        }
        private void Phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            PhoneBorder.Style = (Style)FindResource("notCalledBorder");
        }
        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            Emailborder.Style = (Style)FindResource("notCalledBorder");
        }
    }
}
