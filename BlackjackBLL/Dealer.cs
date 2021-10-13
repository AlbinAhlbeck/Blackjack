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

        public Dealer(GameManager gameManager, Deck deck)
        {
            this.gameManager = gameManager;
            this.deck = deck;
        }

        public Card DealCard()
        {
            return deck.DealCard();
        }
    }
}
