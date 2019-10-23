using System;

namespace Characters
{
    public class Character
    {
        private int maxHealthPoints;
        private int healthPoints;
        private int defencePoints;
        private int shieldPoints;
        private int strengthPoints;
        private string name;
        private bool canAttack;
        private bool activeShield;
        private bool activeRetaliation;

        public Character()
        {

        }

        public Character(int healthPoints, int defencePoints, string name, int shieldPoints = 0, int strengthPoints = 0, bool canAttack = true)
        {
            this.HealthPoints = healthPoints;
            this.DefencePoints = defencePoints;
            this.ShieldPoints = shieldPoints;
            this.StrengthPoints = strengthPoints;
            this.Name = name;
            this.CanAttack = canAttack;
        }

        public int HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                this.healthPoints = value;
            }
        }
        public int DefencePoints
        {
            get
            {
                return this.defencePoints;
            }
            set
            {
                this.defencePoints = value;
            }
        }
        public int ShieldPoints
        {
            get
            {
                return this.shieldPoints;
            }
            set
            {
                this.shieldPoints = value;
            }
        }
        public int StrengthPoints
        {
            get
            {
                return this.strengthPoints;
            }
            set
            {
                this.strengthPoints = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length > 0 && value.Length <= 30)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(string.Empty, "Name length value out of range!");
                }
            }
        }
        public bool CanAttack
        {
            get
            {
                return this.canAttack;
            }
            set
            {
                this.canAttack = value;
            }
        }
        public int MaxHealthPoints
        {
            get
            {
                return this.maxHealthPoints;
            }
            set
            {
                this.maxHealthPoints = value;
            }
        }
        public bool ActiveShield
        {
            get
            {
                return this.activeShield;
            }
            set
            {
                this.activeShield = value;
            }
        }
        public bool ActiveRetaliation
        {
            get
            {
                return this.activeRetaliation;
            }
            set
            {
                this.activeRetaliation = value;
            }
        }
    }
}
