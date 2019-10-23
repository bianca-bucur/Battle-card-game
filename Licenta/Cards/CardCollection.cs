using Enumerations;
using System;
using System.Collections.Generic;
using Actions;
using Characters;

namespace Cards
{
    public class CardCollection
    {
        private Player player;
        private Enemy enemy;
        public CardActions CurrentCardActions;
        public Dictionary<string, Card> allCards;

        public CardCollection(Player player, Enemy enemy)
        {
            this.Player = player;
            this.Enemy = enemy;
            CurrentCardActions = new CardActions();
            allCards = new Dictionary<string, Card>
            {
                {"Strike", new Card(CardTypes.Offence, new List<Action>{new Action(()=>CurrentCardActions.Attack(Enemy,Player,7))})  },
                {"Shield & Bash", new Card(CardTypes.Offence, new List<Action>{new Action(()=>CurrentCardActions.Attack(Enemy,Player,5)),
                                                                               new Action(()=>CurrentCardActions.Defend(Player,3))}, 2) },
                {"Strengthen", new Card(CardTypes.Skill, new List<Action>{new Action(()=>CurrentCardActions.AddStrength(Player,2))}) },
                {"Defend", new Card(CardTypes.Defence, new List<Action>{new Action(()=>CurrentCardActions.Defend(Player,5))}) },
                {"Heal", new Card(CardTypes.Skill, new List<Action>{new Action(()=>CurrentCardActions.Heal(Player, 3))}) },
                {"Energize", new Card(CardTypes.Skill, new List<Action>{new Action(()=>CurrentCardActions.AddEnergy(Player,0))}, 0) },
                {"Life Drain", new Card(CardTypes.Offence, new List<Action>{new Action(()=>CurrentCardActions.Attack(Enemy,Player,5)),
                                                                          new Action(()=>CurrentCardActions.Heal(Player,5+Player.StrengthPoints-Enemy.ShieldPoints))}, 2) },
                {"Draw a card", new Card(CardTypes.Skill, new List<Action>{new Action(()=>CurrentCardActions.DrawCards(Player.UndeltDeck,Player.CurrentHand,1))}, 0) },
                {"Puncture", new Card(CardTypes.Offence, new List<Action>{new Action(()=>CurrentCardActions.Attack(Enemy, Player, 3)) }, 0) },
                {"Barrier", new Card(CardTypes.Defence, new List<Action>{new Action(()=>CurrentCardActions.ActivateShield(Player))}, 3) },
                {"Mirror", new Card(CardTypes.Skill, new List<Action>{new Action(()=>CurrentCardActions.ActivateMirror(Player)) }, 3) },
                {"Sale", new Card(CardTypes.Skill, new List<Action>{new Action(()=>CurrentCardActions.ReduceCost(Player))}) }
            };
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

    }
}
