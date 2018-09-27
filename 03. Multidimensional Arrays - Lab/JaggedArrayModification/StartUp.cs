namespace JaggedArrayModification
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var jaggedSize = int.Parse(Console.ReadLine());
            var jaggedArr = new int[jaggedSize][];

            // Fill jagged array.
            for (int row = 0; row < jaggedSize; row++)
            {
                var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                jaggedArr[row] = new int[arr.Length];

                for (int col = 0; col < arr.Length; col++)
                {
                    jaggedArr[row][col] = arr[col];
                }
            }

            // Manipulate jagged array.
            var command = Console.ReadLine();

            while (command != "END")
            {
                var commandData = command.Split(' ').ToArray();
                var operation = commandData[0];
                var rowIndex = int.Parse(commandData[1]);
                var colIndex = int.Parse(commandData[2]);
                var value = int.Parse(commandData[3]);

                if (rowIndex < 0 || rowIndex > jaggedArr.Length - 1)
                {
                    Console.WriteLine("Invalid coordinates");
                    command = Console.ReadLine();
                    continue;
                }

                if (colIndex < 0 || colIndex > jaggedArr[rowIndex].Length - 1)
                {
                    Console.WriteLine("Invalid coordinates");
                    command = Console.ReadLine();
                    continue;
                }                

                switch (operation)
                {
                    case "Add": jaggedArr[rowIndex][colIndex] += value; break;
                    case "Subtract": jaggedArr[rowIndex][colIndex] -= value; break;
                    default: break;
                }

                command = Console.ReadLine();
            }

            // Print jagged array.
            for (int row = 0; row < jaggedArr.Length; row++)
            {
                for (int col = 0; col < jaggedArr[row].Length; col++)
                {
                    Console.Write($"{jaggedArr[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
