using Blackjack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackBLL
{
    public delegate void PlayerPlay(List<Uri> imagePaths);
    public delegate string PlayerInfo();
    public delegate void DealerPlay(Uri imagePath, int value);
    public delegate bool HitOrStand();

    public class GameManager
    {
        private Deck deck;
        private List<Player> players;
        private Dealer dealer;
        private int round;
        private BlackjackWindow blackjack;
        private PlayerPlay pt;
        private PlayerInfo pi;
        private DealerPlay dealerPlay;
        private HitOrStand hitOrStand;

        public GameManager()
        {           
            blackjack = new BlackjackWindow();
            deck = new Deck(2);
            players = new List<Player>();
            pt = new PlayerPlay(blackjack.Turn);
            dealerPlay = new DealerPlay(blackjack.DealerPlay);
            hitOrStand = new HitOrStand(blackjack.HitOrStand);
            blackjack.Show();
            StartGame();
        }

        private void StartGame()
        {
            round = 1;
            dealer = new Dealer(this, deck);                      // dealer has access to the deck, cards are encapsulated with properties
            for (int i = 0; i < 1; i++)               // create all the players                     
            {
                Hand hand = new Hand();
                string name = "";
                Player player = new Player(hand, name, this);
                players.Add(player);
            }
            Update(); // game loop
        }



        public void Update()
        {
            while(true)
            {
                // dealer           
                    Card card = dealer.DealCard();
                    dealerPlay(card.ImagePath, dealer.Total()); // dealer play a card and update GUI
               
               // players turn
                for (int i = 0; i < players.Count; i++)
                {
                    if(hitOrStand()) // if player hits
                    {
                        players[i].DrawCard(dealer.DealCard());
                        pt(players[i].Hand.GetPaths());
                    }
                    
                }
               
            }
        }

      
    }
}
