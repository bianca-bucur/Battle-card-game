using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using UI;

namespace Licenta
{
    public partial class StartScreen : UserControl
    {
        private int noOfRooms;
        private UserInterface userInterface;

        public StartScreen(UserInterface userInterface)
        {
            InitializeComponent();
            this.UserInterface = userInterface;
            this.NoOfRooms = 5;
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            this.UserInterface.Window.Content = new GameScreen(UserInterface);
        }

        private void SetNoOfRooms(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            this.NoOfRooms = System.Convert.ToInt32(b.Content.ToString());
            this.UserInterface.GameEngine.NoOfRooms = this.NoOfRooms;
            b.Background = Brushes.Lavender;
            foreach(var btn in roomButtons.Children)
            {
                Button a = (Button)btn;
                if (roomButtons.Children.IndexOf(a) != roomButtons.Children.IndexOf(b))
                {
                a.Background = Brushes.Black;
                }
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

        private void ExitGame(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
