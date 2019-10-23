using System;
using System.Linq;
using Characters;

namespace Map
{
    public class Room
    {
        private Enemy enemy;
        private Player player;
        private EnemyCollection enemyCollection;
        private string enemyName;
        private int currentTurn;

        public Room()
        {

        }

        public Room(Player player)
        {
            this.CurrentTurn = 0;
            this.Player = player;
            EnemyCollection = new EnemyCollection(Player);
            GenerateEnemy();
        }

        public void GenerateEnemy()
        {
            Random rnd = new Random();
            int enemyIndex = rnd.Next(0, EnemyCollection.enemyCollection.Count() - 1);
            this.Enemy = EnemyCollection.enemyCollection.ElementAt(enemyIndex).Value;
            this.EnemyName = EnemyCollection.enemyCollection.ElementAt(enemyIndex).Key;
            this.EnemyCollection.enemyCollection.Remove(EnemyCollection.enemyCollection.ElementAt(enemyIndex).Key);
        }

        public void GenerateNewRoom()
        {
            GenerateEnemy();
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
        public string EnemyName
        {
            get
            {
                return this.enemyName;
            }
            set
            {
                this.enemyName = value;
            }
        }
        public int CurrentTurn
        {
            get
            {
                return this.currentTurn;
            }
            set
            {
                this.currentTurn = value;
            }
        }
        public EnemyCollection EnemyCollection
        {
            get
            {
                return this.enemyCollection;
            }
            set
            {
                this.enemyCollection = value;
            }
        }
    }
}
