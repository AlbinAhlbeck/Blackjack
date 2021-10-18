using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackBLL
{
    class Dealer
    {
        private GameManager gameManager;
        private Deck deck;
        private Hand hand;

        public Dealer(GameManager gameManager, Deck deck)
        {
            this.gameManager = gameManager;
            this.deck = deck;
            hand = new Hand();
        }

        public Card DealCard()
        {
            Card card = deck.DealCard();
            hand.Add(card);
            return card;
        }

        public int Total()
        {
           return hand.Total();
        }
    }
}
