using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using System.Net.NetworkInformation;
using System.Timers;
using System.Threading;

namespace Mugen
{
    public partial class MainWindow : Window
    {
        private bool isSortedAscending = true;
        int counter = 0;
        private System.Timers.Timer timer;
        private int m_counter = 2700;
        private bool isTimerRunning = false;
        Tile Tile_1;
        Tile Tile_2;
        Tile Tile_3;
        Tile Tile_4;
        Tile Tile_5;
        Tile Tile_6;
        int k = 0;
        public bool IsPlaceForTile = true;
        public List<Tile> ListOfTiles = new List<Tile>();
        public BindingList<Deadline> ListOfDeadlines = new BindingList<Deadline>();
        public List<TileToJson> ListOfTilesToJson = new List<TileToJson>();
        public List<DeadlinesToJson> DeadlinesToJson = new List<DeadlinesToJson>();
        int i = 0;
        public MainWindow()
        {
            InitializeComponent();
            CreateListOfTiles();
            GetTilesFromJson();
            GetDeadlinesFromJson();
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += OnTimerElapsed;
        }
        public void StartCounter(object sender, RoutedEventArgs e)
        {
            if (!isTimerRunning)
            {
                StartStopTimer.Content = "Stop";
                TimerTypeText.Text = "Focus";
                isTimerRunning = true;
                timer.Start();
            }
            else
            {
                StartStopTimer.Content = "Start";
                TimerTypeText.Text = "Break";
                isTimerRunning = false;
                timer.Stop();
            }

        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            m_counter--;
            int minutes = m_counter / 60;
            int seconds = m_counter % 60;

            TimerText.Dispatcher.Invoke(() =>
            {
                TimerText.Text = $"{minutes:D2}:{seconds:D2}";
            });

            if (minutes == 0 && seconds == 0)
            {
                timer.Stop();
                m_counter = 2700;
                TimerText.Dispatcher.Invoke(() =>
                {
                    TimerText.Text = "45:00";
                    StartStopTimer.Content = "Start";
                    TimerTypeText.Text = "Focus";
                });
                isTimerRunning = false;
            }

        }


        private void grdHeader_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public void Add_Tile(object sender, RoutedEventArgs e)
        {
            try
            {
                IsPlaceForTile = true;
                for (int l = 0; l < ListOfTiles.Count; l++)
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
                    MessageBox.Show("Focus on your current goals :)");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
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
                    counter++;
                    break;

                case 1:
                    Deadline Deadline2 = new Deadline(new TextBox(), new DatePicker());
                    Deadline2.SetValues(DeadlineText, DeadLineDate);
                    DeadlinesList.Items.Add(Deadline2);
                    counter++;
                    break;
                case 2:
                    Deadline Deadline3 = new Deadline(new TextBox(), new DatePicker());
                    Deadline3.SetValues(DeadlineText, DeadLineDate);
                    DeadlinesList.Items.Add(Deadline3);
                    counter++;
                    break;
                case 3:
                    Deadline Deadline4 = new Deadline(new TextBox(), new DatePicker());
                    Deadline4.SetValues(DeadlineText, DeadLineDate);
                    DeadlinesList.Items.Add(Deadline4);
                    counter++;
                    break;
                case 4:
                    Deadline Deadline5 = new Deadline(new TextBox(), new DatePicker());
                    Deadline5.SetValues(DeadlineText, DeadLineDate);
                    DeadlinesList.Items.Add(Deadline5);
                    counter++;
                    break;
                default:
                    MessageBox.Show("Focus on your current goals :)");
                    break;
            }
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
        public void SaveDeadlineListToJsonFile(List<Deadline> deadlines, string filePath)
        {
            foreach (var item1 in deadlines)
            {
                
                DeadlinesToJson deadlinesToJson = new DeadlinesToJson();

                    //TO DO: poprawic obsługe no date
                    if (item1.DeadlineTime.SelectedDate.Value.ToString() == "No date")
                    {
                        deadlinesToJson.DateCreationJson = DateTime.Now;
                    }
                    else
                    {
                        deadlinesToJson.DateCreationJson = item1.DeadlineTime.SelectedDate.Value;
                    }

                    deadlinesToJson.DeadlineText = item1.DeadlineText.Text;

                DeadlinesToJson.Add(deadlinesToJson);
            }
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };
            string json = JsonConvert.SerializeObject(DeadlinesToJson, settings);
            File.WriteAllText(filePath, json);
        }

