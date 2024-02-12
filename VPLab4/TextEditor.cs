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
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    for (int j = i + 1; i < text.Length; j++)
                    {
                        if (!char.IsLetter(text[j]))
                        {
                            text = text.Remove(i, j - i).Insert(i, new string(text.Substring(i, j - i).Reverse().ToArray()));
                            i = j;
                            break;
                        }
                    }
                }
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

        public static string Encode(string text, int codeKey)
        {
            char[] letters = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                letters[i] = (char)(text[i] + codeKey);
            }

            return new string(letters);
        }
    }
}
