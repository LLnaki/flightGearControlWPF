using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using System.Threading;
using System.Windows.Input;
namespace FlightSimulator.ViewModels
{
    public class AutoPilotViewModel : BaseNotify
    {
        private ControlModel model;
        ///A time-pause between executing each command.
        private static readonly int timeToSleep = 2000;
        public bool IsExecutingCommands { set; get; }
        public AutoPilotViewModel(ControlModel controlModel)
        {
            model = controlModel;
        }

        private string commands;
        public string Commands { 
            set
            {                
                commands = value;
                this.NotifyPropertyChanged("Commands");
            }
            get
            {   
                return commands;
            }
        }
        public void ExecuteCommands()
        {
            ///Thread for executing commands.
            Thread thread = new Thread(new ParameterizedThreadStart((delegate (object commands)
           {
               IsExecutingCommands = true;
               this.NotifyPropertyChanged("IsExecutingCommands");
               ///each new command starts at new line. Therefore end line sign is a seperator.
               char[] seperator = { '\r', '\n' };

               string[] executableCommands = ((string)commands).Split(seperator, StringSplitOptions.RemoveEmptyEntries);
               ///Executing each comand seperatedly.
               foreach (string command in executableCommands)
               {
                   model.ExecuteCommand(command + "\r\n");
                   Thread.Sleep(timeToSleep);
               }
               this.IsExecutingCommands = false;
               this.NotifyPropertyChanged("IsExecutingCommands");
           })));
            thread.Start(this.Commands);

        }
        private ICommand _okCommand;
        public ICommand OkCommand
        {
            get
            {
                return _okCommand ?? (_okCommand = new CommandHandler(() => OnOk()));
            }
        }
        private void OnOk()
        {
            this.ExecuteCommands();
        }

        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new CommandHandler(() => OnClear()));
            }
        }
        private void OnClear()
        {
           Commands = "";
        }
    }
}

