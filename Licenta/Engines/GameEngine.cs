using Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using Cards;
using Licenta;
using UI;
using Map;
using System.Windows.Controls;

namespace Engines
{
    public class GameEngine
    {
        private Player player = new Player();
        private Enemy enemy;
        private CardCollection cardCollection;
        private UserInterface ui;
        private Room room;
        private List<KeyValuePair<string, Card>> rewardCards;
        private int defeatedRooms;
        private int noOfRooms;
        private GameScreen window;
        private RewardScreen rewardScreen;
        private ContentControl screenContent;
        private StartScreen startScreen;
        private string enemyIntent;

        public GameEngine(ContentControl screenContent)
        {
            this.Room = new Room(this.Player);
            this.Enemy = Room.Enemy;
            this.ScreenContent = screenContent;
            screenContent.Content = this.StartScreen;
            this.CardCollection = new CardCollection(this.Player, Enemy);
            GeneratePlayerCards();
            Player.FillHand(5);
            ui = new UserInterface(ScreenContent, Player, Room, this);
            Room.CurrentTurn = 1;
            defeatedRooms = 0;
            this.EnemyIntent = Enemy.GetIntent(Room.CurrentTurn);
            ui.EnemyIntent = this.EnemyIntent;
        }

        public GameEngine(Player player, Enemy enemy,CardCollection cardCollection)
        {
            this.Player = player;
            this.Enemy = enemy;
            this.CardCollection = new CardCollection(player, enemy);
            
        }


        public void GeneratePlayerCards()
        {
            for (int i = 0; i < 4; i++)
            {
                this.Player.FullPlayerDeck.AddCard(CardCollection.allCards.ElementAt(0).Key,CardCollection.allCards.ElementAt(0).Value);
            }
            for (int i = 0; i < 4; i++)
            {
                this.Player.FullPlayerDeck.AddCard(CardCollection.allCards.ElementAt(1).Key, CardCollection.allCards.ElementAt(1).Value);
            }
            for (int i = 0; i < 2; i++) 
            {
                this.Player.FullPlayerDeck.AddCard(CardCollection.allCards.ElementAt(2).Key, CardCollection.allCards.ElementAt(2).Value);
            }
            for (int i = 0; i < 2; i++)
            {
                this.Player.FullPlayerDeck.AddCard(CardCollection.allCards.ElementAt(3).Key, CardCollection.allCards.ElementAt(3).Value);
            }
            for (int i = 0; i < 4; i++)
            {
                this.Player.FullPlayerDeck.AddCard(CardCollection.allCards.ElementAt(4).Key, CardCollection.allCards.ElementAt(4).Value);
            }
        }

        public void ExecuteMethod(int index)
        {
            Action a;
            a = Player.CurrentHand.TheDeck.ElementAt(index).Value.UseCard;
            a();
            Player.EnergyPoints -= Player.CurrentHand.TheDeck.ElementAt(index).Value.CardCost;
            if (Enemy.HealthPoints <= 0)
            {
                defeatedRooms++;
                if (defeatedRooms==this.NoOfRooms)
                {
                    this.defeatedRooms = 0;
                    this.ui.GameStatus = 1;
                    this.ui.Player.ResetPlayerGame();
                    GenerateNewRoom();
                    this.ScreenContent.Content = new EndGameScreen(this.ui);
                }
                else
                {
                    GenerateRewards(3);
                    GenerateNewRoom();
                }
            }
        }

        public void GenerateNewRoom()
        {
            Room.GenerateEnemy();
            this.Enemy = Room.Enemy;
            this.CardCollection.Enemy = this.Enemy;
            this.ui.Enemy = Room.Enemy;
            this.Player.ResetPlayerRoom();
            this.EnemyIntent=Enemy.GetIntent(Room.CurrentTurn);
            ui.EnemyIntent = this.EnemyIntent;
        }

        public void EndTurn()
        {
            this.EnemyIntent=Enemy.GetIntent(Room.CurrentTurn);
            ui.EnemyIntent = this.EnemyIntent;

            Enemy.ExecuteAction(Enemy.GetActionIndex(Room.CurrentTurn));
            if(Player.HealthPoints<=0)
            {
                this.defeatedRooms = 0;
                this.ui.GameStatus = 0;
                this.ui.Player.ResetPlayerGame();
                this.ScreenContent.Content = new EndGameScreen(this.ui);
            }
            else
            {
                Player.ResetPlayer();
                Player.DiscardHand();
                Player.FillHand(5);
                Room.CurrentTurn++;
            }
        }

        public void GenerateRewards(int noOfRewardCards)
        {
            rewardCards = new List<KeyValuePair<string, Card>>();
            Random rnd=new Random();
            for (int i = 0; i < noOfRewardCards; i++)
            {
                int index=rnd.Next(4, cardCollection.allCards.Count() - 1);
                while (rewardCards.Contains(cardCollection.allCards.ElementAt(index)))
                {
                    index=rnd.Next(4, cardCollection.allCards.Count() - 1);
                }
                rewardCards.Add(cardCollection.allCards.ElementAt(index));
            }
            rewardScreen = new RewardScreen(rewardCards, Player.FullPlayerDeck, ScreenContent,ui);
            this.ScreenContent.Content = rewardScreen;
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
        public CardCollection CardCollection
        {
            get
            {
                return this.cardCollection;
            }
            set
            {
                this.cardCollection = value;
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
        public GameScreen Window
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
    }
}
