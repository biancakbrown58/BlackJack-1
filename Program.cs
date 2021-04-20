using System;
using System.Collections.Generic;

namespace BlackJack
{
    class Card
    {
        public string Rank;
        public string Suit;
        //access the method by .Value()
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

            // get card value. loop through the suit and rank list 
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
            Console.WriteLine("-----------");
            Console.WriteLine("Your cards:");
            Console.WriteLine("-----------");
            Console.WriteLine($"{firstCard.Rank} {firstCard.Suit}");
            Console.WriteLine($"{secondCard.Rank} {secondCard.Suit}");

            playerHand.Add(deck[0]);
            deck.RemoveAt(0);
            playerHand.Add(deck[0]);
            deck.RemoveAt(0);

            var total = 0;
            for (int i = 0; i < playerHand.Count; i++)
            {
                total += playerHand[i].Value();
            }
            Console.WriteLine($"Total: {total}");
            Console.WriteLine("-------------");
            Console.WriteLine("Hit or Stand?");
            Console.WriteLine("-------------");
            var isRunning = true;
            while (isRunning)
            {
                var newTotal = 0;
                var dealerTotal = 0;
                var newDealerTotal = 0;
                var userInput = Console.ReadLine();
                if (userInput == "hit")
                {
                    var newCard = deck[0];
                    Console.WriteLine("--------------");
                    Console.WriteLine("Your new card:");
                    Console.WriteLine("--------------");
                    Console.WriteLine($"{newCard.Rank} {newCard.Suit}");
                    playerHand.Add(deck[0]);
                    deck.RemoveAt(0);

                    for (int i = 0; i < playerHand.Count; i++)
                    {
                        newTotal += playerHand[i].Value();
                    }
                    Console.WriteLine($"New Total: {newTotal}");
                    if (newTotal > 21)
                    {
                        // var dealerTotal = 0;
                        Console.WriteLine("Oh no!!");

                        //display dealer cards
                        Console.WriteLine("--------------");
                        Console.WriteLine("Dealer's Cards");
                        Console.WriteLine("--------------");
                        Console.WriteLine($"{dealerHand[0].Rank} {dealerHand[0].Suit}");
                        Console.WriteLine($"{dealerHand[1].Rank} {dealerHand[1].Suit}");

                        //get dealer hand totals
                        for (int i = 0; i < dealerHand.Count; i++)
                        {
                            dealerTotal += dealerHand[i].Value();
                        }
                        Console.WriteLine($"Dealer's Total: {dealerTotal}");
                        Console.WriteLine("~~ You Bust ~~ Dealer Wins!");
                    }

                    else if (newTotal <= 21 && newTotal > dealerTotal)
                    {
                        Console.WriteLine("~~ You Won ~~");
                        Console.WriteLine("Here's what the dealer had:");
                        for (int i = 0; i < dealerHand.Count; i++)
                        {
                            dealerTotal += dealerHand[i].Value();
                        }
                        Console.WriteLine($"Dealer's Total: {dealerTotal}");
                    }
                }
                else if (userInput == "stand")
                {
                    //display dealer cards
                    Console.WriteLine("--------------");
                    Console.WriteLine("Dealer's Cards");
                    Console.WriteLine("--------------");
                    Console.WriteLine($"{dealerHand[0].Rank} {dealerHand[0].Suit}");
                    Console.WriteLine($"{dealerHand[1].Rank} {dealerHand[1].Suit}");

                    //get dealer hand totals
                    for (int i = 0; i < dealerHand.Count; i++)
                    {
                        dealerTotal += dealerHand[i].Value();
                    }
                    Console.WriteLine($"Dealer's Total: {dealerTotal}");
                    if (dealerTotal < 17)
                    {
                        var newDealerCard = deck[0];
                        Console.WriteLine($"{newDealerCard.Rank} {newDealerCard.Suit}");
                        dealerHand.Add(deck[0]);
                        deck.RemoveAt(0);

                        for (int i = 0; i < dealerHand.Count; i++)
                        {
                            newDealerTotal += dealerHand[i].Value();
                        }
                        Console.WriteLine($"Dealer's New Total: {newDealerTotal}");
                    }
                }
                else if (newDealerTotal > 21)
                {
                    Console.WriteLine("Dealer Bust you won");
                }
                else if (userInput == "quit")
                {
                    isRunning = false;
                }
            }
        }
    }
}