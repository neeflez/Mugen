using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
        Tile Tile_1;
        Tile Tile_2;
        Tile Tile_3;
        Tile Tile_4;
        Tile Tile_5;
        Tile Tile_6;
        List<Tile> ListOfTiles = new List<Tile>();
        int i = 0;
        public MainWindow()
        {
            InitializeComponent();
            CreateListOfTiles();


        }
        public void Add_Tile(object sender, RoutedEventArgs e)
        {
            if (i < ListOfTiles.Count) { 
            ListOfTiles[i].tile.Visibility = Visibility.Visible;
            i++;
            }
            else
            {
                MessageBox.Show("Chyba masz co robić. Nie dodawaj sobie obwiązków bo wykitujesz :)");
            }
        }

        public void CreateListOfTiles()
        {
            Tile_1 = new Tile("asd", "dsad", 1);
            Tile_1.tile = Tile1;

            Tile_2 = new Tile("asd", "dsad", 1);
            Tile_2.tile = Tile2;

            Tile_3 = new Tile("asd", "dsad", 1);
            Tile_3.tile = Tile3;

            Tile_4 = new Tile("asd", "dsad", 1);
            Tile_4.tile = Tile4;

            Tile_5 = new Tile("asd", "dsad", 1);
            Tile_5.tile = Tile5;

            Tile_6 = new Tile("asd", "dsad", 1);
            Tile_6.tile = Tile6;

            ListOfTiles = new List<Tile> { Tile_1, Tile_2, Tile_3, Tile_4, Tile_5, Tile_6 };
        }
    }
    public class Tile
    {
        string task;
        string description;
        int num;
        public Grid tile;
        public Tile(string _task, string _description, int _num)
        {
            this.description = _description;
            this.task = _task;
            this.num = _num;

        }
    }


}
