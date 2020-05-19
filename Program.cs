using System;
using System.Collections.Generic;

namespace BlackjackAssignment
{
    class Hand
    {
        public List<Card> CardsBeingHeld = new List<Card>();

        public void Accept(Card cardWeAreGivenToHold)
        {
            CardsBeingHeld.Add(cardWeAreGivenToHold);
        }

        public void ShowCards()
        {
            foreach (var card in CardsBeingHeld)
            {
                Console.WriteLine($"{card.Face} of {card.Suit}");
            }
        }
        public int TotalValue()
        {
            var total = 0;
            foreach (var card in CardsBeingHeld)
            {
                var cardValue = card.Value();

                total += cardValue;
            }
            return total;
        }
    }

    class Card
    {
        public string Face { get; set; }
        public string Suit { get; set; }

        public int Value()
        {
            if (Face == "1")
            {
                return 1;
            }
            if (Face == "2")
            {
                return 2;
            }
            if (Face == "3")
            {
                return 3;
            }
            if (Face == "4")
            {
                return 4;
            }
            if (Face == "5")
            {
                return 5;
            }
            if (Face == "6")
            {
                return 6;
            }
            if (Face == "7")
            {
                return 7;
            }
            if (Face == "8")
            {
                return 8;
            }
            if (Face == "9")
            {
                return 9;
            }
            if (Face == "10")
            {
                return 10;
            }
            if (Face == "Jack")
            {
                return 10;
            }
            if (Face == "Queen")
            {
                return 10;
            }
            if (Face == "King")
            {
                return 10;
            }
            if (Face == "Ace")
            {
                return 11;
            }
            return 0;

        }
    }

    class Deck
    {
        private List<Card> Cards = new List<Card>();

        public void MakeCards()
        {
            var suits = new string[] { "Clubs", "Diamonds", "Hearts", "Spades" };
            var faces = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (var suit in suits)
            {
                foreach (var face in faces)
                {
                    var newCard = new Card
                    {
                        Suit = suit,
                        Face = face,
                    };
                    Cards.Add(newCard);
                }
            }
            var rNG = new Random();

            for (var index = Cards.Count - 1; index >= 1; index--)
            {
                var otherIndex = rNG.Next(index);

                var firstCard = Cards[index];
                var otherCard = Cards[otherIndex];

                Cards[index] = otherCard;
                Cards[otherIndex] = firstCard;
            }
        }

        public Card Deal()
        {
            var card = Cards[0];

            Cards.Remove(card);

            return card;
        }
    }

    class Game
    {
        public void Play()
        {
            var deck = new Deck();

            deck.MakeCards();

            var playerHand = new Hand();

            var dealerHand = new Hand();

            var firstCard = deck.Deal();
            playerHand.Accept(firstCard);

            var secondCard = deck.Deal();
            playerHand.Accept(secondCard);

            var firstCardForDealer = deck.Deal();
            dealerHand.Accept(firstCardForDealer);

            var secondCardForDealer = deck.Deal();
            dealerHand.Accept(secondCardForDealer);

            while (playerHand.TotalValue() <= 21)
            {
                Console.WriteLine($"Your cards are: ");
                playerHand.ShowCards();
                var playerHandTotal = playerHand.TotalValue();
                Console.WriteLine($"Which totals up to {playerHandTotal}");

                Console.Write("Hit or Stand?: ");
                var answer = Console.ReadLine();

                if (answer == "Hit")
                {
                    var extraCard = deck.Deal();
                    playerHand.Accept(extraCard);
                }
                else
                {
                    break;
                }
            }

            playerHand.ShowCards();
            Console.WriteLine($"Which totals up to {playerHand.TotalValue()}");
            while (dealerHand.TotalValue() < 17)
            {
                var extraCard = deck.Deal();
                dealerHand.Accept(extraCard);
            }

            Console.WriteLine("The Dealer has:  ");
            dealerHand.ShowCards();
            var dealerHandTotal = dealerHand.TotalValue();
            Console.WriteLine($"Which totals up to {dealerHandTotal}");

            if (playerHand.TotalValue() > 21)
            {
                Console.WriteLine("Bust! House wins");
            }
            else
            if (dealerHand.TotalValue() > 21)
            {
                Console.WriteLine("Bust! Player wins");
            }
            else if (dealerHand.TotalValue() > playerHand.TotalValue())
            {
                Console.WriteLine("Dealer closer to Blackjack; House wins!");
            }
            else if (dealerHand.TotalValue() == playerHand.TotalValue())
            {
                Console.WriteLine("Equal hands, House has the edge. House wins!");
            }
            else
            {
                Console.WriteLine("User closer to Blackjack; Player Wins!");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var keepPlaying = true;

            while (keepPlaying)
            {
                var game = new Game();
                game.Play();

                Console.Write("Would you like to play again? Yes/No:  ");
                var playAgainUserInput = Console.ReadLine();

                keepPlaying = (playAgainUserInput == "Yes");
            }
            Console.WriteLine("Thank you for playing! Come back soon");
        }
    }
}
