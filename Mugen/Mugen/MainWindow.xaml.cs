﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shell;

namespace Mugen
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private bool isSortedAscending = true;
        int counter = 0;
        Tile Tile_1;
        Tile Tile_2;
        Tile Tile_3;
        Tile Tile_4;
        Tile Tile_5;
        Tile Tile_6;
        int k = 0;
        public bool IsPlaceForTile = true;
        List<Tile> ListOfTiles = new List<Tile>();
        public BindingList<Deadline> ListOfDeadlines = new BindingList<Deadline>();
        int i = 0;
        public MainWindow()
        {
            InitializeComponent();
            CreateListOfTiles();
        }
        private void grdHeader_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        public void Add_Tile(object sender, RoutedEventArgs e)
        {
            IsPlaceForTile = true;
            for(int l = 0; l < ListOfTiles.Count; l++)
            {
                if (ListOfTiles[l].isUsed == false)
                {
                    ListOfTiles[l].TaskText.Text = textInputTask.Text;
                    ListOfTiles[l].DescriptionText.Text = textInputDescription.Text;
                    ListOfTiles[l].DateCreation = DateTime.Now;
                    ListOfTiles[l].tile.Visibility = Visibility.Visible;
                    ListOfTiles[l].isUsed = true;
                    IsPlaceForTile = false;
                    break;
                }
            }
            if (IsPlaceForTile)
            {
                MessageBox.Show("Everything in moderation :)");
            }
        }
        public void Sort_deadline_list(object sender, RoutedEventArgs e)
        {
            List<Deadline> List_of_deadlines = new List<Deadline>(DeadlinesList.Items.Cast<Deadline>());

            BubbleSort(List_of_deadlines);

            DeadlinesList.Items.Clear();
            foreach (var item in List_of_deadlines)
            {
                DeadlinesList.Items.Add(item);
            }

            isSortedAscending = !isSortedAscending;
        }
        private void BubbleSort(List<Deadline> list)
        {
            int n = list.Count;

            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < n - 1 - i; j++)
                {
                    int comparisonResult = list[j].CompareTo(list[j + 1]);

                    if ((isSortedAscending && comparisonResult > 0) || (!isSortedAscending && comparisonResult < 0))
                    {
                        Deadline temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
            }
        }

        public void Add_Deadline(object sender, RoutedEventArgs e)
        {
            
            switch (counter)
            {
                case 0:
                    Deadline Deadline1 = new Deadline(new TextBox(), new DatePicker());
                    Deadline1.SetValues(DeadlineText, DeadLineDate);
                    DeadlinesList.Items.Add(Deadline1);
                    break;

                case 1:
                    Deadline Deadline2 = new Deadline(new TextBox(), new DatePicker());
                    Deadline2.SetValues(DeadlineText, DeadLineDate);
                    DeadlinesList.Items.Add(Deadline2);
                    break;
                case 2:
                    Deadline Deadline3 = new Deadline(new TextBox(), new DatePicker());
                    Deadline3.SetValues(DeadlineText, DeadLineDate);
                    DeadlinesList.Items.Add(Deadline3);
                    break;
                case 3:
                    Deadline Deadline4 = new Deadline(new TextBox(), new DatePicker());
                    Deadline4.SetValues(DeadlineText, DeadLineDate);
                    DeadlinesList.Items.Add(Deadline4);
                    break;
                case 4:
                    Deadline Deadline5 = new Deadline(new TextBox(), new DatePicker());
                    Deadline5.SetValues(DeadlineText, DeadLineDate);
                    DeadlinesList.Items.Add(Deadline5);
                    break;
                default:
                    MessageBox.Show("Everything in moderation :)");
                    break;
            }
            counter++;
        }
        public void CreateListOfTiles()
        {
            Tile_1 = new Tile(Tile1, TaskText1, DescriptionText1, false, DateTime.Now);

            Tile_2 = new Tile(Tile2, TaskText2, DescriptionText2, false, DateTime.Now);

            Tile_3 = new Tile(Tile3, TaskText3, DescriptionText3, false, DateTime.Now);

            Tile_4 = new Tile(Tile4, TaskText4, DescriptionText4, false, DateTime.Now);

            Tile_5 = new Tile(Tile5, TaskText5, DescriptionText5, false, DateTime.Now);

            Tile_6 = new Tile(Tile6, TaskText6, DescriptionText6, false, DateTime.Now);

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
        public void save_tiles_to_file()
        {
            ListOfTiles.Sort();
        }

       private void ListBoxItem_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        // Pobierz zaznaczony element
        ListBoxItem selectedListBoxItem = (ListBoxItem)DeadlinesList.SelectedItem;

        if (selectedListBoxItem != null)
        {
                // Usuń zaznaczony element z ListBox
                DeadlinesList.Items.Remove(selectedListBoxItem);
        }
    }
    }


    public class Tile 
    {
        public DateTime DateCreation;
        public bool isUsed;
        public Grid tile;
        public TextBlock TaskText;
        public TextBlock DescriptionText;
        public Tile(Grid _tile, TextBlock _TaskText, TextBlock _DescriptionText, bool _isUsed, DateTime _dateCreation)
        {
            this.DescriptionText = _DescriptionText;
            this.TaskText = _TaskText;
            this.tile = _tile;
            this.isUsed = _isUsed;
            this.DateCreation = _dateCreation;
        }


    }
    public class Deadline : IComparable<Deadline>
    {
        TextBox DeadlineText { get; }
        DatePicker? DeadlineTime { get; }

        public Deadline(TextBox _deadlineText, DatePicker? _deadlineTime)
        {
            this.DeadlineText = _deadlineText;
            this.DeadlineTime = _deadlineTime;
        }

        public override string ToString()
        {
            return DeadlineText.Text + "\n" + (DeadlineTime?.SelectedDate?.ToString("dd.MM.yyyy") ?? "No date");
        }

        public int CompareTo(Deadline other)
        {
            if (other == null)
            {
                return 1;
            }

            DateTime? thisDate = this.DeadlineTime?.SelectedDate;
            DateTime? otherDate = other.DeadlineTime?.SelectedDate;

            if (thisDate < otherDate)
            {
                return -1;
            }
            else if (thisDate > otherDate)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void SetValues(TextBox deadlineText, DatePicker? deadlineTime)
        {
            this.DeadlineText.Text = deadlineText.Text;
            this.DeadlineTime.SelectedDate = deadlineTime?.SelectedDate;
        }
    }





}
