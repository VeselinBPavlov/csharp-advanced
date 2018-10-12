namespace NumberWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var playerOneCards = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var playerTwoCards = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var draw = new List<string>();

            var firstPlayerCards = new Queue<string>(playerOneCards);
            var secondPlayerCards = new Queue<string>(playerTwoCards);
            
            for (int i = 1; i <= 1000000; i++)
            {
                var firstCard = int.Parse(firstPlayerCards.Peek().Substring(0, firstPlayerCards.Peek().Length - 1));
                var secondCard = int.Parse(secondPlayerCards.Peek().Substring(0, secondPlayerCards.Peek().Length - 1));

                if (firstCard > secondCard)
                {
                    firstPlayerCards.Enqueue(firstPlayerCards.Dequeue());
                    firstPlayerCards.Enqueue(secondPlayerCards.Dequeue());
                }
                else if (secondCard > firstCard)
                {
                    secondPlayerCards.Enqueue(secondPlayerCards.Dequeue());
                    secondPlayerCards.Enqueue(firstPlayerCards.Dequeue());
                } 
                else
                {
                    var firstHand = 0;
                    var secondHand = 0;

                    draw.Add(firstPlayerCards.Dequeue());
                    draw.Add(secondPlayerCards.Dequeue());

                    while (true)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            var firstPlayerChar = firstPlayerCards.Peek().Substring(firstPlayerCards.Peek().Length - 1).ToCharArray();
                            var secondPlayerChar = secondPlayerCards.Peek().Substring(secondPlayerCards.Peek().Length - 1).ToCharArray();

                            var firstValue = firstPlayerChar[0] - 96;
                            var secondValue = secondPlayerChar[0] - 96;

                            firstHand += firstValue;
                            secondHand += secondValue;

                            draw.Add(firstPlayerCards.Dequeue());
                            draw.Add(secondPlayerCards.Dequeue());
                        }                        

                        if (firstHand > secondHand)
                        {
                            draw = draw.OrderByDescending(x => int.Parse(x.Substring(0, x.Length - 1))).ToList();
                            foreach (var card in draw)
                            {
                                firstPlayerCards.Enqueue(card);                                
                            }
                            draw = new List<string>();
                            break;
                        }
                        else if (secondHand > firstHand)
                        {
                            draw = draw.OrderByDescending(x => int.Parse(x.Substring(0, x.Length - 1))).ToList();
                            foreach (var card in draw)
                            {
                                secondPlayerCards.Enqueue(card);
                            }
                            draw = new List<string>();
                            break;
                        }
                        
                        if (firstPlayerCards.Count == 0 && secondPlayerCards.Count == 0)
                        {
                            Console.WriteLine($"Draw after {i} turns");
                            return;
                        }
                    }
                }

                if (firstPlayerCards.Count == 0)
                {
                    Console.WriteLine($"Second player wins after {i} turns");
                    return;
                }
                else if (secondPlayerCards.Count == 0)
                {
                    Console.WriteLine($"First player wins after {i} turns");
                    return;
                }                 
            }

            var winner = firstPlayerCards.Count > secondPlayerCards.Count ? "First" : "Second";
            Console.WriteLine($"{winner} player wins after 1000000 turns");
        }
    }
}
