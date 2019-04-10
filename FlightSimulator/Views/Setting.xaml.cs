using FlightSimulator.Model;
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
using System.Windows.Shapes;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {
        ApplicationSettingViewModel vm;
        public Setting()
        {
            InitializeComponent();
            vm = new ApplicationSettingViewModel(new ApplicationSettingsModel);
            DataContext = vm;
        }
    }
    private void btnOk_Click(object sender, EventArgs e)
    {

    }
    private void btnCancle_Click(object sender, EventArgs e)
    {

    }

}
