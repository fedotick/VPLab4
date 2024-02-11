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

        public static int RepetitionsOfWord(string text, string searchWord)
        {
            text = text.TrimStart().TrimEnd();
            searchWord = searchWord.TrimStart().TrimEnd();

            if (text == "" || searchWord == "") return 0;

            int count = 0;
            
            string[] words = Regex.Split(text, @"\W+");

            foreach (string word in words)
            {
                if (searchWord == word)
                {
                    count++;
                }
            }

            return count;
        }

        public static string RemoveExtraSpaces(string text)
        {
            return Regex.Replace(text, @"\s+", " ").Trim();
        }

        public static int CountWords(string text)
        {
            text = text.Trim();

            if (text == "") return 0;

            string[] words = Regex.Split(text, @"\W+");

            return words.Length;
        }
    }
}
