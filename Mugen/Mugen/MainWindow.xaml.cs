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
        int k = 0;
        List<Tile> ListOfTiles = new List<Tile>();
        int i = 0;
        public MainWindow()
        {
            InitializeComponent();
            CreateListOfTiles();


        }
        public void Add_Tile(object sender, RoutedEventArgs e)
        {
            for(int l = 0; l < ListOfTiles.Count; l++)
            {
                if (ListOfTiles[l].isUsed == false)
                {
                    ListOfTiles[l].tile.Visibility = Visibility.Visible;
                    ListOfTiles[l].TaskText.Text = textInputTask.Text;
                    ListOfTiles[l].DescriptionText.Text = textInputDescription.Text;
                    ListOfTiles[l].isUsed = true;
                    break;
                }
            }
            //if (i < ListOfTiles.Count && ListOfTiles[i].isUsed == false)
            //{ 
            //    ListOfTiles[i].tile.Visibility = Visibility.Visible;
            //    ListOfTiles[i].TaskText.Text = textInputTask.Text;
            //    ListOfTiles[i].DescriptionText.Text = textInputDescription.Text;
            //    ListOfTiles[i].isUsed = true;
            //    i++;
            //}
            //else
            //{
            //    MessageBox.Show("Co za dużo to nie zdrowo :)");
            //}
        }

        public void CreateListOfTiles()
        {
            Tile_1 = new Tile("asd", "dsad", false);
            Tile_1.tile = Tile1;
            Tile_1.TaskText = TaskText1;
            Tile_1.DescriptionText = DescriptionText1;

            Tile_2 = new Tile("asd", "dsad", false);
            Tile_2.tile = Tile2;
            Tile_2.TaskText = TaskText2;
            Tile_2.DescriptionText = DescriptionText2;

            Tile_3 = new Tile("asd", "dsad", false);
            Tile_3.tile = Tile3;
            Tile_3.TaskText = TaskText3;
            Tile_3.DescriptionText = DescriptionText3;

            Tile_4 = new Tile("asd", "dsad", false);
            Tile_4.tile = Tile4;
            Tile_4.TaskText = TaskText4;
            Tile_4.DescriptionText = DescriptionText4;

            Tile_5 = new Tile("asd", "dsad", false);
            Tile_5.tile = Tile5;
            Tile_5.TaskText = TaskText5;
            Tile_5.DescriptionText = DescriptionText5;

            Tile_6 = new Tile("asd", "dsad", false);
            Tile_6.tile = Tile6;
            Tile_6.TaskText = TaskText6;
            Tile_6.DescriptionText = DescriptionText6;

            ListOfTiles = new List<Tile> { Tile_1, Tile_2, Tile_3, Tile_4, Tile_5, Tile_6 };
        }
        public void DeleteTile(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement frameworkElement)
            {
                var xNameProperty = frameworkElement.GetType().GetProperty("Name");
                if (xNameProperty != null)
                {
                    string xNameValue = xNameProperty.GetValue(frameworkElement) as string;
                    int j = xNameValue[xNameValue.Length - 1] - 49;
                    if (j < k)
                    {
                        i = j;
                    }
                    else
                    {
                        i = k;
                    }
                    k = j;
                    ListOfTiles[j].tile.Visibility = Visibility.Collapsed;
                    ListOfTiles[j].isUsed = false;
                }
            }
        }
    }
    public class Tile
    {
        string task;
        string description;
        public bool isUsed;
        public Grid tile;
        public TextBlock TaskText;
        public TextBlock DescriptionText;
        public Tile(string _task, string _description, bool _isUsed)
        {
            this.description = _description;
            this.task = _task;
            this.isUsed = _isUsed;
        }
    }


}
