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
    /// Interaction logic for MakeStudentWindow.xaml
    /// </summary>
    public partial class MakeStudentWindow : Window
    {
        private ApplicantViewModel applicant = null;
        PersonsListWindow personsListWindow = null;
        public MakeStudentWindow(PersonsListWindow personsListWindow)
        {
            InitializeComponent();
            this.personsListWindow = personsListWindow;
        }
        public MakeStudentWindow(ApplicantViewModel applicant, PersonsListWindow personsListWindow) : this(personsListWindow)
        {
            this.applicant = applicant;
            this.MakeStudentNamelabel.Content = $"Student: {this.applicant.FirstName}  {this.applicant.LastName}";
            this.MakeStudentLessonNameLabel.Content = $"{this.applicant.Technology.Name}";
        }

        private async void MakeStudentComfirmBtnClick(object sender, RoutedEventArgs e)
        {
            ApplicantController applctrl = new ApplicantController();
            LessonViewModel lesson = new LessonViewModel
            {
                StartingDate = Helper.GetDate(this.StartingDatePicker.Text),
                EndingDate = Helper.GetDate(this.EndingDatePicker.Text), 
            };
            await applctrl.MakeStudent(this.applicant.Id);
            personsListWindow.ApplList.ItemsSource = await applctrl.GetAllAsync();
            StudentViewModel student = new StudentViewModel()
            {
                ApplicantViewModelId = this.applicant.Id,
                Description = "asdasdasdasd"
            };
            student.Lessons.Add(lesson);
            StudentController studentController = new StudentController();
            studentController.AddStudent(student);
            this.Close();
        }
    }
}
