﻿namespace GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var bagCapacity = long.Parse(Console.ReadLine());
            var itemsInput = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var goldBag = new Dictionary<string, long>();
            var goldQuantity = 0L;

            var gemBag = new Dictionary<string, long>();
            var gemQuantity = 0L;

            var cashBag = new Dictionary<string, long>();
            var cashQuantity = 0L;

            for (int i = 0; i < itemsInput.Length; i += 2)
            {
                var itemName = itemsInput[i];
                var itemAmount = long.Parse(itemsInput[i + 1]);

                var itemType = GetItemType(itemName);

                var canInsertItem = CanPutItemInBag(itemType, itemAmount, bagCapacity, goldQuantity, gemQuantity, cashQuantity);

                if (itemType == "invalid" || !canInsertItem)
                {
                    continue;
                }

                switch (itemType)
                {
                    case "Gold":
                        InsertItem(goldBag, itemName, itemAmount);
                        goldQuantity += itemAmount;
                        break;
                    case "Gem":
                        InsertItem(gemBag, itemName, itemAmount);
                        gemQuantity += itemAmount;
                        break;
                    case "Cash":
                        InsertItem(cashBag, itemName, itemAmount);
                        cashQuantity += itemAmount;
                        break;
                }
            }

            if (goldBag.Any())
            {
                Console.WriteLine(PrintBag(goldBag, "Gold", goldQuantity));
                if (gemBag.Any())
                {
                    Console.WriteLine(PrintBag(gemBag, "Gem", gemQuantity));
                    if (cashBag.Any())
                    {
                        Console.WriteLine(PrintBag(cashBag, "Cash", cashQuantity));
                    }
                }
            }
        }

        private static string PrintBag(Dictionary<string, long> bag, string type, long totalAmount)
        {
            var resultBuilder = new StringBuilder();

            resultBuilder.AppendLine($"<{type}> ${totalAmount}");

            var orderedBag = bag.OrderByDescending(i => i.Key).ThenBy(i => i.Value);

            foreach (var item in orderedBag)
            {
                resultBuilder.AppendLine($"##{item.Key} - {item.Value}");
            }

            var result = resultBuilder.ToString().TrimEnd();
            return result;
        }

        private static void InsertItem(Dictionary<string, long> bag, string itemName, long itemAmount)
        {
            if (!bag.ContainsKey(itemName))
            {
                bag[itemName] = 0;
            }

            bag[itemName] += itemAmount;
        }

        private static bool CanPutItemInBag(string itemType, long itemAmount, long bagCapacity, long goldQuantity, long gemQuantity, long cashQuantity)
        {
            long bagOccupied = goldQuantity + gemQuantity + cashQuantity;

            if (bagCapacity < bagOccupied + itemAmount)
            {
                return false;
            }

            switch (itemType)
            {
                case "Gold":
                    return true;
                case "Gem":
                    gemQuantity += itemAmount;
                    return gemQuantity <= goldQuantity;
                case "Cash":
                    cashQuantity += itemAmount;
                    return cashQuantity <= gemQuantity;
            }

            return false;
        }

        private static string GetItemType(string itemName)
        {
            if (itemName.Length == 3)
            {
                return "Cash";
            }

            if (itemName.ToLower().EndsWith("gem"))
            {
                return "Gem";
            }

            if (itemName.ToLower() == "gold")
            {
                return "Gold";
            }

            return "invalid";
        }
    }
}
