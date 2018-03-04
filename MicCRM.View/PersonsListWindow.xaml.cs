using MicCRM.Info.Models;
using MicCRM.Logic.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for AllAplicantsWindow.xaml
    /// </summary>
    public partial class PersonsListWindow : UserControl
    {
        private MainWindow UserControlsParent = null; 
        public PersonsListWindow(MainWindow ParentWindow)
        {
           InitializeComponent();
           
            this.UserControlsParent = ParentWindow;
            //  Excel icons Will be Always Hidden  on Creating instance of this Window
            ParentWindow.ExportGrid.Visibility = Visibility.Hidden; 
            ParentWindow.ImportGrid.Visibility = Visibility.Hidden;
            TechnologyController tech = new TechnologyController();
            Helpers.HelperMethodes.GetTechnologiesList(this.LessonsComboBox);
        }   
        private void ApplList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid datagrid = sender as DataGrid;
            if (datagrid == null) return;
            if (datagrid.SelectedItem is ApplicantViewModel applicant)
            {
                UserControlsParent.MainFormColleft.Children.Clear();

                AboutApplicant AboutApplicantWindow = new AboutApplicant(applicant, UserControlsParent, this);
                UserControlsParent.MainFormColleft.Children.Add(AboutApplicantWindow);
            }
            else return;
        }
        private async void OnFindBtnClicked(object sender, RoutedEventArgs e)
        {
            ApplicantController appController = new ApplicantController();
            List<ApplicantViewModel> filteredList = new List<ApplicantViewModel>();

            filteredList = await appController.GetAllAsync();

            if (!string.IsNullOrEmpty(FirstNameTextBox.Text))
            {
                filteredList = filteredList
                    .Where(a => a.FirstName.ToLower()
                    .StartsWith(FirstNameTextBox.Text.ToLower()))
                    .ToList();
            }
            if (!string.IsNullOrEmpty(LastNameTextbox.Text))
            {
                filteredList = filteredList
                    .Where(a => a.LastName.ToLower()
                    .StartsWith(LastNameTextbox.Text.ToLower()))
                    .ToList();
            }
            if (!string.IsNullOrEmpty(LessonsComboBox.Text))
            {
                filteredList = filteredList
                    .Where(a => a.Technology.Name == LessonsComboBox.Text)
                    .ToList();
            }

            ApplList.ItemsSource = filteredList;
        }
        private async void OnRefresh(object sender, RoutedEventArgs e)
        {
            ApplicantController applicantController = new ApplicantController();
            this.ApplList.ItemsSource = await applicantController.GetAllAsync(); 
        }
    }
}
