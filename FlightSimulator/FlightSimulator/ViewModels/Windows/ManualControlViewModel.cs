using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
namespace FlightSimulator.ViewModels.Windows
{
    public class ManualControlViewModel : BaseNotify
    {
        private ControlModel model;
        private double throttle;
        private double rudder;
        private double aileron;
        private double elevator;
        public double Throttle
        {
            set
            {
                model.Throttle = value;
                throttle = value;
                NotifyPropertyChanged("Throttle");
            }
            get
            {
                return throttle;
            }
        }
        public double Rudder
        {
            set
            {
                model.Rudder = value;
                rudder = value;
                NotifyPropertyChanged("Rudder");
            }
            get
            {
                return rudder;
            }
        }
        public double Aileron
        {
            set
            {
                model.Aileron = value;
                aileron = value;
                NotifyPropertyChanged("Aileron");
            }
            get
            {
                return aileron;
            }
        }
        public double Elevator
        {
            set
            {
                model.Elevator = value;
                elevator = value;
                NotifyPropertyChanged("Elevator");
            }
            get
            {
                return elevator;
            }
        }
        public ManualControlViewModel(ControlModel model)
        {
            this.model = model;
            Aileron = 0;
            Rudder = 0;
            Throttle = 0;
            Elevator = 0;
        }
        

    }
}
