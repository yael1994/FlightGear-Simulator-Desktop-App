using FlightSimulator.ViewModels;
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

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for Auto.xaml
    /// </summary>
    public partial class Auto : UserControl
    {
        private AutoPilotViewModel autoPilotView;
        public Auto()
        {
            InitializeComponent();
            autoPilotView = new AutoPilotViewModel();
            DataContext = autoPilotView;
            if (autoPilotView.WhiteBackgroundAction == null)
            {
                autoPilotView.WhiteBackgroundAction = new Action(() => TextBox.Background = Brushes.White);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            this.TextBox.Clear();
        }
        private void TextBoxAuto_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox.Background = Brushes.Pink;
        }
    }
}
