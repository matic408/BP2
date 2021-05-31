using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Commands;

namespace UI.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        public ViewModelBase currentViewModel;

        public MainViewModel()
        {
            CurrentViewModel = new DealViewModel();
            UpdateViewCommand = new UpdateViewCommand(this);
        }

        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }
    }
}
