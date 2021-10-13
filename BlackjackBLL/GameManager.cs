using Blackjack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackBLL
{
    public delegate string PlayerTurn(string s);
    public delegate string PlayerInfo();
    public class GameManager
    {
        private Deck deck;
        private List<Player> players;
        private Dealer dealer;
        private int round;
        private BlackjackWindow blackjack;
        private PlayerTurn pt;
        private PlayerInfo pi;

        public GameManager()

        {           
            blackjack = new BlackjackWindow();
            deck = new Deck(2);
            players = new List<Player>();
            pt = new PlayerTurn(blackjack.Turn);
            blackjack.Show();
            StartGame();
        }

        private void StartGame()
        {
            round = 1;
            dealer = new Dealer(this, deck);                      // dealer has access to the deck, cards are encapsulated with properties, no cheating :)
            for (int i = 0; i < players.Count; i++)               // create all the players                     
            {
                Hand hand = new Hand();
                string name = "";
                Player player = new Player(hand, name, this);
                players.Add(player);
            }
            Debug.WriteLine(pt("player 1"));
            //Update(); // game loop
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
