using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class stringUtility
    {
        public static string SummerizeText(string longText, int maxLength = 20)
        {

            if (longText.Length < maxLength)
                return longText;


            var words = longText.Split(' ');
            var totalCharacters = 0;
            var summaryWords = new List<string>();

            foreach (var word in words)
            {
                summaryWords.Add(word);

                totalCharacters += word.Length + 1;
                if (totalCharacters > maxLength)
                {
                    break;
                }

            }

            var summary = String.Join(" ", summaryWords) + "...";

            return summary;

        }
    }
}
