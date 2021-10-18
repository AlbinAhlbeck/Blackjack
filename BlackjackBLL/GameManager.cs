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
    public delegate void DealerPlay(Uri imagePath, int value);
    public class GameManager
    {
        private Deck deck;
        private List<Player> players;
        private Dealer dealer;
        private int round;
        private BlackjackWindow blackjack;
        private PlayerTurn pt;
        private PlayerInfo pi;
        private DealerPlay dealerPlay;

        public GameManager()

        {           
            blackjack = new BlackjackWindow();
            deck = new Deck(2);
            players = new List<Player>();
            pt = new PlayerTurn(blackjack.Turn);
            dealerPlay = new DealerPlay(blackjack.DealerPlay);
            
            blackjack.Show();
            StartGame();
        }

        private void StartGame()
        {
            round = 1;
            dealer = new Dealer(this, deck);                      // dealer has access to the deck, cards are encapsulated with properties
            for (int i = 0; i < players.Count; i++)               // create all the players                     
            {
                Hand hand = new Hand();
                string name = "";
                Player player = new Player(hand, name, this);
                players.Add(player);
            }
            Debug.WriteLine(pt("player 1"));
            Update(); // game loop
        }



        public void Update()
        {
            while(true)
            {
                for (int i = 0; i < 3; i++)
                {
                    Card card = dealer.DealCard();
                    dealerPlay(card.ImagePath, dealer.Total()); // dealer play a card and update GUI
                    Debug.WriteLine(card.ToString());
                }
               
               
                for (int i = 0; i < players.Count; i++)
                {
                    if(players[i].Play())
                    {
                        players[i].DrawCard(dealer.DealCard()) ;
                    }
                    
                }
                break;
            }
        }

      
    }
}
