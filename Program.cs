using System;
using System.Collections.Generic;

namespace BlackJack
{
    class Card
    {
        public string Rank;
        public string Suit;
        //assess the method by .Value()
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

            var suits = new List<string>() { "♣️", "♦️", "❤️", "♠️" };
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

            // var dealerCard1 = deck[0];
            dealerHand.Add(deck[0]);
            deck.RemoveAt(0);

            // var dealerCard2 = deck[1];
            dealerHand.Add(deck[0]);
            deck.RemoveAt(0);




            //show top 2 cards
            var firstCard = deck[0];
            var secondCard = deck[1];


            // write out value with firstcard.value()
            // Console.WriteLine($"{firstCard.Rank} {firstCard.Suit}  with a value of {firstCard.Value()}");
            // Console.WriteLine($"{secondCard.Rank} {secondCard.Suit}  with a value of {secondCard.Value()}");

            Console.WriteLine($"{firstCard.Rank} {firstCard.Suit}");
            Console.WriteLine($"{secondCard.Rank} {secondCard.Suit}");


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
            Console.WriteLine("Would you like to hit or stand?");
            var isRunning = true;
            while (isRunning)
            {

                var userInput = Console.ReadLine();
                if (userInput == "hit")
                {
                    var newCard = deck[0];
                    var newTotal = 0;
                    Console.WriteLine($"{newCard.Rank} {newCard.Suit}");
                    playerHand.Add(deck[0]);
                    deck.RemoveAt(0);

                    for (int i = 0; i < playerHand.Count; i++)
                    {
                        newTotal += playerHand[i].Value();
                    }

                    Console.WriteLine($"Your new total is: {newTotal}");
                    if (newTotal > 21)
                    {
                        var dealerTotal = 0;
                        Console.WriteLine("!!You Bust!!");
                        Console.WriteLine("The dealer wins!");

                        //display dealer cards
                        Console.WriteLine("Dealer's Cards");
                        Console.WriteLine($"{dealerHand[0].Rank} {dealerHand[0].Suit}");
                        Console.WriteLine($"{dealerHand[1].Rank} {dealerHand[1].Suit}");

                        //get dealer hand totals
                        for (int i = 0; i < dealerHand.Count; i++)
                        {
                            dealerTotal += dealerHand[i].Value();
                        }
                        Console.WriteLine($"Dealer's total is: {dealerTotal}");

                    }

                    // if (userInput == "stand")
                    // {
                    //     Console.WriteLine("You want to stand??");
                    // }
                    else
                    {
                        Console.WriteLine("hit or stand?");

                    }

                    //  else if (userInput == "stand")
                    //   {
                    //       Console.WriteLine("You want to stand?");
                    //   }
                }


                else
                {
                    var dealerTotal = 0;
                    Console.WriteLine("you want to stand?");
                    Console.WriteLine("Here's the Dealer's Hand");
                    //display dealer cards
                    Console.WriteLine("Dealer's Cards");
                    Console.WriteLine($"{dealerHand[0].Rank} {dealerHand[0].Suit}");
                    Console.WriteLine($"{dealerHand[1].Rank} {dealerHand[1].Suit}");

                    //get dealer hand totals
                    for (int i = 0; i < dealerHand.Count; i++)
                    {
                        dealerTotal += dealerHand[i].Value();
                    }
                    Console.WriteLine($"Dealer's total is: {dealerTotal}");
                    // if ( dealerTotal > newTotal)
                    // isRunning = false;
                }
            }


        }
    }
}