using MicCRM.Logic.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MicCRM.View.Helpers
{
    class HelperMethodes
    {
        /// <summary>
        ///  Add  User Control  to Grid
        /// </summary>
        /// <param name="mainGrid">Content Grid</param>
        /// <param name="gridTochange">Grid to change</param> 
        /// <param name="index">Index of grid wich will be updated</param>
        /// <param name="window">Added User Control</param>
        /// <param name="gridPersetage">Right Grid's Width with percents </param>
        /// <returns>Returns User contorl wich will be added</returns>
        public static UserControl UpdateGrid(Grid mainGrid, Grid gridTochange, UserControl Addedwindow, double RightgridPersetage)
        { 
            gridTochange.Children.Clear();
            mainGrid.ColumnDefinitions[0].Width = new GridLength(100 - RightgridPersetage, GridUnitType.Star); 
            mainGrid.ColumnDefinitions[1].Width = new GridLength(RightgridPersetage, GridUnitType.Star); 
            gridTochange.Children.Add(Addedwindow);
            return Addedwindow; 
        }
        public static void HideMenu(Grid mainGrid, int GridIndex, Grid MenuGrid)
        {
            mainGrid.RowDefinitions[GridIndex].Height = new GridLength(0, GridUnitType.Star);
            MenuGrid.Visibility = Visibility.Hidden;
        }
        public static void ShowMenu(Grid mainGrid, int GridIndex, Grid MenuGrid)
        {
            mainGrid.RowDefinitions[GridIndex].Height = new GridLength(7, GridUnitType.Star);
            MenuGrid.Visibility = Visibility.Visible;
        }
        public static async void GetTechnologiesList(ComboBox comboBox)
        {
            TechnologyController techctrl = new TechnologyController();
            comboBox.ItemsSource = await techctrl.GetAllAsync();
        }
    }
}
