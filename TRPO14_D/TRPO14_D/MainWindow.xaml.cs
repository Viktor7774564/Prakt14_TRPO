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
using TRPO14_D.ViewModels;
using TRPO14_D.Models;
using System.IO;
using System.Text.Json;

namespace TRPO14_D
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CarViewModel();
            string str = Car.categoriesstring;
            string[] mass = str.Split(' ');
            cbx1.ItemsSource = mass;
            object[] items = cbx1.Items.OfType<String>().Distinct().ToArray();
            cbx1.ItemsSource = items;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ((CarViewModel)DataContext).AddCar();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ((CarViewModel)DataContext).DeleteCar();
        }

        private void Save_Json(object sender, RoutedEventArgs e)
        {
            ((CarViewModel)DataContext).SavingJson();
        }

        private void SaleCategory_Changed(object sender, TextChangedEventArgs e)
        {
            if (SaleCategory.IsChecked == true && cbx1.SelectedItem != null && procent.Text != "")
            {
                ((CarViewModel)DataContext).CalcSaleGroup(cbx1.SelectedItem.ToString(), int.Parse(procent.Text));
            }
        }

        private void procent_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Any(symbol => !char.IsDigit(symbol)))
            {
                e.Handled = true;
            }
        }
    }
}
