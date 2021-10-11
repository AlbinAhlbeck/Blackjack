using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackBLL
{
    class Deck
    {
        private Card[] deck;
        private int currentCard;
        private const int NUMBER_OF_CARDS = 52;
        private Random rand;

        public Deck()
        {
            string[] faces = {"Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"};
            string[] suites = {Suite.Hearts, Suite.Clubs, Suite.Diamonds, Suite.Spades};

            deck = new Card[NUMBER_OF_CARDS];

            currentCard = 0;

            rand = new Random();

            for (int i = 0; i < deck.Length; i++)
			{
                deck[i] = new Card(faces[i % 11], suites[i / 13]);
                deck[i].ToString();
			}
        }

        public void ShuffleDeck()
        {
            currentCard = 0;

            for (int first = 0; first < deck.Length; first++)
			{
                int second = rand.Next(NUMBER_OF_CARDS);
                Card temp = deck[first];
                deck[first] = deck[second];
                deck[second] = temp;
			}
        }

        public Card DealCard()
        {
            if(currentCard < deck.Length) 
            {
                return deck[currentCard++];
            }
            else 
            {
                return null;
            }
        }
    }
