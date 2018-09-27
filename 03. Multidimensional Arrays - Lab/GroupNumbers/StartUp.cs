namespace GroupNumbers
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var jaggedArr = new int[3][];
            
            for (int row = 0; row < jaggedArr.Length; row++)
            {
                // Filter input array by criteria.
                var tempRow = arr.Where(x => Math.Abs(x) % 3 == row).ToArray();

                // Fill jagged array.
                jaggedArr[row] = new int[tempRow.Length];
                jaggedArr[row] = tempRow;
            }

            // Print jagged array.
            foreach (var row in jaggedArr)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }
    }
}
