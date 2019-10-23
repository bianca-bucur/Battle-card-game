using Engines;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using UI;

namespace Licenta
{
    public partial class GameScreen : UserControl
    {
        private GameEngine gameEngine;
        private int noOfRooms;
        private ContentControl screenContent;
        private UserInterface userInterface;

        public GameScreen(UserInterface userInterface)
        {
            InitializeComponent();
            this.UserInterface = userInterface;
            InitializeHand();
            Button endTurn = this.endTurn;
            endTurn.Click += EndTurn;
            this.enemyName.Content = UserInterface.Room.EnemyName;
            InitiateScreen();
        }


        public void InitializeHand()
        {
            int i = 0;
            foreach (var c in UserInterface.Player.CurrentHand.TheDeck)
            {
                Button b = (Button)this.cardDisplay.Children[i];
                b.IsEnabled = true;
                b.HorizontalContentAlignment = HorizontalAlignment.Center;
                b.Content = c.Key + Environment.NewLine + c.Value.CardCost;
                b.Click += ExecuteMethod;
                if(UserInterface.Player.CanAttack==false)
                {
                    if (c.Value.CardType == Enumerations.CardTypes.Offence)
                    {
                        b.IsEnabled = false;
                    }
                }
                i++;
            };
        }

        public void ClearHand()
        {
            int i = 0;
            foreach (var c in UserInterface.Player.CurrentHand.TheDeck)
            {
                Button b = (Button)this.cardDisplay.Children[i];
                b.Click -= ExecuteMethod;
                i++;
            };
        }

        public void ExecuteMethod(object sender, EventArgs e)
        {
            int i = this.cardDisplay.Children.IndexOf((UIElement)sender);
            UserInterface.GameEngine.ExecuteMethod(i);
            Button b = (Button)this.cardDisplay.Children[i];
            b.IsEnabled = false;
            Storyboard myStoryboard = (Storyboard)enemyImage.Resources["HitStoryboard"];
            Storyboard.SetTarget(myStoryboard.Children.ElementAt(0) as DoubleAnimationUsingKeyFrames, enemyImage);
            myStoryboard.Begin();
            RefreshStats();
        }

        public void RefreshStats()
        {
            pHealthPoints.Text = UserInterface.Player.HealthPoints.ToString();
            pShieldPoints.Text = UserInterface.Player.ShieldPoints.ToString();
            pStrengthPoints.Text = UserInterface.Player.StrengthPoints.ToString();
            pEnergyPoints.Text = UserInterface.Player.EnergyPoints.ToString();
            eHealthPoints.Text = UserInterface.Enemy.HealthPoints.ToString();
            eStrengthPoints.Text = UserInterface.Enemy.StrengthPoints.ToString();
            eShieldPoints.Text = UserInterface.Enemy.ShieldPoints.ToString();
            eIntent.Text = UserInterface.EnemyIntent;
        }

        public void EndTurn(object sender, EventArgs e)
        {
            UserInterface.GameEngine.EndTurn();
            ClearHand();
            InitializeHand();
            RefreshStats();
            UserInterface.Player.ResetPlayer();
        }

        public void InitiateScreen()
        {
            RefreshStats();
            BitmapImage img = new BitmapImage(new Uri("/Resources/Heart.png", UriKind.Relative));
            pHealthImg.Source = img;
            img= new BitmapImage(new Uri("/Resources/Shield.png", UriKind.Relative));
            pShieldImg.Source = img;
            img = new BitmapImage(new Uri("/Resources/Sabers.png", UriKind.Relative));
            pStrengthImg.Source = img;
            img = new BitmapImage(new Uri("/Resources/Energy.png", UriKind.Relative));
            pEnergyImg.Source = img;
            img = new BitmapImage(new Uri("/Resources/HeartE.png", UriKind.Relative));
            eHealthImg.Source = img;
            img = new BitmapImage(new Uri("/Resources/ShieldE.png", UriKind.Relative));
            eShieldImg.Source = img;
            img = new BitmapImage(new Uri("/Resources/SabersE.png", UriKind.Relative));
            eStrengthImg.Source = img;

            img = new BitmapImage(new Uri(this.UserInterface.Enemy.ImagePath, UriKind.Relative));
            this.enemyImage.Source = img;
        }

        private void ExitGame(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public GameEngine GameEngine
        {
            get
            {
                return this.gameEngine;
            }
            set
            {
                this.gameEngine = value;
            }
        }
        public int NoOfRooms
        {
            get
            {
                return this.noOfRooms;
            }
            set
            {
                this.noOfRooms = value;
            }
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

    }
}
