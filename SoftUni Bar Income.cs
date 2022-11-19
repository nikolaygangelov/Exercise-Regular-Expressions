
namespace _3._SoftUni_Bar_Income
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main(string[] args)
        {
            decimal income = 0;
            
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                string pattern = @"^%(?<name>[A-Z][a-z]+)%[^\|\$\%\.]*<(?<product>\w+)>[^\|\$\%\.]*\|(?<quantity>\d+)\|[^\|\$\%\.]*?(?<price>\d+(\.\d+)?)\$$";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(input);
               
                if (match.Success)
                {
                    int count = int.Parse(match.Groups["quantity"].Value);
                    double price = double.Parse(match.Groups["price"].Value);
                    double totalPrice = count * price;
                    income += (decimal)totalPrice;

                    Console.WriteLine($"{match.Groups["name"]}: {match.Groups["product"]} - {totalPrice:f2}");
                }

                
            }
            Console.WriteLine($"Total income: {income:f2}");
        }
    }
}
