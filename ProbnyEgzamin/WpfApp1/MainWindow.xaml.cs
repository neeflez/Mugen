using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProbnyEgzamin;
using static ProbnyEgzamin.Program;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            ListaSerwisow listaSerwisow = new ListaSerwisow();

            MessageBox.Show(listaSerwisow.ToString());
            //listawpf.ItemsSource =  listaserwisow;
            //listawpf.ItemsSource = listaserwisow;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public struct Wlasciciel
        {
            public string imie;
            public string nazwisko;

            public Wlasciciel(string _imie, string _nazwisko)
            {
                this.imie = _imie;
                this.nazwisko = _nazwisko;
            }
        }
    }
}
