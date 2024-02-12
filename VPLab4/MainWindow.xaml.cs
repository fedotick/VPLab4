using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace VPLab4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            richTextBoxEnterText.TextChanged += RichTextBoxEnterText_TextChanged;
            richTextBoxDeleteWord.TextChanged += RichTextBoxDeleteWord_TextChanged;
            richTextBoxRepetitionWord.TextChanged += RichTextBoxRepetitionWord_TextChanged;

            buttonDelete.Click += ButtonDelete_Click;
            buttonTurnOverEveryWord.Click += ButtonTurnOverEveryWord_Click;
            buttonRemoveExtraSpaces.Click += ButtonRemoveExtraSpaces_Click;
            buttonEncode.Click += ButtonEncode_Click;
            buttonDecode.Click += ButtonDecode_Click;
        }

        private void RichTextBoxEnterText_TextChanged(object sender, TextChangedEventArgs e)
        {
            Placeholder((RichTextBox)sender, labelEnterText, "Enter text...");
            RepetitionsOfWord((RichTextBox)sender, richTextBoxRepetitionWord);
            CountWords((RichTextBox)sender);
        }

        private void RichTextBoxDeleteWord_TextChanged(object sender, TextChangedEventArgs e)
        {
            Placeholder((RichTextBox)sender, labelDeleteWord, "Enter word...");
        }

        private void RichTextBoxRepetitionWord_TextChanged(object sender, TextChangedEventArgs e)
        {
            Placeholder((RichTextBox)sender, labelEnterRepetitionWord, "Enter word...");
            RepetitionsOfWord(richTextBoxEnterText, (RichTextBox)sender);
        }

        private void Placeholder(RichTextBox richTextBox, Label label, string placeholderText)
        {
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            string text = textRange.Text;

            if (text.Length <= 2)
            {
                label.Content = placeholderText;
            }
            else
            {
                label.Content = "";
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            string enterText = GetTextFromRichTextBox(richTextBoxEnterText);
            string deleteWord = GetTextFromRichTextBox(richTextBoxDeleteWord);

            string result = TextEditor.DeleteWord(enterText, GetWord(deleteWord));

            SetTextInRichTextBox(richTextBoxEnterText, result);

            Placeholder(richTextBoxEnterText, labelEnterText, "Enter text...");
        }

        private void ButtonTurnOverEveryWord_Click(object sender, RoutedEventArgs e)
        {
            string enterText = GetTextFromRichTextBox(richTextBoxEnterText);

            string result = TextEditor.TurnOverEveryWord(enterText);

            SetTextInRichTextBox(richTextBoxEnterText, result);
        }

        private void RepetitionsOfWord(RichTextBox richTextBoxEnterText, RichTextBox richTextBoxRepetitionWord)
        {
            string enterText = GetTextFromRichTextBox(richTextBoxEnterText);
            string repetitionWord = GetTextFromRichTextBox(richTextBoxRepetitionWord);

            labelRepetitionWord.Content = "Repetitions: " + TextEditor.RepetitionsOfWord(enterText, GetWord(repetitionWord));
        }

        private void ButtonRemoveExtraSpaces_Click(object sender, RoutedEventArgs e)
        {
            string enterText = GetTextFromRichTextBox(richTextBoxEnterText);

            string result = TextEditor.RemoveExtraSpaces(enterText);

            SetTextInRichTextBox(richTextBoxEnterText, result);
        }

        private void CountWords(RichTextBox richTextBoxEnterText)
        {
            string enterText = GetTextFromRichTextBox(richTextBoxEnterText);

            labelCountWords.Content = "Words: " + TextEditor.CountWords(enterText);
        }

        private void ButtonEncode_Click(object sender, RoutedEventArgs e)
        {
            string enterText = GetTextFromRichTextBox(richTextBoxEnterText);

            string result = TextEditor.Encode(enterText, 2);

            SetTextInRichTextBox(richTextBoxEnterText, result);
        }

        private void ButtonDecode_Click(object sender, RoutedEventArgs e)
        {
            string enterText = GetTextFromRichTextBox(richTextBoxEnterText);

            string result = TextEditor.Encode(enterText, -2);

            SetTextInRichTextBox(richTextBoxEnterText, result);
        }

        private string GetTextFromRichTextBox(RichTextBox richTextBox)
        {
            return new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
        }

        public void SetTextInRichTextBox(RichTextBox richTextBox, string newText)
        {
            richTextBox.Document.Blocks.Clear();
            richTextBox.Document.Blocks.Add(new Paragraph(new Run(newText)));
        }

        public string GetWord(string text, int index = 0)
        {
            MatchCollection words = Regex.Matches(text, @"\b\w+\b");

            if (words.Count > 0) return words[index].Value;

            return string.Empty;
        }
    }
}
