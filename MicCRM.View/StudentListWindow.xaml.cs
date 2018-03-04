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
    /// Interaction logic for StudentListWindow.xaml
    /// </summary>
    public partial class StudentListWindow : UserControl
    {
        private MainWindow UserControlsParent = null;
        public StudentListWindow(MainWindow ParentWindow)
        {
            InitializeComponent();

            this.UserControlsParent = ParentWindow;
            //  Excel icons Will be Always Hidden  on Creating instance of this Window
            ParentWindow.ExportGrid.Visibility = Visibility.Hidden;
            ParentWindow.ImportGrid.Visibility = Visibility.Hidden;
        }
        private void StudentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid datagrid = sender as DataGrid;
            if (datagrid == null) return;
            if (datagrid.SelectedItem is StudentViewModel student)
            {
                UserControlsParent.MainFormColleft.Children.Clear();
                AboutStudent AboutApplicantWindow = new AboutStudent(student, UserControlsParent, this);
                UserControlsParent.MainFormColleft.Children.Add(AboutApplicantWindow);
            }
            else return;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
