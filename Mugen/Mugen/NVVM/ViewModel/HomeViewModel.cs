// HomeViewModel.cs
using Mugen.Core;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Mugen.NVVM.ViewModel
{
    internal class HomeViewModel : ObservableObject
    {
        private ObservableCollection<string> _kafelki;
        private string _textInputTask;

        public ObservableCollection<string> Kafelki
        {
            get { return _kafelki; }
            set
            {
                _kafelki = value;
                OnPropertyChanged();
            }
        }

        public string TextInputTask
        {
            get { return _textInputTask; }
            set
            {
                _textInputTask = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _dodajKafelekCommand;

        public ICommand DodajKafelekCommand
        {
            get
            {
                if (_dodajKafelekCommand == null)
                {
                    _dodajKafelekCommand = new RelayCommand(DodajKafelek);
                }

                return _dodajKafelekCommand;
            }
        }

        public HomeViewModel()
        {
            Kafelki = new ObservableCollection<string>();
        }

        private void DodajKafelek(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(TextInputTask))
            {
                Kafelki.Add(TextInputTask);
                TextInputTask = string.Empty; // Clear TextBox after adding a tile
            }
        }
    }
}
