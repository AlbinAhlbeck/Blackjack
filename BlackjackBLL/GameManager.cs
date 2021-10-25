using Blackjack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackjackBLL
{
    public delegate void PlayerPlay(List<Uri> imagePaths, string name, int value);
    public delegate string PlayerInfo();
    public delegate void DealerPlay(List<Uri> imagePaths, int value);

    public class GameManager
    {
        private Deck deck;
        private List<Player> players;
        private Player currentPlayer;
        private int playerIndex = 0;
        private Dealer dealer;
        private int round;
        private int nbrOfPlayers;
        private int nbrOfDecks;
        private BlackjackWindow blackjack;
        private PlayerPlay pt;
        private PlayerInfo pi;
        private DealerPlay dealerPlay;


        public GameManager(int nbrOfPlayers, int nbrOfDecks)
        {
           
            this.nbrOfPlayers = nbrOfPlayers;
            this.nbrOfDecks = nbrOfDecks;
            Init();
        }

        private void StartGame()
        {
            round = 1;
            for (int i = 1; i < nbrOfPlayers + 1; i++)               // create all the players                     
            {
                string name = "Player " + i;
                Player player = new Player(name);
                players.Add(player);
            }
            currentPlayer = players[0];
            pt(currentPlayer.Hand.GetPaths(), currentPlayer.Name, currentPlayer.Hand.Total());
            NewRound();
        }

        private void Init()
        {
            blackjack = new BlackjackWindow();
            deck = new Deck(nbrOfDecks);
            dealer = new Dealer(deck);
            players = new List<Player>();          
            pt = new PlayerPlay(blackjack.Turn);
            dealerPlay = new DealerPlay(blackjack.DealerPlay);
            blackjack.Hit += Hit;
            blackjack.Stand += Stand;
            blackjack.Show();
            StartGame();
        }


        public void NewRound()
        {
                // dealer
                playerIndex = 0;
                // players turn
           
                Debug.WriteLine("First round");
                PlaceCard();
                for (int i = 0; i < players.Count; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {                    
                         DrawCard(players[i]);  
                    }

                }                      
        }   
        
        public void EndRound()
        {
            if (dealer.Hand.Total() < 17)
            {
                PlaceCard();
                EndRound();
            }
            else
            {
                Results();
            }
           
            dealerPlay(dealer.Hand.GetPaths(), dealer.Total()); // dealer play a card and update GUI
          
        }
        
        public void DrawCard(Player player)
        {
            Card card = dealer.DealCard();
            player.DrawCard(card);
            pt(currentPlayer.Hand.GetPaths(), currentPlayer.Name, currentPlayer.Hand.Total());
        }

        private void Results()
        {
            bool dealerWin = true;
            if (dealer.Total() > 21)
            {
                dealerWin = false;
               
            }
            else
            {
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].Hand.Total() < 21 && players[i].Hand.Total() > dealer.Hand.Total())
                    {
                        dealerWin = false;
                    }
                }
                if (dealerWin)
                {
                    Debug.WriteLine("Dealer win");
                }
                else
                {
                    Debug.WriteLine("Dealer lost");
                }         
            }
            Restart();
        }


        public void PlaceCard()
        {
            Card card = dealer.PlaceCard();
            dealerPlay(dealer.Hand.GetPaths(), dealer.Total()); // dealer play a card and update GUI
        }
        

        public void Hit(object sender, EventArgs e)
        {
            if (!currentPlayer.IsFinished)
            {
                DrawCard(currentPlayer);

                if (currentPlayer.Hand.Total() > 21)
                {
                    Debug.WriteLine("Fat");
                    blackjack.Fat();
                    currentPlayer.Fat = true;
                    currentPlayer.IsFinished = true;
                    NextPlayer();

                }
                pt(currentPlayer.Hand.GetPaths(), currentPlayer.Name, currentPlayer.Hand.Total());
            }
            else
            {
                Debug.WriteLine("Finished");
            }
            

        }

        public void Stand(object sender, EventArgs e)
        {
            if (!currentPlayer.IsFinished)
            {
                currentPlayer.IsFinished = true;
                NextPlayer();
            }               
        }

        private void NextPlayer()
        {
                if (playerIndex + 1 < players.Count)
                {
                    playerIndex++;
                    currentPlayer = players[playerIndex];
                    pt(currentPlayer.Hand.GetPaths(), currentPlayer.Name, currentPlayer.Hand.Total());
                }
                else
                {
                Debug.WriteLine("Players are done");
                    playerIndex = 0;
                    //DealCard();
                    EndRound();
                }
                
            
        }

        public void Restart()
        {
            Debug.WriteLine("lol");
            blackjack.Restart();
            blackjack.Hide();
            Results results = new Results(GenerateResultArray());
            results.Show();
            Init();
        }

        private string[] GenerateResultArray()
        {
            string[] results = new string[players.Count + 1];

            results[0] = dealer.Result(); // show dealer result first

            for (int i = 0; i < players.Count; i++) // then show player results
            {
                results[i + 1] = players[i].Result();
            }

            return results;
        }

       


    }
}
