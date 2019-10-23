using Cards;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UI;

namespace Licenta
{
    public partial class RewardScreen : UserControl
    {
        private List<KeyValuePair<string, Card>> generatedRewardCards;
        private Deck playerDeck;
        private ContentControl screenContent;
        private GameScreen gameScreen;
        private UserInterface userInterface;

        public RewardScreen(List<KeyValuePair<string, Card>> generatedRewardCards, Deck playerDeck, ContentControl screenContent, UserInterface userInterface)
        {
            InitializeComponent();
            this.generatedRewardCards = generatedRewardCards;
            this.ScreenContent = screenContent;
            this.PlayerDeck = playerDeck;
            this.UserInterface = userInterface;
            ShowRewards();
        }

        public void SelectCard(object sender, RoutedEventArgs e)
        {
            int i = this.rewards.Children.IndexOf((UIElement)sender);
            this.PlayerDeck.AddCard(generatedRewardCards.ElementAt(i).Key, generatedRewardCards.ElementAt(i).Value);
            foreach (var c in rewards.Children)
            {
                Button b = (Button)c;
                b.IsEnabled = false;
            }
        }

        public void ShowRewards()
        {
            int i = 0;
            foreach (var c in generatedRewardCards)
            {
                Button b = (Button)rewards.Children[i];
                b.IsEnabled = true;
                b.Content = c.Key + " " + c.Value.CardCost;
                i++;
            };
        }

        private void Continue(object sender, RoutedEventArgs e)
        {
            screenContent.Content = new GameScreen(UserInterface);
        }

        public ContentControl ScreenContent
        {
            get
            {
                return this.screenContent;
            }
            set
            {
                this.screenContent = value;
            }
        }

        public GameScreen GameScreen
        {
            get
            {
                return this.gameScreen;
            }
            set
            {
                this.gameScreen = value;
            }
        }


        public UserInterface UserInterface
        {
            get
            {
                return this.userInterface;
            }
            set
            {
                this.userInterface = value;
            }
        }

        public Deck PlayerDeck
        {
            get
            {
                return this.playerDeck;
            }
            set
            {
                this.playerDeck = value;
            }
        }
    }
}
