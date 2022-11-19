using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Race
{
    class Race
    {
        static void Main(string[] args)
        {
            string racers = Console.ReadLine();//George, Peter, Bill, Tom

            string input = string.Empty;
            Dictionary<string, int> validPatternNames = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "end of race")//G4e@55or%6g6!68e!!@
            {
                string patternForName = @"(?<name>[A-Za-z])";//6 matches George
                string patternForDistance = @"(?<distance>[0-9])";//7 matches 4556668
                Regex regexForName = new Regex(patternForName);
                Regex regexForDistance = new Regex(patternForDistance);
                MatchCollection charsOfName = regexForName.Matches(input);
                MatchCollection digitsOfDistance = regexForDistance.Matches(input);

                var sb = new StringBuilder();
                foreach (Match @char in charsOfName)
                {
                    sb.Append(@char.Value);
                }

                string patternName = sb.ToString();//George
                int distance = 0;
                foreach (Match digit in digitsOfDistance)
                {
                    distance += int.Parse(digit.Value);
                }

                if (racers.Contains(patternName))
                {
                    if (!validPatternNames.ContainsKey(patternName))
                    {

                        validPatternNames[patternName] = 0;
                    }

                    validPatternNames[patternName] += distance;
                }
            }

            List<string> orderedListOfRacers = validPatternNames
                .OrderByDescending(item => item.Value)
                .Select(item => item.Key)
                .Take(3)
                .ToList();
            
            Console.WriteLine($"1st place: {orderedListOfRacers[0]}");
            Console.WriteLine($"2nd place: {orderedListOfRacers[1]}");
            Console.WriteLine($"3rd place: {orderedListOfRacers[2]}");

            //foreach (var item in validPatternNames.OrderByDescending(item => item.Value).Take(3))
            //{
            //    Console.WriteLine(item.Key);

            //}
        }
    }
}
