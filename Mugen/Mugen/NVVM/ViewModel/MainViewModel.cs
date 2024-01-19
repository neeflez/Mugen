using Mugen.Core;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Mugen.NVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public HomeViewModel HomeVm { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVm = new HomeViewModel();
            CurrentView = HomeVm;
        }

        private RelayCommand dodajKafelekCommand;

        public ICommand DodajKafelekCommand
        {
            get
            {
                if (dodajKafelekCommand == null)
                {
                    dodajKafelekCommand = new RelayCommand(DodajKafelek);
                }

                return dodajKafelekCommand;
            }
        }

        private void DodajKafelek(object commandParameter)
        {
            Debug.WriteLine("dodaj kafelek");
        }
    }
}
