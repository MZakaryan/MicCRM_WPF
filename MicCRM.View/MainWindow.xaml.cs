using MicCRM.View;
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
using MicCRM.Logic.Helpers;
using MicCRM.View.Helpers;
using MicCRM.Logic.Controllers;
using System.ComponentModel;
using System.Threading;

namespace MicCRM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {  
        private bool IsAddMenuHidden;
        private bool IsExcelButtonsHidden;
        public MainWindow()
        {
            IsExcelButtonsHidden = true;
            IsAddMenuHidden = true;
        } 
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            this.ExcelGrid.Visibility = Visibility.Hidden;
            if (IsAddMenuHidden)
            { 
                HelperMethodes.ShowMenu(this.ParentMenuGrid, 1, SecondryMenuAdd);
                IsAddMenuHidden = false;
            }
            else
            {
                HelperMethodes.HideMenu(this.ParentMenuGrid, 1, SecondryMenuAdd);
                IsAddMenuHidden = true;
            }
        }
        private void OnApplicantBtnClickAdd(object sender, RoutedEventArgs e)
        {
            AddEntityWindow AddWindow = new AddEntityWindow();
            HelperMethodes.UpdateGrid(this.MainGrid, this.MainFormColRight, AddWindow, 100);
        } 
        private  async  void OnApplicantBtnClick(object sender, RoutedEventArgs e)
        { 
            PersonsListWindow AplicantsWindow = new PersonsListWindow(this);
            this.ExcelGrid.Visibility = Visibility.Visible;
            AplicantsWindow.lbltextApplicantList.Content = "Applicants";
            AplicantsWindow.TeacherComboBox.IsEnabled = false;
            this.logoMicrosoft.Visibility = Visibility.Visible; 
            HelperMethodes.UpdateGrid(MainGrid, MainFormColRight, AplicantsWindow, 70);
            ApplicantController appcontrol = new ApplicantController();
            AplicantsWindow.ApplList.ItemsSource = await appcontrol.GetAllAsync(); 
        }  
        private async void OnAllStudentBtnClick(object sender, RoutedEventArgs e)
        {
            this.ExcelGrid.Visibility = Visibility.Hidden;
            StudentListWindow StudentsWindow = new StudentListWindow(this); 
            HelperMethodes.UpdateGrid(MainGrid, MainFormColRight, StudentsWindow, 70);
            this.logoMicrosoft.Visibility = Visibility.Visible;
            StudentController stctrl = new StudentController();
            StudentsWindow.studentList.ItemsSource = await stctrl.GetAllAsync();
        }
        private void OnAllTeachersBtnClick(object sender, RoutedEventArgs e)
        {
            this.ExcelGrid.Visibility = Visibility.Hidden;
            PersonsListWindow teachersWindow = new PersonsListWindow(this);
            teachersWindow.lbltextApplicantList.Content = "Teachers";
            teachersWindow.TeacherComboBox.IsEnabled = false;
            HelperMethodes.UpdateGrid(MainGrid, MainFormColRight, teachersWindow, 70);
            this.logoMicrosoft.Visibility = Visibility.Visible;
        }

        private void ExcelIconClick(object sender, RoutedEventArgs e)
        { 
            if (!IsExcelButtonsHidden)
            {
                 this.ImportGrid.Visibility = Visibility.Hidden;
                 this.ExportGrid.Visibility = Visibility.Hidden;
                IsExcelButtonsHidden = true;
            }
            else
            {
                this.ImportGrid.Visibility = Visibility.Visible;
                this.ExportGrid.Visibility = Visibility.Visible;
                IsExcelButtonsHidden = false;
            }
                
        }

        private void ImportClick(object sender, RoutedEventArgs e)
        {
            ExcelWindow exWIn = new ExcelWindow();
            exWIn.Show();
        }
    }
}
