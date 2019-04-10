using FlightSimulator.Model;
using FlightSimulator.ViewModels;
using FlightSimulator.ViewModels.Windows;
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

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {
        SettingsWindowViewModel vm;
        public Setting()
        {
            InitializeComponent();
            vm = new SettingsWindowViewModel(new ApplicationSettingsModel);
            DataContext = vm;
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            txtIP.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtPort.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtCommandPort.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            vm.SaveSettings();  
            this.Close();
        }

        private void BtnCancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
   

}
