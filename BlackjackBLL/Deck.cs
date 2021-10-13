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
        private Random rand;
        private int decks = 1; // default
        string[] faces = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        Suite[] suites = { Suite.Hearts, Suite.Clubs, Suite.Diamonds, Suite.Spades };
        public Deck(int decks)
        {
            this.decks = decks;
            Init();
            ShuffleDeck();
        }

        public void Init()
        {
            deck = new List<Card>();
            for (int i = 1; i < decks; i++)
            {
                deck.AddRange(CreateDeck());
                SetImagePaths();
            }           
           ShuffleDeck();
        }

        private List<Card> CreateDeck()
        {
            List<Card> tempDeck = new List<Card>();

            rand = new Random();
              
               for (int j = 0; j < nbrOfCards; j++)
                {
                    tempDeck.Add(new Card(faces[j % 13], suites[j / 13], j % 13));
                }
            return tempDeck;
        }

        private void SetImagePaths()
        {
            for (int i = 0; i < 13; i++)
            {
                if (deck[i].Suite == Suite.Hearts)
                {

                    if (i == 0)
                    {
                        deck[i].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", "ace_of_hearts.png"));
                    }

                    else if (i == 10)
                    {
                        deck[i].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", "jack_of_hearts.png"));
                    }

                    else if (i == 11)
                    {
                        deck[i].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", "queen_of_hearts.png"));
                    }


                    else if (i == 12)
                    {
                        deck[i].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", "king_of_hearts.png"));
                    }

                    else
                    {
                        deck[i].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", i + "_of_hearts.png"));
                    }
                }
            }
            for (int i = 13; i < 26; i++)
            {
                if (deck[i].Suite == Suite.Clubs)
                {
                    if (i == 13)
                    {
                        deck[i].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", "ace_of_clubs.png"));
                    }

                    else if (i == 10 * 2)
                    {
                        deck[i].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", "jack_of_clubs.png"));
                    }

                    else if (i == 11 * 2)
                    {
                        deck[i].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", "queen_of_clubs.png"));
                    }


                    else if (i == 12 * 2)
                    {
                        deck[i].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", "king_of_clubs.png"));
                    }

                    else
                    {
                        deck[i].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", i / 2 + "_of_clubs.png"));
                    }
                }
            }
            for (int i = 26; i < 39; i++)
            {
                if (deck[i].Suite == Suite.Diamonds)
                {
                    if (i == 26)
                    {
                        deck[i].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", "ace_of_diamonds.png"));
                    }

                    else if (i == 10 * 3)
                    {
                        deck[i].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", "jack_of_diamonds.png"));
                    }

                    else if (i == 11 * 3)
                    {
                        deck[i].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", "queen_of_diamonds.png"));
                    }


                    else if (i == 12 * 3)
                    {
                        deck[i].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", "king_of_diamonds.png"));
                    }

                    else
                    {
                        deck[i].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", i / 3 + "_of_diamonds.png"));
                    }
                }
            }



            for (int i = 39; i < 52; i++)
            {
                if (deck[i].Suite == Suite.Spades)
                {
                    if (i == 39)
                    {
                        deck[i].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", "ace_of_spades.png"));
                    }

                    else if (i == 10 * 4)
                    {
                        deck[i].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", "jack_of_spades.png"));
                    }

                    else if (i == 11 * 4)
                    {
                        deck[i].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", "queen_of_spades.png"));
                        
                    }

                    else if (i == 12 * 4)
                    {
                        deck[i].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", "king_of_spades.png"));
                        
                    }

                    else
                    {
                        deck[i].ImagePath = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\", i / 4 + "_of_spades.png"));
                    }
                }
            }
        }

        public void ShuffleDeck()
        {
            List<Card> tempDeck = new List<Card>();
            tempDeck = deck;
            for (int first = 0; first < tempDeck.Count; first++)
            {
                int second = rand.Next(tempDeck.Count);
                Card temp = tempDeck[first];
                tempDeck[first] = tempDeck[second];
                tempDeck[second] = temp;
            }
            deck = tempDeck;
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
                Debug.WriteLine("Deck empty");
                return null;
            }
        }
        
    }
}
