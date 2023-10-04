using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WordleCopy_v1._0.Model;
using WordleCopy_v1._0.View.UserControls;
using WordleCopy_v1._0.ViewModel;

namespace WordleCopy_v1._0
{

    public partial class MainWindow : Window
    {
        public static Dictionary<string, LastTile>? KeyboardKeys { get; set; }
        public static List<TextBox> tiles = new List<TextBox>();
        public static int GuessCounter;
        public static string? sampleRandomWord;


        public MainWindow()
        {
            AppViewModel vm = new AppViewModel();
            DataContext = vm;
            InitializeComponent();
            CreateTiles();
            CreateKeyboardLayout();
            GuessCounter = 1;

            tile11.Focus();
        }

        private void CreateKeyboardLayout()
        {
            KeyboardKeys = new Dictionary<string, LastTile>
            {
                { "Q", Q },
                { "W", W },
                { "E", E },
                { "R", R },
                { "T", T },
                { "Y", Y },
                { "U", U },
                { "I", I },
                { "O", O },
                { "P", P },
                { "A", A },
                { "S", S },
                { "D", D },
                { "F", F },
                { "G", G },
                { "H", H },
                { "J", J },
                { "K", K },
                { "L", L },
                { "Z", Z },
                { "X", X },
                { "C", C },
                { "V", V },
                { "B", B },
                { "N", N },
                { "M", M }
            };

        }

        private static void ResetTiles() 
        {
            SolidColorBrush brushDefault = new SolidColorBrush(Color.FromArgb(0xFF, 0x3C, 0x32, 0x32));
            foreach (TextBox textBox in tiles)
            {
                textBox.Clear();
                textBox.IsHitTestVisible = false;
                textBox.Background = brushDefault;
                textBox.IsTabStop = false;
            }
        }

        private static void ResetKeyboard() 
        {
            SolidColorBrush brushDefault = new SolidColorBrush(Color.FromArgb(0xFF, 0x3C, 0x32, 0x32));
            foreach (var key in KeyboardKeys) 
            {
                KeyboardKeys[key.Key].IsEnabled = true;
                KeyboardKeys[key.Key].Background = brushDefault;
            }

        }

        public async void ResetGame() 
        {
            GuessCounter = 1;
            ResetTiles();
            ResetKeyboard();
            sampleRandomWord = await FetchRandomWord();
            sampleRandomWord = sampleRandomWord.ToUpper();
            for (int i = 0; i < 5; i++) 
            {
                tiles[i].IsHitTestVisible = true;
                tiles[i].IsTabStop = true;
            }
            
            AppViewModel appViewModel = new AppViewModel();
            this.DataContext = appViewModel;
            tiles[0].Focus();
        }

        private void CreateTiles()
        {
            tiles.Add(tile11); tiles.Add(tile12); tiles.Add(tile13); tiles.Add(tile14); tiles.Add(tile15);
            tiles.Add(tile21); tiles.Add(tile22); tiles.Add(tile23); tiles.Add(tile24); tiles.Add(tile25);
            tiles.Add(tile31); tiles.Add(tile32); tiles.Add(tile33); tiles.Add(tile34); tiles.Add(tile35);
            tiles.Add(tile41); tiles.Add(tile42); tiles.Add(tile43); tiles.Add(tile44); tiles.Add(tile45);
            tiles.Add(tile51); tiles.Add(tile52); tiles.Add(tile53); tiles.Add(tile54); tiles.Add(tile55);
        }

        private async Task<string> FetchRandomWord()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("https://random-word-api.herokuapp.com/word?length=5");

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();

                        string[] words = JsonSerializer.Deserialize<string[]>(json);

                        return words[0];
                    }
                    else
                    {
                        MessageBox.Show("Cannot fetch random word.","Sorry!", MessageBoxButton.OK,MessageBoxImage.Warning);
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        private async void GetRandomWord(object sender, RoutedEventArgs e)
        {
            sampleRandomWord = await FetchRandomWord();
            sampleRandomWord = sampleRandomWord.ToUpper();
            return;
        }

    }
}
