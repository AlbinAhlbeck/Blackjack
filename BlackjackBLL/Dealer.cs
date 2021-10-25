using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackBLL
{
    class Dealer
    {
        private Deck deck;
        private Hand hand;

        public Dealer(Deck deck)
        {

            this.deck = deck;
            hand = new Hand();
        }

        public Card PlaceCard()
        {

            Card card = deck.DealCard();
            if (card == null)
            {
                Debug.WriteLine("Dealer card draw is null");
            }
            else
            {             
                hand.Add(card);
                return card;
            }
            return null;
        }

        public Card DealCard()
        {

            Card card = deck.DealCard();
            if (card == null)
            {
                Debug.WriteLine("Dealer card draw is null");
            }
            else
            {
                        
                return card;
            }
            return null;
        }

        public int Total()
        {
           return hand.Total();
        }

        public Hand Hand
        {
            get
            {
                return hand;
            }
            set
            {
                hand = value;
            }
        }

        public string Result()
        {
            return "Dealer " + " Score: " + Total();
        }
    }
}
