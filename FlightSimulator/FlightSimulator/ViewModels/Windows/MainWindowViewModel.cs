using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Model;
using System.Net.Sockets;
using System.Net;
using FlightSimulator.Views.Dialogs;
using FlightSimulator.ViewModels;
namespace FlightSimulator.ViewModels.Windows
{
   public class MainWindowViewModel : BaseNotify
    {
        private ControlModel model;
        private readonly IDialogService dialogService;
        public AutoPilotViewModel AutoPilViewModel { set; get; }
        public FlightBoardViewModel FlightBViewModel { set; get; }
        public ManualControlViewModel ManualConViewModel { set; get; }
        private IPAddress IpAddress
        {
            get
            {
                return IPAddress.Parse(Properties.Settings.Default.FlightServerIP);
            }
        }
        private int CommandsPort
        {
            get
            {
                return Properties.Settings.Default.FlightCommandPort;
            }
        }
        private int InfoPort
        {
            get
            {
                return Properties.Settings.Default.FlightInfoPort;
            }
        }
        public MainWindowViewModel(IDialogService dialogService)
        {
            model =  new ControlModel();
            this.dialogService = dialogService;
            AutoPilViewModel = new AutoPilotViewModel(model);
            ManualConViewModel = new ManualControlViewModel(model);
            FlightBViewModel = FlightBoardViewModel.Instance;
            FlightBViewModel.Model = model;
        }
        public void BreakConnectionChanelsWithSimulator()
        {
                model.DisconectFromSimulator();
                model.TurnOffServer();
        }
        
        #region Commands
        #region SettingsCommand
        private ICommand _settingsCommand;
        public ICommand SettingsCommand
        {
            get
            {
                return _settingsCommand ?? (_settingsCommand = new CommandHandler(() => OnSettings()));
            }
        }
        private void OnSettings()
        {

            dialogService.ShowDialog(new SettingsWindowViewModel());
        }
        

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
            model.StartServer(IpAddress, InfoPort);
            model.ConnectToSimulator(IpAddress, CommandsPort);
        }

    
        #endregion
        #endregion
        #endregion
    }
}
