using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FlightSimulator.Views.Dialogs;
namespace FlightSimulator.ViewModels.Windows
{
    /// <summary>
    /// View Model of settings window, which serves as a dialog window.
    /// </summary>
    public class SettingsWindowViewModel : BaseNotify, IDialogRequestClose
    {
        public event EventHandler<EventArgs> CloseRequested;
        private ISettingsModel model;

        public SettingsWindowViewModel()
        {
            this.model = new ApplicationSettingsModel();
            ///Initializing settings of connection chanels.
            FlightServerIP = model.FlightServerIP;
            FlightCommandPort = model.FlightCommandPort;
            FlightInfoPort = model.FlightInfoPort;
        }

        public string FlightServerIP
        {
            get { return model.FlightServerIP; }
            set
            {
                model.FlightServerIP = value;
                NotifyPropertyChanged("FlightServerIP");
            }
        }

        public int FlightCommandPort
        {
            get { return model.FlightCommandPort; }
            set
            {
                model.FlightCommandPort = value;
                NotifyPropertyChanged("FlightCommandPort");
            }
        }

        public int FlightInfoPort
        {
            get { return model.FlightInfoPort; }
            set
            {
                model.FlightInfoPort = value;
                NotifyPropertyChanged("FlightInfoPort");
            }
        }

     

        public void SaveSettings()
        {
            model.SaveSettings();
        }

        public void ReloadSettings()
        {
            model.ReloadSettings();
        }

        #region Commands
        #region ClickCommand
        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => OnClick()));
            }
        }
        private void OnClick()
        {
            SaveSettings();
            CloseRequested?.Invoke(this, new EventArgs());
        }
        #endregion

        #region CancelCommand
        private ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new CommandHandler(() => OnCancel()));    
            }
        }
        private void OnCancel()
        {
            model.ReloadSettings();
            CloseRequested?.Invoke(this, new EventArgs());
        }

        #endregion
        #endregion
        public void OnWindowClosing(object sender, EventArgs e)
        {
            model.ReloadSettings();
        }
    }
}

