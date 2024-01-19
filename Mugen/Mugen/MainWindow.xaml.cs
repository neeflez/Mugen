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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mugen
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double ostatniaPozycjaX = 0;
        private double ostatniaPozycjaY = 0;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void DodajKafelek_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DodajKafelek();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DodajKafelek()
        {
            // Tworzenie nowego kafelka z wykorzystaniem StackPanel
            StackPanel kafelek = new StackPanel();
            kafelek.Resources = tileStackPanel.Resources;

            Border border = new Border();
            border.Background = (LinearGradientBrush)Application.Current.FindResource("TileBackground");
            border.CornerRadius = new CornerRadius(12);

            TextBlock textTask = new TextBlock();
            textTask.Text = "Task";
            textTask.FontSize = 28;
            textTask.Margin = new Thickness(0, 12, 0, 0); // Margines od góry
            textTask.Foreground = Brushes.White;
            textTask.HorizontalAlignment = HorizontalAlignment.Center;
            textTask.VerticalAlignment = VerticalAlignment.Center;

            TextBlock textDescription = new TextBlock();
            textDescription.Text = "Description";
            textDescription.FontSize = 16;
            textDescription.Margin = new Thickness(12, 0, 12, 0); // Margines od lewej i prawej
            textDescription.Foreground = Brushes.White;

            TextBlock textProgress = new TextBlock();
            textProgress.Text = "1/2";
            textProgress.FontSize = 28;
            textProgress.Margin = new Thickness(0, 0, 0, 12); // Margines od dołu
            textProgress.Foreground = Brushes.White;
            textProgress.FontWeight = FontWeights.Bold;
            textProgress.HorizontalAlignment = HorizontalAlignment.Center;

            kafelek.Children.Add(border);
            border.Child = textTask;
            kafelek.Children.Add(textDescription);
            kafelek.Children.Add(textProgress);

            // Ustawienie pozycji kafelka obok poprzedniego
            if (canvas.Children.Count > 0)
            {
                Canvas.SetLeft(kafelek, ostatniaPozycjaX + 10); // Dodaj odstęp 10 pikseli
                Canvas.SetTop(kafelek, ostatniaPozycjaY + 10); // Dodaj odstęp 10 pikseli
            }

            // Zapisanie aktualnej pozycji dla kolejnego kafelka
            ostatniaPozycjaX = Canvas.GetLeft(kafelek);
            ostatniaPozycjaY = Canvas.GetTop(kafelek);

            // Dodanie kafelka do canvas
            canvas.Children.Add(kafelek);
        }
    }
}
