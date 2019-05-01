using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FlightSimulator.Views.Dialogs;
using FlightSimulator.Views.Windows;
using FlightSimulator.ViewModels.Windows;
namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// This function sets up needed settings for correct running of the application. In particular,
        /// it initializes importent component to run application using MVVM model.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            IDialogService dialogService = new DialogService(MainWindow);
            /// SettingsWindwow is a dialog. Therefore its view and viewModel must be registered.
            dialogService.Register<SettingsWindowViewModel, SettingsWindow>();
            var viewModel = new MainWindowViewModel(dialogService);
            var view = new MainWindow { DataContext = viewModel };
            ///When the main window is being closed, we have to close all sockets/threads
            ///that were opened for communication with simulator.
            view.Closed += delegate (Object obj, EventArgs args)
            {
                viewModel.BreakConnectionChanelsWithSimulator();
            };
            view.ShowDialog();
     
        }
    }
}
