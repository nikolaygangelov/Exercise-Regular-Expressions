using System;
using System.Text.RegularExpressions;

namespace _1._Furniture
{
    class Furniture
    {
        static void Main(string[] args)
        {
            double cost = 0;
            string input = string.Empty;

            Console.WriteLine("Bought furniture:");

            while ((input = Console.ReadLine()) != "Purchase")
            {
                string pattern = @">>(?<name>[A-Za-z]+)<<(?<price>\d+|(\d+\.\d+))!(?<quantity>\d+)(\.\d+)?";
                Regex regex = new Regex(pattern);
                Match validFurniture = regex.Match(input);
                
                bool containsValidFurniture = regex.IsMatch(input);

                if (containsValidFurniture)
                {
                    Console.WriteLine($"{validFurniture.Groups["name"].Value}");
                    double price = double.Parse(validFurniture.Groups["price"].Value);
                    int quantity = int.Parse(validFurniture.Groups["quantity"].Value);
                    cost += price * quantity;
                }

            }
            Console.WriteLine($"Total money spend: {cost:f2}");
        }
    }
}
