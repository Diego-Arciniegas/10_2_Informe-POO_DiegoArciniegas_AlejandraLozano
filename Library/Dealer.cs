using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;

namespace Library
{
    public class Dealer : User
    {
        private List<Card> deck;

        public List<Card> Deck { get => deck; set => deck = value; }

        public void Generade()
        {
            deck = new List<Card>();
            Hand = new List<Card>();

            char[] suits = { '♥', '♦', '♣', '♠' };
            string[] symbols = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "K", "Q" };

            foreach (char su in suits)
            {
                foreach (string sy in symbols)
                {

                    Card c = new Card(su, sy);
                    deck.Add(c);

                }

            }
        }
        public void Randomize()
        {

            Random rnd = new Random();
            this.deck = this.deck.OrderBy(x => (rnd.Next())).ToList();

        }

        public Card Deal()
        {

            Card c = this.deck.First();
            this.deck.Remove(c);
            return c;

        }

        public void AddCard(Card c)
        {
            Hand.Add(c);
        }

        public void Init()
        {
            AddCard(Deal());
            AddCard(Deal());
        }


    }

}