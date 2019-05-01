using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace FlightSimulator.Views.Dialogs
{
    /// <summary>
    /// This class provides with means and tools to operate on Dialog windows.
    /// </summary>
    public class DialogService : IDialogService
    {
        private readonly Window owner;
        /// <summary>
        /// Mapping from view models to its views.
        /// </summary>
        public IDictionary<Type,Type> Mappings { get; }

        public DialogService(Window owner)
        {
            this.owner = owner;
            Mappings = new Dictionary<Type, Type>();
        }
        public void Register<TViewModel, TView>() where TViewModel : IDialogRequestClose
                                                  where TView: IDialog
        {
            if (Mappings.ContainsKey(typeof(TViewModel)))
                throw new ArgumentException($"Type{typeof(TViewModel)} is already mapped to type {typeof(TView)}");
            Mappings.Add(typeof(TViewModel), typeof(TView));

        }
        public bool? ShowDialog<TViewModel>(TViewModel viewModel) where TViewModel:IDialogRequestClose
        {
            ///Geting appropriate viewType for given ViewModel.
            Type viewType = Mappings[typeof(TViewModel)];

            IDialog dialog = (IDialog) Activator.CreateInstance(viewType);
            EventHandler<EventArgs> handler = null;

            handler = (sender, e) =>
            {
                    dialog.Close();
            };
            viewModel.CloseRequested += handler;

            dialog.DataContext = viewModel;
            dialog.Owner = owner;
            return dialog.ShowDialog();
        }

    }
}
