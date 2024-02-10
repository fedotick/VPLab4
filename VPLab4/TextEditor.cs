using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
