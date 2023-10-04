using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using WordleCopy_v1._0.Model;
using WordleCopy_v1._0.ViewModel;

namespace WordleCopy_v1._0.View.UserControls
{

    public partial class MyTextBox : TextBox
    {
        public MyTextBox()
        {
            InitializeComponent();
        }

        void MoveToNextBox(KeyEventArgs e)
        {
            FocusNavigationDirection nextBox = FocusNavigationDirection.Next;
            TraversalRequest request = new TraversalRequest(nextBox);
            UIElement? currentBox = Keyboard.FocusedElement as UIElement;
            if (currentBox != null)
            {
                if (currentBox.MoveFocus(request)) 
                    e.Handled = true;

            }
        }
        void MoveToPreviousBox(KeyEventArgs e)
        {
            FocusNavigationDirection nextBox = FocusNavigationDirection.Previous;
            TraversalRequest request = new TraversalRequest(nextBox);
            UIElement? currentBox = Keyboard.FocusedElement as UIElement;
            if (currentBox != null)
            {
                if (currentBox.MoveFocus(request)) 
                    e.Handled = true;

            }
        }


        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            int col = Grid.GetColumn(textBox);

            if (e.Key == Key.Enter)
            {
                if (CheckValidGuess()) 
                {
                    ValidateBoxes();
                    
                }                    
                else
                    Animate.AnimateShake();
            }
            else if (e.Key >= Key.A && e.Key <= Key.Z)
            {
                if (e.Key != Key.Space)
                {
                    if (col == 4 && (textBox.Text == "" || textBox.Text == " ")) 
                    {
                        Animate.DepressedAnimation(textBox);
                        textBox.Text = e.Key.ToString();
                        return;
                    }

                    if (col < 4) 
                    {
                        
                        Animate.DepressedAnimation(textBox);
                        textBox.Text = e.Key.ToString();
                        MoveToNextBox(e);
                    }
                        
                }
                
            }
            

        }

        private void TextValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (sender is TextBox tb)
            {
                int col = Grid.GetColumn(tb);

                if (e.Key == Key.Space)
                    e.Handled = true;
                else if (e.Key == Key.Back || e.Key == Key.Left)
                {
                    if(!string.IsNullOrEmpty(tb.Text))
                        tb.Text = "";
                    else
                        if (col > 0)
                            MoveToPreviousBox(e);
                    
                }

            }

        }
        private static async Task ValidateBoxes()
        {
            bool correct = true;
            string word = MainWindow.sampleRandomWord;
            //BrushConverter converter = new BrushConverter();
            SolidColorBrush brushGreen = new SolidColorBrush(Color.FromArgb(0xFF, 0x4B, 0xAB, 0x4B));
            SolidColorBrush brushYellow = new SolidColorBrush(Color.FromArgb(0xFF, 0xCC, 0xCC, 32));


            int j = 0;
            for (int i = (MainWindow.GuessCounter * 5) - 5; i < (MainWindow.GuessCounter * 5); i++)
            {
                Animate.Flip(MainWindow.tiles[i]);
                await Task.Delay(500);
                if (MainWindow.tiles[i].Text == word[j].ToString())
                {
                    MainWindow.KeyboardKeys[MainWindow.tiles[i].Text].Background = brushGreen;
                    MainWindow.tiles[i].Background = brushGreen;
                }
                else if (word.Contains(MainWindow.tiles[i].Text) && MainWindow.tiles[i].Text != "") 
                {
                    if (!((MainWindow.KeyboardKeys[MainWindow.tiles[i].Text].Background as SolidColorBrush)?.Color == brushGreen.Color))
                    {
                        MainWindow.KeyboardKeys[MainWindow.tiles[i].Text].Background = brushYellow;
                    }

                    MainWindow.tiles[i].Background = brushYellow;
                    correct = false;
                }
                else 
                {
                    MainWindow.KeyboardKeys[MainWindow.tiles[i].Text].IsEnabled = false;
                    correct = false; 
                
                }
                
                MainWindow.tiles[i].IsHitTestVisible = false;
                MainWindow.tiles[i].IsTabStop = false;
                j++;
            }

            if (correct)
            {
                MainWindow mother = (MainWindow)Application.Current.MainWindow;
                ResultView resultView = new ResultView(mother,MainWindow.GuessCounter,MainWindow.sampleRandomWord);
                resultView.ShowDialog();
                return;
            }
            MainWindow.GuessCounter++;
            EnableNextRow(MainWindow.GuessCounter);

        }

        private static void EnableNextRow(int row)
        {
            if (row <= 5)
            {
                for (int i = (row * 5) - 5; i < (row * 5); i++)
                {
                    MainWindow.tiles[i].IsHitTestVisible = true;
                    MainWindow.tiles[i].IsTabStop = true;
                }
                MainWindow.tiles[(row * 5) - 5].Focus();
            }
            else
            {
                MainWindow mother = (MainWindow)Application.Current.MainWindow;
                ResultView resultView = new ResultView(mother,6,MainWindow.sampleRandomWord);
                resultView.ShowDialog();
            }
        }

        private bool CheckValidGuess()
        {
            StringBuilder guess = new StringBuilder();
            int j = 0;
            for (int i = (MainWindow.GuessCounter * 5) - 5; i < (MainWindow.GuessCounter * 5); i++)
            {
                if (!(MainWindow.tiles[i].Text != null && MainWindow.tiles[i].Text != ""))
                    return false;
                else
                    guess.Append(MainWindow.tiles[i].Text);
            }
            
            if (AppViewModel.ValidWords.Rows.Contains(guess.ToString().ToLower()))
            {
                if (AppViewModel.ValidGuesses.Contains(guess.ToString()))
                {
                    return false;
                }
                else
                {
                    AppViewModel.ValidGuesses.Add(guess.ToString());
                    return true;
                }
            }
            else if (MainWindow.sampleRandomWord == guess.ToString())
            {
                StreamWriter streamWriter = new StreamWriter("FiveLetterWords.txt", true);
                streamWriter.WriteLine(guess.ToString().ToLower());
                streamWriter.Close();
                AppViewModel.ValidWords.Rows.Add(guess.ToString().ToLower());
                return true;
            }
            else
            {
                return false;
            }   
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            textBox.Clear();
        }
    }
}
