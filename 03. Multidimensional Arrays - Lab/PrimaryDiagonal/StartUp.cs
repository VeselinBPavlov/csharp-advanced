namespace PrimaryDiagonal
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine());

            var sum = 0;
            var counter = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                sum += arr[counter];
                counter++;
            }

            Console.WriteLine(sum);
        }
    }
}
