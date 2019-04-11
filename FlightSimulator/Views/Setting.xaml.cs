using FlightSimulator.Model;
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
        SettingsWindowViewModel vm { get; }
        public bool isOpen { get; set; }

        public Setting()
        {
            InitializeComponent();
            isOpen = true;
            vm = new SettingsWindowViewModel(new ApplicationSettingsModel());
            DataContext = vm;
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            txtCommandPort.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtIP.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtPort.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            vm.SaveSettings();
            this.isOpen = false;
            this.Close();
        }

        private void BtnCancle_Click(object sender, RoutedEventArgs e)
        {
            this.isOpen = false;
            vm.ReloadSettings();
            this.Close();
        }
    }
}
