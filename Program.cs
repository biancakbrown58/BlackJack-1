using System;
using System.Collections.Generic;

namespace BlackJack
{
    class Card
    {
        public string Rank;
        public string Suit;
        public int Value()
        {
            if (Rank == "Ace")
            {
                return 11;
            }
            else if (Rank == "Queen" || Rank == "King" || Rank == "Jack")
            {
                return 10;
            }
            else
            {
                return int.Parse(Rank);
            }

        }

    }




    class Program
    {
        static void Main(string[] args)
        {
            var deck = new List<Card>();

            var suits = new List<string>() { "Clubs", "Diamonds", "Hearts", "Spades" };
            var ranks = new List<string>() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };


            // get card value. loop through the face list and parse to a number

            //Gavin loop
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    var card = new Card { Suit = suit, Rank = rank };
                    deck.Add(card);
                }
            }

            //shuffle
            var numberOfCards = deck.Count;
            for (var rightSide = numberOfCards - 1; rightSide >= 1; rightSide--)
            {
                //getting one side to keep the value of them
                var leftSide = new Random().Next(0, rightSide);
                var leftCard = deck[leftSide];
                var rightCard = deck[rightSide];
                deck[rightSide] = leftCard;
                deck[leftSide] = rightCard;
            }
            var playerHand = new List<Card>();
            var dealerHand = new List<Card>();

            dealerHand.Add(deck[0]);
            deck.RemoveAt(0);
            dealerHand.Add(deck[0]);
            deck.RemoveAt(0);



            //show top 2 cards
            var firstCard = deck[0];
            var secondCard = deck[1];

            // write out value with firstcard.value()
            Console.WriteLine($"{firstCard.Rank} of {firstCard.Suit} with a value of {firstCard.Value()}");
            Console.WriteLine($"{secondCard.Rank} of {secondCard.Suit} with a value of {secondCard.Value()}");

            playerHand.Add(deck[0]);
            deck.RemoveAt(0);
            playerHand.Add(deck[0]);
            deck.RemoveAt(0);
            var total = 0;
            // var playersHandTotal = 0;
            // var dealersHandTotal = 0;

            for (int i = 0; i < playerHand.Count; i++)
            {
                total += playerHand[i].Value();
            }
            Console.WriteLine($"Your total is {total}");


        }
    }
}