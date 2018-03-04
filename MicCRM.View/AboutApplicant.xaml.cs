using MicCRM.Info.Models;
using MicCRM.Logic.Controllers;
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
    /// Interaction logic for AboutApplicant.xaml
    /// </summary>
    public partial class AboutApplicant : UserControl
    {
        private ApplicantViewModel applicant = null;
        private PersonsListWindow PersonsListWindow = null;
        private MainWindow ParentGrid = null;
        public AboutApplicant(MainWindow parent, PersonsListWindow personsListWindow)
        {
            InitializeComponent();
            this.ParentGrid = parent;
            this.PersonsListWindow = personsListWindow;
        }
        public AboutApplicant(ApplicantViewModel applicant, MainWindow parent, PersonsListWindow personsListWindow) :this(parent, personsListWindow)
        {
            this.applicant = applicant; 
            this.nameLabel.Content = this.applicant.FirstName;
            this.surNameLabel.Content = this.applicant.LastName;
            this.phoneLabel.Content = this.applicant.Phone1;
            this.emailLabel.Content = this.applicant.Email;
            this.DescriptionLable.AppendText(this.applicant.Description);
            this.DateLable.Content = this.applicant.Date;
            this.TechName.Content = this.applicant.Technology.Name;
        } 
        private void MakeStudentBtnClick(object sender, RoutedEventArgs e)
        {
            MakeStudentWindow msw = new MakeStudentWindow(this.applicant, PersonsListWindow);
            msw.Show();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditApplicantWindow edt = new EditApplicantWindow(this.applicant, PersonsListWindow);
            edt.Show();
        }

        private async void RemoveApplicantBtnClick(object sender, RoutedEventArgs e)
        {
          MessageBoxResult messageBoxResult =   MessageBox
                .Show($"Do you want to delete " +
                $"{this.applicant.FirstName} " +
                $"{this.applicant.LastName}  " +
                $"from applicants?", "Remove Applicant",
                MessageBoxButton.YesNo);
            switch (messageBoxResult)
            { 
                case MessageBoxResult.Yes:
                    ApplicantController applicantController = new ApplicantController();
                    this.applicant.Deleted = true;
                    await  applicantController.UpdateApplicant(this.applicant.Id, this.applicant);
                    PersonsListWindow.ApplList.ItemsSource = await applicantController.GetAllAsync();
                    break;
                case MessageBoxResult.No:
                    break;
                default:
                    break;
            }
        } 
        private void CloseBtn(object sender, RoutedEventArgs e)
        { 
            this.ParentGrid.MainFormColleft.Children.Clear();
        }
    }
}
