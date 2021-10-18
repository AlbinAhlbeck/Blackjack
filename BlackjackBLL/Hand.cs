using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackBLL
{
    class Hand
    {
        private List<Card> cards;
        public Hand()
        {
            cards = new List<Card>();
        }

        public void Add(Card card)
        {
            cards.Add(card);
        }

        public int Total()
        {
            int total = 0;

            for (int i = 0; i < cards.Count; i++)
            {
                total += cards[i].CardValue;
            }

            return total;
        }
    }
}
