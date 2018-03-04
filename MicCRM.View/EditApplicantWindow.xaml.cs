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
using System.Windows.Shapes;

namespace MicCRM.View
{
    /// <summary>
    /// Interaction logic for EditApplicantWindow.xaml
    /// </summary>
    public partial class EditApplicantWindow : Window
    {
        ApplicantViewModel applicant = null;
        PersonsListWindow personsListWindow = null;
        public EditApplicantWindow(ApplicantViewModel applicantModel, PersonsListWindow personsListWindow)
        {
            InitializeComponent();
            this.applicant = applicantModel;
            this.textBoxName.Text = this.applicant.FirstName;
            this.textBoxLastName.Text = this.applicant.LastName;
            this.textBoxPhone.Text = this.applicant.Phone1;
            this.textBoxEmail.Text = this.applicant.Email;
            this.DescTextBox.AppendText(this.applicant.Description);
            AddTechnologiesToComboBox(this.technologyCombobox);
            this.personsListWindow = personsListWindow; 
        }
        private async void AddTechnologiesToComboBox(ComboBox comboBox)
        {
            TechnologyController technologyController = new TechnologyController();
            comboBox.ItemsSource = await technologyController.GetAllAsync();
        }
        private async  void ComfirmEditButtonClick(object sender, RoutedEventArgs e)
        {
           ApplicantController applicantController = new ApplicantController();
           var range = new TextRange(this.DescTextBox.Document.ContentStart, this.DescTextBox.Document.ContentEnd);
           ApplicantViewModel app = new ApplicantViewModel
            {
                FirstName = this.textBoxName.Text,
                LastName = this.textBoxLastName.Text,
                Phone1 = this.textBoxPhone.Text,
                Email = this.textBoxEmail.Text,
                Date = Helper.GetDate(this.EditDatePicker.Text),
                Technology = this.technologyCombobox.SelectedItem as TechnologyViewModel,
                Description = range.Text 
            };
            this.applicant.Technology = app.Technology; 
            await  applicantController.UpdateApplicant(this.applicant.Id, app);
            personsListWindow.ApplList.ItemsSource = await applicantController.GetAllAsync();
            this.Close(); 
        }
    }
}
