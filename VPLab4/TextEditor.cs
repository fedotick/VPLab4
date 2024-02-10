using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace VPLab4
{
    internal class TextEditor
    {
        public static string DeleteWord(string text, string word)
        {
            return text.Replace(word, "");
        }

        public static string TurnOverEveryWord(string text)
        {
            string[] words = Regex.Split(text, @"\W+");

            if (words[0] == "") return text;

            HashSet<string> uniqueWords = new HashSet<string>(words);

            foreach (string word in uniqueWords)
            {
                text = text.Replace(word, FlipWord(word));
            }

            return text;
        }

        public static string FlipWord(string word)
        {
            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
