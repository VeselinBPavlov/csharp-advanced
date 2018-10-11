﻿namespace CryptoMaster
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var maxSequence = 0;

            for (int index = 0; index < numbers.Length; index++)
            {
                for (int step = 1; step < numbers.Length; step++)
                {
                    var currentIndex = index;
                    var nextIndex = (index + step) % numbers.Length;
                    var currentSequence = 1;

                    while (numbers[currentIndex] < numbers[nextIndex])
                    {
                        currentIndex = nextIndex;
                        nextIndex = (nextIndex + step) % numbers.Length;
                        currentSequence++;
                    }

                    if (currentSequence > maxSequence)
                    {
                        maxSequence = currentSequence;
                    }
                }
            }

            Console.WriteLine(maxSequence);
        }
    }
}
