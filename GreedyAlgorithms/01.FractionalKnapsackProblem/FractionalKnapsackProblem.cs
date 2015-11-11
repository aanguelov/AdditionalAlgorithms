namespace _01.FractionalKnapsackProblem
{
    using System;

    internal class FractionalKnapsackProblem
    {
        private static void Main()
        {
            int capacity = int.Parse(Console.ReadLine().Split(' ')[1]);
            int itemsCount = int.Parse(Console.ReadLine().Split(' ')[1]);

            Item[] items = new Item[itemsCount];
            for (int i = 0; i < itemsCount; i++)
            {
                string[] data = Console.ReadLine().Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                items[i] = new Item(double.Parse(data[1]), double.Parse(data[0]));
            }

            Array.Sort(items);

            double totalWeight = 0;
            double totalPrice = 0;
            foreach (var item in items)
            {
                if (totalWeight + item.Weight <= capacity)
                {
                    totalWeight += item.Weight;
                    totalPrice += item.Price;
                    Console.WriteLine("Take 100% of item with price {0:f2} and weight {1:f2}", item.Price, item.Weight);
                }
                else
                {
                    double diff = capacity - totalWeight;
                    double percentage = (diff * 100) / item.Weight;
                    totalPrice += item.Price * percentage / 100;
                    Console.WriteLine(
                        "Take {0:f2}% of item with price {1:f2} and weight {2:f2}",
                        percentage,
                        item.Price,
                        item.Weight);
                    break;
                }
            }

            Console.WriteLine("Total price: {0:f2}", totalPrice);
        }
    }
}