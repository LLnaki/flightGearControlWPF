using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace FlightSimulator.Views.Dialogs
{   
    /// <summary>
    /// This interface defines Dialogs 
    /// </summary>
    public interface IDialog
    {
        object DataContext { get; set; }
        /// <summary>
        /// The window, from which Dialog was asked to be shown.
        /// </summary>
        Window Owner { get; set; }
        void Close();
        bool? ShowDialog();
    }
    /// <summary>
    /// This interface defines a behaviour, which makes it possible to use dialog in MVVM model.
    /// It provides with tools to use views of dialogs in viewModels of other windows in polymorphic and
    /// encapsulating way, so that viewModel don't know view(only some general interface) 
    /// and thus MVVM model requirements are satisfied.
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        /// For each ViewModel of some Dialog, registers a propriate to it view.
        /// </summary>
        /// <typeparam name="TViewModel">View model of some dialog window in MVVM pattern.</typeparam>
        /// <typeparam name="TView">View of some dialog window in MVVM pattern.</typeparam>
        void Register<TViewModel, TView>() where TViewModel : IDialogRequestClose
                                           where TView : IDialog;
        /// <summary>
        /// Shows appropriate view for given viewModel(for Dialog window).
        /// </summary>
        /// <typeparam name="TViewModel">View model of some dialog window in MVVM pattern.</typeparam>
        /// <param name="viewModel">View model object of TViewModelType which will be showed.</param>
        /// <returns></returns>
        bool? ShowDialog<TViewModel>(TViewModel viewModel) where TViewModel : IDialogRequestClose;
    }
    /// <summary>
    /// An interface that defines a behavior that responds to request to close window of view in MVVM pattern.
    /// </summary>
    public interface IDialogRequestClose
    {
        /// <summary>
        /// An event that should be called whenever a dialog is asked to be closed.
        /// </summary>
        event EventHandler<EventArgs> CloseRequested;
    }
    
}
