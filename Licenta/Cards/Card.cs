using System;
using System.Collections.Generic;
using Enumerations;

namespace Cards
{
    public class Card
    {
        private CardTypes cardType;
        private List<Action> cardEffects = new List<Action>();
        private int cardCost;

        public Card()
        {

        }

        public Card(CardTypes cardType, List<Action> actions,int cardCost=1)
        {
            this.CardType = cardType;
            this.CardEffects = actions;
            this.CardCost = cardCost;
        }

        public CardTypes CardType
        {
            get
            {
                return this.cardType;
            }
            set
            {
                this.cardType = value;
            }
        }
        public int CardCost
        {
            get
            {
                return this.cardCost;
            }
            set
            {
                this.cardCost = value;
            }
        } 
        public List<Action> CardEffects
        {
            get
            {
                return this.cardEffects;
            }
            set
            {
                this.cardEffects = value;
            }
        }

        public void UseCard()
        {
            foreach (var action in CardEffects)
            {
                action();                
            }
        }
    }
}
