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
            int index = text.IndexOf(word);

            while (index >= 0)
            {
                text = text.Remove(index, word.Length);
                index = text.IndexOf(word);
            }

            return text;
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

        public static int RepetitionsOfWord(string text, string searchWord)
        {
            MatchCollection words = Regex.Matches(text, @"\b\w+\b");

            if (text == "" || searchWord == "") return 0;

            int count = 0;

            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].Value == searchWord)
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
            return Regex.Matches(text, @"\b\w+\b").Count;
        }

        public static string Encode(string text, int codeKey)
        {
            StringBuilder result = new StringBuilder(text.Length);

            for (int i = 0; i < text.Length; i++)
            {
                result.Append((char)(text[i] + codeKey));
            }

            return result.ToString();
        }
    }
}
