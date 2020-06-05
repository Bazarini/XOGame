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

namespace OXGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameManager _gameManager;

        public MainWindow()
        {
            InitializeComponent();
            _gameManager = new GameManager();

        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {

            string bName = ((Button)sender).Name;
            ((Button)sender).Content = _gameManager.currentPlayer.Character;
            ((Button)sender).IsEnabled = false;
            if (_gameManager.ChangeCell(Int32.Parse(bName.Substring(1, 1)), int.Parse(bName.Substring(2, 1))))
            {
                MessageBox.Show($"{_gameManager.currentPlayer.Name} won!");
                _gameManager.NewGame();
                OWons.Content = _gameManager.SP.Wons;
                XWons.Content = _gameManager.FP.Wons;
                UnmuteButtons();
            }
        }
        private (string, string) GetPlayers()
        {
            if (P1.Text == "" || P2.Text == "")
            {
                MessageBox.Show("Enter Players Names.");
                return (null, null);
            }
            P1.IsEnabled = false;
            P2.IsEnabled = false;
            return (P1.Text, P2.Text);
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            (string, string) players = GetPlayers();
            if (!string.IsNullOrEmpty(players.Item1) && !string.IsNullOrEmpty(players.Item2))
            {
                _gameManager.NewGame(players.Item1, players.Item2);
                UnmuteButtons();
            }

        }
        private void UnmuteButtons()
        {
            foreach (Button button in Grid1.Children.OfType<Button>())
            {
                if (button != NewGame)
                {
                    button.Content = "";
                    button.IsEnabled = true;
                }
            }

        }
    }
}
