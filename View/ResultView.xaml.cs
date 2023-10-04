using System;
using System.Windows;

namespace WordleCopy_v1._0.View
{

    public partial class ResultView : Window
    {
        public ResultView(Window parent, int numOfGuesses = 1, string? resultMessage = "")
        {           
            Owner = parent;
            InitializeComponent();
            switch (numOfGuesses)
            {
                case 1:
                    ResultViewTextBox.Text = $"Word in One!\n{resultMessage}";
                    break;
                case 2:
                    ResultViewTextBox.Text = $"Excellent!\n{resultMessage}";
                    break;
                case 3:
                    ResultViewTextBox.Text = $"Great Job!\n{resultMessage}";
                    break;
                case 4:
                    ResultViewTextBox.Text = $"Good!\n{resultMessage}";
                    break;
                case 5:
                    ResultViewTextBox.Text = $"That was clutch!\n{resultMessage}";
                    break;
                default:
                    ResultViewTextBox.Text = $"Aww.. \nWord is {resultMessage}";
                    break;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
                mainWindow.ResetGame();
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }
    }
}
