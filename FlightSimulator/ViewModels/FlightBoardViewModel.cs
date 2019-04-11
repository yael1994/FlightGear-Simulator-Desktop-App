using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private IFlightModel model;
        private Setting settingWindow;
        public FlightBoardViewModel()
        {
         
        }
        public double Lon
        {
            get;
        }

        public double Lat
        {
            get;
        }


        #region Commands
        #region ClickCommand
        private ICommand _settingCommand;
        public ICommand SettingsCommand
        {
            get
            {
                return _settingCommand ?? (_settingCommand = new CommandHandler(() => OnSetting()));
            }
        }
        private void OnSetting()
        {
            if (settingWindow == null)
            {
                settingWindow = new Setting();
            }
                settingWindow.Show();
        
        }
        #endregion

        #region CancelCommand
        private ICommand _connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand = new CommandHandler(() => OnConnect()));
            }
        }
        private void OnConnect()
        {
            model.Connect();
        }
        #endregion
        #endregion
    }
}
