using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Resources;

namespace BlackjackBLL
{
    public class Deck
    {
        private List<Card> deck;
        private int nbrOfCards = 52; // default
        private Random rng;
        private int decks = 1; // default
        string[] faces = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        Suite[] suites = { Suite.Hearts, Suite.Clubs, Suite.Diamonds, Suite.Spades };

        public Deck(int decks)
        {
            this.decks = decks;
            Debug.WriteLine("Decks: " + decks);
            Init();
            Debug.WriteLine(deck.Count);
        }

        public void Init()
        {
            deck = new List<Card>();
            for (int i = 0; i < decks; i++)
            {
                deck.AddRange(CreateDeck());
                SetImagePaths();
            }           
           Shuffle(deck);
        }

        private List<Card> CreateDeck()
        {
            List<Card> tempDeck = new List<Card>();

            rng = new Random();
              
               for (int j = 0; j < nbrOfCards; j++)
                {
                tempDeck.Add(new Card(faces[j % 13], suites[j / 13]));                               
                }
            Debug.WriteLine(tempDeck.Count);
            return tempDeck;
        }

        private void SetImagePaths()
        {
            string face = null;
            int j = 0;
            int min = 0;
            int max = 13;
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    face = "hearts";
                    Debug.WriteLine("Looking for hearts");
                }

                if (i == 1)
                {
                    face = "clubs";
                    Debug.WriteLine("Looking for clubs");
                    min = 13;
                    j = min;
                    max = 26;
                }

                if (i == 2)
                {
                    face = "diamonds";
                    Debug.WriteLine("Looking for diamonds");
                    min = 26;
                    j = min;
                    max = 38;
                }

                if (i == 3)
                {
                    face = "spades";
                    Debug.WriteLine("Looking for spades");
                    min = 39;
                    j = min;
                    max = 52;
                }

                while(j < max)                         
                {
                    
                    // special cards
                    if (j - min == 0)
                    {
                        deck[j].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", "ace_of_" + face + ".png"));
                        deck[j].CardValue = 1;
                    }

                    else if (j - min == 10)
                    {
                        deck[j].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", "jack_of_" + face + ".png"));
                        deck[j].CardValue = 10;
                    }

                    else if (j - min == 11)
                    {
                        deck[j].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", "queen_of_" + face + ".png"));
                        deck[j].CardValue = 10;
                    }

                    else if (j - min == 12)
                    {
                        deck[j].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", "king_of_" + face + ".png"));
                        deck[j].CardValue = 10; 
                    }

                    else // if the card is numeric card
                    {                    
                            deck[j].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", j - min + 1 + "_of_" + face + ".png"));
                        deck[j].CardValue = j - min + 1; // set value
                    }

                    
                    Debug.WriteLine(deck[j].ToString());
                    j++;
                }

            }
        }
                    
        public void Shuffle(List<Card> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public Card DealCard()
        {
            if (deck.Count > 0)
            {
                Card tempCard = deck[0];
                deck.RemoveAt(0);
                return tempCard;
            }
            else
            {
                Init(); // create new deck
                return null;
            }
        }
        
    }
}
