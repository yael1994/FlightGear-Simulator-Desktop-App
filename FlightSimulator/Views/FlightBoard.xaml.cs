using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using FlightSimulator.Model;
using FlightSimulator.ViewModels;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for MazeBoard.xaml
    /// </summary>
    public partial class FlightBoard : UserControl
    {
        ObservableDataSource<Point> planeLocations = null;
        private FlightBoardViewModel vm;

        public FlightBoard()
        {
            InitializeComponent();
            this.vm = new FlightBoardViewModel();
            vm.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            { Vm_PropertyChanged(sender, e); };
            DataContext = vm;
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
                    planeLocations = new ObservableDataSource<Point>();
                    // Set identity mapping of point in collection to point on plot
                    planeLocations.SetXYMapping(p => p);
                    // Add line graph to plotter
                    plotter.AddLineGraph(planeLocations, 2, "Route");
           
            
        }

        private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals("Lat") || e.PropertyName.Equals("Lon") && (vm.Lat!=0 && vm.Lon!=0))
            {
                //create point form the lat and the lon that get from the flight gear
                Point p1 = new Point(vm.Lat, vm.Lon);          
                //draw the road for the new position
                planeLocations.AppendAsync(Dispatcher, p1);
            }
        }

    }

}

