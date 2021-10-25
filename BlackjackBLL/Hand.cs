using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackBLL
{
    public class Hand
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

        public List<Uri> GetPaths()
        {
            List<Uri> tempList = new List<Uri>();
            for (int i = 0; i < cards.Count; i++)
            {
                tempList.Add(cards[i].ImagePath);
            }
            return tempList;
        }
    }
}
