using Characters;
using Engines;
using Licenta;
using Map;
using System.Windows.Controls;

namespace UI
{
    public class UserInterface
    {
        private ContentControl window;
        private Player player;
        private Enemy enemy;
        private Room room;
        private GameEngine gameEngine;
        private StartScreen startScreen;
        private GameScreen gameScreen;
        private RewardScreen rewardScreen;
        private EndGameScreen endGameScreen;
        private string enemyIntent;
        private int gameStatus;

        public UserInterface()
        {

        }

        public UserInterface(ContentControl window, Player player, Room room, GameEngine gameEngine)
        {
            this.Window = window;
            this.Player = player;
            this.Room = room;
            this.Enemy = Room.Enemy;
            this.GameEngine = gameEngine;
            this.EnemyIntent = gameEngine.EnemyIntent;
            this.StartScreen = new StartScreen(this);
            window.Content = this.StartScreen;
        }

        

        public ContentControl Window
        {
            get
            {
                return this.window;
            }
            set
            {
                this.window = value;
            }
        }
        public Player Player
        {
            get
            {
                return this.player;
            }
            set
            {
                this.player = value;
            }
        }
        public Enemy Enemy
        {
            get
            {
                return this.enemy;
            }
            set
            {
                this.enemy = value;
            }
        }
        public Room Room
        {
            get
            {
                return this.room;
            }
            set
            {
                this.room = value;
            }
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

        public StartScreen StartScreen
        {
            get
            {
                return this.startScreen;
            }
            set
            {
                this.startScreen = value;
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
        public RewardScreen RewardScreen
        {
            get
            {
                return this.rewardScreen;
            }
            set
            {
                this.rewardScreen = value;
            }
        }
        public EndGameScreen EndGameScreen
        {
            get
            {
                return this.endGameScreen;
            }
            set
            {
                this.endGameScreen = value;
            }
        }
        public string EnemyIntent
        {
            get
            {
                return this.enemyIntent;
            }
            set
            {
                this.enemyIntent = value;
            }
        }

        public int GameStatus
        {
            get
            {
                return this.gameStatus;
            }
            set
            {
                this.gameStatus = value;
            }
        }
    }
}
