using System.Windows;
using System.Windows.Controls;
using UI;

namespace Licenta
{
    public partial class EndGameScreen : UserControl
    {
        private UserInterface ui;

        public EndGameScreen(UserInterface ui)
        {
            InitializeComponent();
            this.UI = ui;
            SetEndText();
        }

        private void SetEndText()
        {
            if (this.ui.GameStatus == 1)
            {
                endText.Text = "Congratulations! You beat the game!";
            }
            else
            {
                endText.Text = "You have been defeated!";
            }
        }

        private void ReturnToMenu(object sender, RoutedEventArgs e)
        {
            this.UI.Window.Content = new StartScreen(this.UI);
        }

        public UserInterface UI
        {
            get
            {
                return this.ui;
            }
            set
            {
                this.ui = value;
            }
        }
    }
}
