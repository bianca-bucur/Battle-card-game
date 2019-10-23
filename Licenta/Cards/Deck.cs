using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    public class Deck
    {
        public List<KeyValuePair<string, Card>> TheDeck = new List<KeyValuePair<string, Card>>();
        private Random rnd = new Random();

        public Deck()
        {

        }

        public void AddCard(string cardName, Card newCard)
        {
            TheDeck.Add(new KeyValuePair<string, Card>(cardName,newCard));
        }

        public void RemoveCard(int index)
        {
            TheDeck.RemoveAt(index);
        }

        public void UseCard(int index)
        {
            TheDeck.ElementAt(index).Value.UseCard();
        }
        
        public void Shuffle()
        {
            int n = TheDeck.Count;
            for (int i = 0; i < n; i++)
            {
                int r = i + rnd.Next(n - i);
                KeyValuePair<string, Card> t = TheDeck[r];
                TheDeck[r] = TheDeck[i];
                TheDeck[i] = t;
            }
        }


    }
}
