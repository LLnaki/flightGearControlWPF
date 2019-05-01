using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using System.ComponentModel;
namespace FlightSimulator.ViewModels.Windows
{
   public sealed class FlightBoardViewModel : BaseNotify
    {
        public static FlightBoardViewModel Instance { get; } = new FlightBoardViewModel();
        private ControlModel model;
        public ControlModel Model
        {
            get
            {
                return model;
            }

            set
            {
                this.model = value;
                value.PropertyChanged += delegate (object obj, PropertyChangedEventArgs args)
                {
                    NotifyPropertyChanged(args.PropertyName);
                };
            }
        }
        public float Lat
            {
                get { return Model.Lat; }
            }
        public float Lon
        {
            get { return Model.Lon; }
        }
        
        private FlightBoardViewModel() { }
    }
}
