﻿using System;
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
        public bool IsPlaceForTile = true;
        List<Tile> ListOfTiles = new List<Tile>();
        int i = 0;
        public MainWindow()
        {
            InitializeComponent();
            CreateListOfTiles();
        }
        public void Add_Tile(object sender, RoutedEventArgs e)
        {
            IsPlaceForTile = true;
            for(int l = 0; l < ListOfTiles.Count; l++)
            {
                if (ListOfTiles[l].isUsed == false)
                {
                    ListOfTiles[l].tile.Visibility = Visibility.Visible;
                    ListOfTiles[l].TaskText.Text = textInputTask.Text;
                    ListOfTiles[l].DescriptionText.Text = textInputDescription.Text;
                    ListOfTiles[l].isUsed = true;
                    IsPlaceForTile = false;
                    break;
                }
            }
            if (IsPlaceForTile)
            {
                MessageBox.Show("co za dużo to nie zdrowo :)");
            }
        }

        public void CreateListOfTiles()
        {
            Tile_1 = new Tile(Tile1, TaskText1, DescriptionText1, false);

            Tile_2 = new Tile(Tile2, TaskText2, DescriptionText2, false);

            Tile_3 = new Tile(Tile3, TaskText3, DescriptionText3, false);

            Tile_4 = new Tile(Tile4, TaskText4, DescriptionText4, false);

            Tile_5 = new Tile(Tile5, TaskText5, DescriptionText5, false);

            Tile_6 = new Tile(Tile6, TaskText6, DescriptionText6, false);

            ListOfTiles = new List<Tile> { Tile_1, Tile_2, Tile_3, Tile_4, Tile_5, Tile_6 };
        }
        public void DeleteTile(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement frameworkElement)
            {
                var xNameProperty = frameworkElement.GetType().GetProperty("Name");
                if (xNameProperty != null)
                {
                    //parsing x:Name string from delete button to know which tile we have to delete
                    string xNameValue = xNameProperty.GetValue(frameworkElement) as string;
                    int j = xNameValue[xNameValue.Length - 1] - 49;
                    //Saving smallest index of deleted tile so we know where to put one with add button
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

        public void Shutdown_app(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
    public class Tile
    {
        public bool isUsed;
        public Grid tile;
        public TextBlock TaskText;
        public TextBlock DescriptionText;
        public Tile(Grid _tile, TextBlock _TaskText, TextBlock _DescriptionText, bool _isUsed)
        {
            this.DescriptionText = _DescriptionText;
            this.TaskText = _TaskText;
            this.tile = _tile;
            this.isUsed = _isUsed;
        }
    }
    


}
