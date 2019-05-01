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
using FlightSimulator.ViewModels.Windows;
using FlightSimulator.Views.Dialogs;
namespace FlightSimulator.Views.Windows
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window, IDialog
    {
        
        public SettingsWindow()
        {
            InitializeComponent();
            SettingsWindowViewModel viewModel = new SettingsWindowViewModel();
            DataContext = viewModel;
            Closing += viewModel.OnWindowClosing;
        }
    }
}
