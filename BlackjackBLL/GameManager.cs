using Blackjack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlackjackBLL
{
    public class GameManager
    {
        public Deck deck;
        List<Player> players;
        Dealer dealer;
        int round;
        public event EventHandler eventHandler;
        public GameManager()
        {
            deck = new Deck(2);
            players = new List<Player>();
        }

        public void StartGame()
        {
            round = 1;
            dealer = new Dealer(this, deck);                      // dealer has access to the deck, cards are encapsulated with properties, no cheating :)
            for (int i = 0; i < players.Count; i++)               // create all the players                     
            {
                Hand hand = new Hand();
                string name = "";
                string playerID = "";
                Player player = new Player(hand, name, playerID, this);
                players.Add(player);
            }

            Update(); // game loop
        }

        public void Update()
        {
            while(true)
            {
                dealer.DealCard();
                for (int i = 0; i < players.Count; i++)
                {
                    players[i].Play();
                }
            }
        }
    }
}
