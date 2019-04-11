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
        private Setting settingWindow;

        private double lon;
        private double lat;

        public FlightBoardViewModel()
        {
            this.lon = 0;
            this.lat = 0;
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
        #region SettingCommand
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
            if (settingWindow == null|| !settingWindow.isOpen)
            {
                settingWindow = new Setting();
                settingWindow.Show();
            }
        
        }
        #endregion

        #region ConnectCommand
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
