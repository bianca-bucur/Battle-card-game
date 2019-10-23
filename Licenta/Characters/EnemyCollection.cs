using Actions;
using Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Characters
{
    public class EnemyCollection
    {
        public Dictionary<string, Enemy> enemyCollection;
        private CardActions actions;
        private Player player;
        private Random rnd = new Random();

        public EnemyCollection()
        {

        }

        public EnemyCollection(Player player)
        {
            this.Actions = new CardActions();
            this.Player = player;
            enemyCollection = new Dictionary<string, Enemy>();
            enemyCollection.Add("E0", new Enemy("/Resources/Enemy3.png", 21, 5, 10, new int[] { 0 },new List<CardTypes> { CardTypes.Offence }));
            enemyCollection.Add("E1", new Enemy("/Resources/Enemy4.png", 60, 7, 11, new int[] { 0, 0, 1 }, new List<CardTypes> { CardTypes.Offence, CardTypes.Skill }));
            enemyCollection.Add("E2", new Enemy("/Resources/Enemy5.png", 42, 3, 8, new int[] { 2, 0, 0, 0, 1 }, new List<CardTypes> { CardTypes.Offence, CardTypes.Skill, CardTypes.Defence }));
            enemyCollection.Add("E3", new Enemy("/Resources/Enemy6.png", 30, 5, 12, new int[] { 0, 0, 0, 0, 1 }, new List<CardTypes> { CardTypes.Offence, CardTypes.Skill }));
            enemyCollection.Add("E4", new Enemy("/Resources/Enemy7.png", 35, 7, 10, new int[] { 0, 0, 0, 1, 0, 0, 2 }, new List<CardTypes> { CardTypes.Offence, CardTypes.Skill, CardTypes.Skill }));
            enemyCollection.Add("E5", new Enemy("/Resources/Enemy3.png", 25, 2, 8, new int[] { 0, 1, 0 }, new List<CardTypes> { CardTypes.Offence, CardTypes.Skill }));
            enemyCollection.Add("E6", new Enemy("/Resources/Enemy4.png", 48, 5, 8, new int[] { 0, 0, 1, 0, 0, 0, 1 }, new List<CardTypes> { CardTypes.Offence, CardTypes.Skill }));
            enemyCollection.Add("E7", new Enemy("/Resources/Enemy5.png", 60, 3, 7, new int[] { 0, 1, 0, 0, 0, 1 }, new List<CardTypes> { CardTypes.Offence, CardTypes.Defence },true));
            enemyCollection.Add("E8", new Enemy("/Resources/Enemy6.png", 29, 5, 10, new int[] { 0, 0, 2, 0, 1, 0 }, new List<CardTypes> { CardTypes.Offence, CardTypes.Skill, CardTypes.Skill }));
            enemyCollection.Add("E9", new Enemy("/Resources/Enemy7.png", 30, 10, 14, new int[] { 0, 0, 0, 0, 1 }, new List<CardTypes> { CardTypes.Offence, CardTypes.Skill }));
            enemyCollection.Add("E10", new Enemy("/Resources/Enemy5.png", 40, 5, 8, new int[] { 0, 0, 2, 0, 1, 0 }, new List<CardTypes> { CardTypes.Offence, CardTypes.Skill, CardTypes.Skill }));
            foreach (var enemy in enemyCollection)
            {
                enemy.Value.Actions= new List<Action> { new Action(() => Actions.Attack(this.Player, this.enemyCollection.ElementAt(0).Value, 1/*rnd.Next(4, 8)*/)) };
            }
            enemyCollection.ElementAt(1).Value.Actions.AddRange(new List<Action> { new Action(() => Actions.SubstractStrength(this.Player, 1)) });
            enemyCollection.ElementAt(2).Value.Actions.AddRange(new List<Action> { new Action(() => Actions.SubstractStrength(this.Player, 1)),
                                                                                   new Action(() => Actions.Defend(this.enemyCollection.ElementAt(2).Value,10)) });
            enemyCollection.ElementAt(3).Value.Actions.AddRange(new List<Action> { new Action(() => Actions.SubstractShieldPoints(this.Player, 2)) });
            enemyCollection.ElementAt(4).Value.Actions.AddRange(new List<Action> { new Action(() => Actions.SubstractShieldPoints(this.Player, 2)),
                                                                                   new Action(() => Actions.SubstractStrength(this.Player,1)) });
            enemyCollection.ElementAt(5).Value.Actions.AddRange(new List<Action> { new Action(() => Actions.AddStrength(this.enemyCollection.ElementAt(4).Value, 2)) });
            enemyCollection.ElementAt(6).Value.Actions.AddRange(new List<Action> { new Action(() => Actions.ForbidAttack(this.Player)) });
            enemyCollection.ElementAt(7).Value.Actions.AddRange(new List<Action> { new Action(() => Actions.Defend(this.enemyCollection.ElementAt(2).Value, 10)) });
            enemyCollection.ElementAt(8).Value.Actions.AddRange(new List<Action> { new Action(() => Actions.ForbidAttack(this.Player)),
                                                                                   new Action(() => Actions.AddStrength(this.enemyCollection.ElementAt(8).Value, 2)) });
            enemyCollection.ElementAt(9).Value.Actions.AddRange(new List<Action> { new Action(() => Actions.Heal(this.enemyCollection.ElementAt(9).Value, 10)) });
            enemyCollection.ElementAt(10).Value.Actions.AddRange(new List<Action> { new Action(() => Actions.Heal(this.enemyCollection.ElementAt(9).Value, 5)),
                                                                                    new Action(() => Actions.SubstractShieldPoints(this.Player, 1))});
        }

        public CardActions Actions
        {
            get
            {
                return this.actions;
            }
            set
            {
                this.actions = value;
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
    }
}
