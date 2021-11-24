using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2020.Solutions
{
    public class Day22
    {
        public int CalculateWinningScore(string[] input)
        {
            var game = ParseInput(input);

            while (!game.Complete)
            {
                game.PlayRound();
            }

            game.Print();

            return CalculateScore(game.Winner);
        }

        public int CalculateScore(Queue<int> deck)
        {
            var list = deck.ToList();

            return Enumerable.Range(1, deck.Count).Reverse().Zip(list, (a, b) => a * b).Sum();
            
        }

        private Game ParseInput(string[] input)
        {
            var player1 = input.TakeWhile(x => x != "");

            var player2 = input.Skip(player1.Count() + 1);

            return new Game
            {
                Deck1 = new Queue<int>(player1.Skip(1).Select(int.Parse)),
                Deck2 = new Queue<int>(player2.Skip(1).Select(int.Parse))
            };
        }
    }

    public record Game
    {
        public Queue<int> Deck1 { get; set; }
        public Queue<int> Deck2 { get; set; }

        public bool Complete => Deck1.Count == 0 || Deck2.Count == 0;

        public Queue<int> Winner => Deck1.Count > 0 ? Deck1 : Deck2;

        public void Print()
        {
            Console.WriteLine($"Player 1's deck: {string.Join(",", Deck1)}");
            Console.WriteLine($"Player 2's deck: {string.Join(",", Deck2)}");
        }

        public void PlayRound()
        {
            var one = Deck1.Dequeue();
            var two = Deck2.Dequeue();

            if (one > two)
            {
                Deck1.Enqueue(one);
                Deck1.Enqueue(two);
            }
            else
            {
                Deck2.Enqueue(two);
                Deck2.Enqueue(one);
            }
        }
    }

}
