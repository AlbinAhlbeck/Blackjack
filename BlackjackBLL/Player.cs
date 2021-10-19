using BlackjackBLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Player
    {
        private Hand hand;
        private bool isFinished;
        private string name;
        private string playerID;
        private bool winner;
        private GameManager gameManager;

        public Player(Hand hand, string name, GameManager gameManager)
        {
            this.name = name;
            this.hand = hand;
            this.gameManager = gameManager;
        }

        public void DrawCard(Card card)
        {
            Debug.WriteLine(playerID + " drew a " + card.ToString());
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

        public string PlayerID
        {
            get
            {
                return playerID;
            }
            set
            {
                playerID = value;
            }
        }

    }
}
