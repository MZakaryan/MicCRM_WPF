using MicCRM.Info.Models;
using MicCRM.Logic.Controllers;
using MicCRM.Parser;
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
    /// Interaction logic for ExcelWindow.xaml
    /// </summary>
    public partial class ExcelWindow : Window
    {
        List<ApplicantViewModel> list = new List<ApplicantViewModel>();
        public  ExcelWindow()
        {
            InitializeComponent();
            Helpers.HelperMethodes.GetTechnologiesList(this.comboBoxTech);
        }  
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Import import = new Import(true); 
            this.list = await import.ReadFromExcel(this.comboBoxTech.Text);
            this.List.ItemsSource = list; 
        } 
        private void ComfirmExcel(object sender, RoutedEventArgs e)
        {
            Import import = new Import(false);
            import.AddToDB(this.list);
            this.Close();
        }
    }
}