        public void SaveTilesToJsonFile(List<TileToJson> tiles, string filePath)
        {
            foreach (var item1 in ListOfTiles)
            {
                TileToJson tileToJson = new TileToJson();

                tileToJson.DateCreationJson = item1.DateCreation;
                tileToJson.DescriptionTextJson = item1.DescriptionText.Text;
                tileToJson.TaskTextJson = item1.TaskText.Text;
                tileToJson.IsUsedJson = item1.isUsed;

                ListOfTilesToJson.Add(tileToJson);
            }

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };
            string json = JsonConvert.SerializeObject(tiles, settings);

            File.WriteAllText(filePath, json);
        }
        public void GetTilesFromJson()
        {
            string json = System.IO.File.ReadAllText(@"C:\Users\neeflez\Desktop\Mugen\Mugen\Mugen\JsonFiles\Tiles");
            List<TileToJson> ListOfTilesFromJson = JsonConvert.DeserializeObject<List<TileToJson>>(json);
            for (int q = 0; q < ListOfTiles.Count; q++)
            {
                ListOfTiles[q].isUsed = ListOfTilesFromJson[q].IsUsedJson;
                ListOfTiles[q].DescriptionText.Text = ListOfTilesFromJson[q].DescriptionTextJson;
                ListOfTiles[q].TaskText.Text = ListOfTilesFromJson[q].TaskTextJson;
                ListOfTiles[q].DateCreation = ListOfTilesFromJson[q].DateCreationJson; 
                if (ListOfTiles[q].isUsed == true)
                {
                    ListOfTiles[q].tile.Visibility = Visibility.Visible;
                }
            }
        }
        public void GetDeadlinesFromJson()
        {
            string json = System.IO.File.ReadAllText(@"C:\Users\neeflez\Desktop\Mugen\Mugen\Mugen\JsonFiles\Deadlines");
            List<DeadlinesToJson> ListOfDeadlinesFromJson = JsonConvert.DeserializeObject<List<DeadlinesToJson>>(json);

            for (int q = 0; q < ListOfDeadlinesFromJson.Count; q++)
            {
                ListOfDeadlines.Add(new Deadline(new TextBox(), new DatePicker()));
                ListOfDeadlines[q].DeadlineText.Text = ListOfDeadlinesFromJson[q].DeadlineText;
                ListOfDeadlines[q].DeadlineTime.SelectedDate = ListOfDeadlinesFromJson[q].DateCreationJson;
                DeadlinesList.Items.Add(ListOfDeadlines[q]);
            }
            counter = DeadlinesList.Items.Count;
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
            SaveTilesToJsonFile(ListOfTilesToJson, @"C:\Users\neeflez\Desktop\Mugen\Mugen\Mugen\JsonFiles\Tiles");
            List<Deadline> List_of_deadlines = new List<Deadline>(DeadlinesList.Items.Cast<Deadline>());
            SaveDeadlineListToJsonFile(List_of_deadlines, @"C:\Users\neeflez\Desktop\Mugen\Mugen\Mugen\JsonFiles\Deadlines");
            Application.Current.Shutdown();
        }
        public void save_tiles_to_file()
        {
            ListOfTiles.Sort();
        }

        private void ListBoxItem_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Deadline selectedDeadline = (Deadline)DeadlinesList.SelectedItem;

            if (selectedDeadline != null)
            {
                int selectedIndex = DeadlinesList.Items.IndexOf(selectedDeadline);
                if (selectedIndex != -1)
                {
                    List<Deadline> List_of_deadlines = new List<Deadline>(DeadlinesList.Items.Cast<Deadline>());
                    DeadlinesList.Items.Clear();
                    List_of_deadlines.RemoveAt(selectedIndex);
                    foreach (var item in List_of_deadlines)
                    {
                        DeadlinesList.Items.Add(item);
                    }
                    counter--;
                    
                }
            }
        }
    }

    internal interface ICloneable<T>
    {
        T Clone();
    }
}
