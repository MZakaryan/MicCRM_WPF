using MicCRM.Info.Models;
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
    /// Interaction logic for AboutPerson.xaml
    /// </summary>
    public partial class AboutStudent : UserControl
    { 
        private StudentListWindow PersonsListWindow = null;
        private MainWindow ParentGrid = null;
        public AboutStudent(MainWindow parent, StudentListWindow studentListWindow)
        {
            InitializeComponent();
            this.ParentGrid = parent;
            this.PersonsListWindow = studentListWindow;
        }
        public AboutStudent(StudentViewModel student, MainWindow parent, StudentListWindow StudentListWindow) : this(parent, StudentListWindow)
        {
            this.nameLabel.Content = student.ApplicantViewModel.FirstName;
            this.surNameLabel.Content = student.ApplicantViewModel.LastName;
            this.phoneLabel.Content = student.ApplicantViewModel.Phone1;
            this.emailLabel.Content = student.ApplicantViewModel.Email;
            this.DescriptionLable.Content = student.Description;
            this.DateLable.Content = student.ApplicantViewModel.Date.ToShortDateString(); 
            List<LessonTechnologyViewModel> list = new List<LessonTechnologyViewModel>();
            foreach (var item in student.Lessons)
            {
                LessonTechnologyViewModel lessonTechnologyViewModel = new LessonTechnologyViewModel();
                lessonTechnologyViewModel.TechName = student.ApplicantViewModel.Technology.Name;
                lessonTechnologyViewModel.StartingDate = item.StartingDate.ToShortDateString();
                lessonTechnologyViewModel.EndingDate = item.EndingDate.ToShortDateString();
                list.Add(lessonTechnologyViewModel);
            }
            this.LesonsList.ItemsSource = list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        } 
    }
}
