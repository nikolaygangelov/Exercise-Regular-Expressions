
namespace _4._Star_Enigma
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

            int n = int.Parse(Console.ReadLine());

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string encryptedMessage = Console.ReadLine();
                string toLower = encryptedMessage.ToLower();
                int decryptionKey = 0;

                for (int j = 0; j < encryptedMessage.Length; j++)
                {
                    char currentChar = toLower[j];
                    
                    if(currentChar == 's' || currentChar == 't' || currentChar == 'a' || currentChar == 'r')
                    {
                        decryptionKey++;
                    }

                }

                var sb = new StringBuilder();
                for (int k = 0; k < encryptedMessage.Length; k++)
                {
                    char currentChar = encryptedMessage[k];//S
                    int newAsciiValue = (int)currentChar - decryptionKey;//83-3=80
                    sb.Append((char)newAsciiValue);
                }

                string decryptedMessage = sb.ToString();//PQ@Alderaa1:30000!A!->20000
                string pattern = @"@(?<planetName>[A-Za-z]+)[^\@\-\!\:]*:(?<planetPopulation>\d+)[^\@\-\!\:]*!(?<attackType>A|D)![^\@\-\!\:]*->(?<count>\d+)";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(decryptedMessage);

                if (match.Success)
                {

                    if (match.Groups["attackType"].Value == 'A'.ToString())
                    {

                        if (!attackedPlanets.Contains(match.Groups["planetName"].Value))
                        {
                            attackedPlanets.Add(match.Groups["planetName"].Value);
                        }

                    }
                    else if(match.Groups["attackType"].Value == 'D'.ToString())
                    {

                        if (!destroyedPlanets.Contains(match.Groups["planetName"].Value))
                        {
                            destroyedPlanets.Add(match.Groups["planetName"].Value);
                        }

                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            foreach (string attackedPlanet in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {attackedPlanet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            foreach (string destroyedPlanet in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {destroyedPlanet}");
            }
        }
    }
}
