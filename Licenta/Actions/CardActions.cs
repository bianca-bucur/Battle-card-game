using Cards;
using Characters;
using System;
using System.Linq;

namespace Actions
{
    public class CardActions
    {
        public void Attack(Character target, Character caster, int damagePoints)
        {
            int actualDamage;
            if (caster.GetType() == typeof(Enemy))
            {
                Random rnd = new Random();
                Enemy e = (Enemy)caster;
                int dmgPoints = rnd.Next(e.MinDmg, e.MaxDmg);
                actualDamage = dmgPoints + caster.StrengthPoints;
            }
            else
            {
                actualDamage = damagePoints + caster.StrengthPoints;
            }
            if (target.ActiveRetaliation)
            {
                Attack(caster, target, 3);
            }
            if (target.ShieldPoints >= actualDamage)
            {
                target.ShieldPoints -= actualDamage;
            }
            else
            {
                target.HealthPoints -= actualDamage + target.ShieldPoints;
                if (target.HealthPoints <= 0)
                {
                    target.HealthPoints = 0;
                }
            }
        }

        public void Defend(Character caster, int shieldPoints)
        {
            caster.ShieldPoints += shieldPoints + caster.DefencePoints;
        }

        public void Heal(Character caster, int healthPoints)
        {
            caster.HealthPoints += healthPoints;
            if (caster.HealthPoints >= caster.MaxHealthPoints)
            {
                caster.HealthPoints = caster.MaxHealthPoints;
            }
        }

        public void AddShieldPoints(Character target, int defencePoints)
        {
            target.DefencePoints += defencePoints;
        }

        public void SubstractShieldPoints(Character target, int defencePoints)
        {
            if (target.DefencePoints >= -3)
            {
            target.DefencePoints -= defencePoints;
            }
        }

        public void AddEnergy(Player target,int additionalEnergyPoints)
        {
            target.EnergyPoints += additionalEnergyPoints;     
        }
        
        public void AddStrength(Character target, int strengthPoints)
        {
            target.StrengthPoints += strengthPoints;
        }

        public void SubstractStrength(Character target, int strengthPoints)
        {
            if (target.StrengthPoints >= -3)
            {
            target.StrengthPoints -= strengthPoints;
            }
        }

        public void DrawCards(Deck sourceDeck, Deck destinationDeck, int cardCount)
        {
            for (int i = 0; i < cardCount; i++)
            {
                destinationDeck.AddCard(sourceDeck.TheDeck.ElementAt(sourceDeck.TheDeck.Count() - 1 ).Key, sourceDeck.TheDeck.ElementAt(sourceDeck.TheDeck.Count() - 1).Value);
                sourceDeck.RemoveCard(sourceDeck.TheDeck.Count() - 1 );
            }
        }

        public void ForbidAttack(Character target)
        {
            target.CanAttack = false;
        }

        public void ReduceCost(Player player)
        {
            foreach(var c in player.CurrentHand.TheDeck)
            {
                c.Value.CardCost = 0;
            }
        }

        public void ActivateShield(Character character)
        {
            character.ActiveShield = true;
        }

        public void ActivateMirror(Character character)
        {
            character.ActiveRetaliation = true;
        }
    }
}
