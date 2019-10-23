using Engines;
using System.Windows;

namespace Licenta
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GameEngine gameEngine = new GameEngine(this.screenContent);
        }
    }
}
