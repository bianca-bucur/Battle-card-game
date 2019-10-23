using Cards;
using System.Linq;
using System.Windows;

namespace Characters
{
    public class Player : Character
    {
        private int energyPoints;
        private Deck fullPlayerDeck = new Deck();
        private Deck undeltCards = new Deck();
        private Deck currentHand = new Deck();
        private Deck discardDeck = new Deck();

        public Player():base(100,0,"Player",0,0)
        {
            this.UndeltDeck = FullPlayerDeck;
            this.EnergyPoints = 3;
            this.MaxHealthPoints = 100;
        }

        public Player(int energyPoints=3):base(100,0,"Player",0,0)
        {
            this.UndeltDeck = FullPlayerDeck;
            this.MaxHealthPoints = 100;
            this.EnergyPoints = energyPoints;
        }

        public void FillHand(int cardCount)
        {
            int drawnCards = 0;
            this.UndeltDeck.Shuffle();
            while (this.UndeltDeck.TheDeck.Count() > 0 && drawnCards < cardCount)
            {
                this.CurrentHand.AddCard(this.UndeltDeck.TheDeck.Last().Key, this.UndeltDeck.TheDeck.Last().Value);
                this.UndeltDeck.TheDeck.RemoveAt(this.UndeltDeck.TheDeck.Count() - 1);
                drawnCards++;
            }
            if (drawnCards < cardCount)
            {
                MoveCards(this.DiscardDeck, this.UndeltDeck, this.DiscardDeck.TheDeck.Count());
                this.UndeltDeck.Shuffle();
                MoveCards(this.UndeltDeck, this.CurrentHand, cardCount - drawnCards);
            }
        }

        public void DiscardHand()
        {
            MoveCards(this.CurrentHand, this.DiscardDeck, this.CurrentHand.TheDeck.Count());
        }
        
        public void MoveCards(Deck sourceDeck, Deck destinationDeck, int cardCount)
        {
            for (int i = 0; i < cardCount; i++)
            {
                destinationDeck.AddCard(sourceDeck.TheDeck.ElementAt(i).Key, sourceDeck.TheDeck.ElementAt(i).Value);
            }
            sourceDeck.TheDeck.RemoveRange(sourceDeck.TheDeck.Count()  - cardCount, cardCount);
        }

        public void ResetPlayer()
        {
            this.EnergyPoints = 3;
            this.CanAttack = true;
            if (ActiveShield == false) 
            {
            this.ShieldPoints = 0;
            }
        }

        public void ResetPlayerRoom()
        {
            ResetPlayer();
            this.ActiveRetaliation = false;
            this.ActiveShield = false;
            this.DefencePoints = 0;
            this.StrengthPoints = 0;
        }

        public void ResetPlayerGame()
        {
            ResetPlayerRoom();
            this.HealthPoints = 100;
            this.MaxHealthPoints = 100;
            this.UndeltDeck = FullPlayerDeck;
        }

        public int EnergyPoints
        {
            get
            {
                return this.energyPoints;
            }
            set
            {
                if (value >= 0 && value <= 20)
                {
                    this.energyPoints = value;
                }
                else
                {
                    MessageBox.Show("Insufucient enegry!");
                }
            }
        }
        public Deck FullPlayerDeck
        {
            get
            {
                return this.fullPlayerDeck;
            }
            set
            {
                this.fullPlayerDeck = value;
            }
        }
        public Deck UndeltDeck
        {
            get
            {
                return this.undeltCards;
            }
            set
            {
                this.undeltCards = value;
            }
        }
        public Deck CurrentHand
        {
            get
            {
                return this.currentHand;
            }
            set
            {
                this.currentHand = value;
            }
        }
        public Deck DiscardDeck
        {
            get
            {
                return this.discardDeck;
            }
            set
            {
                this.discardDeck = value;
            }
        }
        public void SelectCard()
        {

        }
    }
}
