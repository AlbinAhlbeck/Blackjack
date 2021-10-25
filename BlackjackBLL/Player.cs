using BlackjackBLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Player
    {
        private Hand hand;
        private bool isFinished;
        private string name;
        private bool winner;
        private bool fat;

        public Player(string name)
        {
            this.name = name;
            hand = new Hand();
        }

        public void DrawCard(Card card)
        {
            hand.Add(card);
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

        public bool Fat
        {
            get
            {
                return fat;
            }
            set
            {
                fat = value;
            }
        }

      

        public bool IsFinished
        {
            get
            {
                return isFinished;
            }
            set
            {
                isFinished = value;
            }
        }

        public bool Play()
        {
            return true;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Result()
        {
            return name + " Score: " + hand.Total();
        }

        

    }
}
