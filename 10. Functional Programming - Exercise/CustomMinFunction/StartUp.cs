namespace CustomMinFunction
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(SmallestNumber(numbers));
        }

        public static Func<int[], int> SmallestNumber = arr =>
        {
            var smallestNum = int.MaxValue;

            foreach (var num in arr)
            {
               if (smallestNum > num)
               {
                    smallestNum = num;
               }
            }

            return smallestNum;
        };
    }
}
