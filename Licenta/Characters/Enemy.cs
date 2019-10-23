using System;
using System.Collections.Generic;
using System.Linq;
using Enumerations;

namespace Characters
{
    public class Enemy : Character
    {
        private List<Action> actions=new List<Action>();
        private List<CardTypes> actionTypes = new List<CardTypes>();
        public int[] attackOrder;
        private int minDmg;
        private int maxDmg;
        private string imagePath;

        public Enemy():base(100,0,"Test Enemy")
        {
        }

        public Enemy(string path, int healthPoints, int minDmg, int maxDmg, int[] attackOrder, List<CardTypes> actionTypes, bool activeShield = false, bool activeRetaliation=false)
        {
            this.HealthPoints = healthPoints;
            this.MinDmg = minDmg;
            this.MaxDmg = maxDmg;
            this.Actions = actions;
            this.attackOrder = attackOrder;
            this.ActionTypes = actionTypes;
            this.ImagePath = path;
        }

        public Enemy(int healthPoints, int minDmg, int maxDmg, List<Action> Actions, int[] attackOrder)
        {
            this.HealthPoints = healthPoints;
            this.MinDmg = minDmg;
            this.MaxDmg = maxDmg;
            this.Actions = actions;
            this.attackOrder = attackOrder;
        }

        public int GetActionIndex(int turn)
        {
            return attackOrder[(turn-1) % attackOrder.Length];
        }

        public string GetIntent(int turn)
        {
            string intent;
            if (ActionTypes.ElementAt(attackOrder[(turn-1) % attackOrder.Length]) == CardTypes.Defence) 
            {
                intent = "Intent: Defend";
            }
            else if(ActionTypes.ElementAt(attackOrder[turn % attackOrder.Length]) == CardTypes.Offence)
            {
                intent = "Intent: Attack";
            }
            else
            {
                intent = "Intent: Skill";
            }
            return intent;
        }

        public void ExecuteAction(int actionIndex)
        {
            Actions.ElementAt(actionIndex)();
        }

        public List<Action> Actions
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


        public int MinDmg
        {
            get
            {
                return this.minDmg;
            }
            set
            {
                this.minDmg = value;
            }
        }

        public int MaxDmg
        {
            get
            {
                return this.maxDmg;
            }
            set
            {
                this.maxDmg = value;
            }
        }

        public List<CardTypes> ActionTypes
        {
            get
            {
                return this.actionTypes;
            }
            set
            {
                this.actionTypes = value;
            }
        }

        public string ImagePath
        {
            get
            {
                return this.imagePath;
            }
            set
            {
                this.imagePath = value;
            }
        }
    }
}
