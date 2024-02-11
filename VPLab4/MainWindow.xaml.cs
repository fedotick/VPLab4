using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            TextRange textRangeEnterText = new TextRange(richTextBoxEnterText.Document.ContentStart, richTextBoxEnterText.Document.ContentEnd);
            TextRange textRangeDeleteWord = new TextRange(richTextBoxDeleteWord.Document.ContentStart, richTextBoxDeleteWord.Document.ContentEnd);

            string enterText = textRangeEnterText.Text.TrimStart('\r', '\n').TrimEnd('\r', '\n');
            string deleteWord = textRangeDeleteWord.Text.TrimStart('\r', '\n').TrimEnd('\r', '\n');

            string result = TextEditor.DeleteWord(enterText, deleteWord);
            textRangeEnterText.Text = result;

            Placeholder(richTextBoxEnterText, labelEnterText, "Enter text...");
        }

        private void ButtonTurnOverEveryWord_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRangeEnterText = new TextRange(richTextBoxEnterText.Document.ContentStart, richTextBoxEnterText.Document.ContentEnd);

            string enterText = textRangeEnterText.Text.TrimStart('\r', '\n').TrimEnd('\r', '\n');

            textRangeEnterText.Text = TextEditor.TurnOverEveryWord(enterText);
        }

        private void RepetitionsOfWord(RichTextBox richTextBoxEnterText, RichTextBox richTextBoxRepetitionWord)
        {
            TextRange textRangeEnterText = new TextRange(richTextBoxEnterText.Document.ContentStart, richTextBoxEnterText.Document.ContentEnd);
            TextRange textRangeRepetitionWord = new TextRange(richTextBoxRepetitionWord.Document.ContentStart, richTextBoxRepetitionWord.Document.ContentEnd);

            string enterText = textRangeEnterText.Text.TrimStart('\r', '\n').TrimEnd('\r', '\n');
            string repetitionWord = textRangeRepetitionWord.Text.TrimStart('\r', '\n').TrimEnd('\r', '\n');

            labelRepetitionWord.Content = "Repetitions: " + TextEditor.RepetitionsOfWord(enterText, repetitionWord);
        }

        private void ButtonRemoveExtraSpaces_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRangeEnterText = new TextRange(richTextBoxEnterText.Document.ContentStart, richTextBoxEnterText.Document.ContentEnd);

            string enterText = textRangeEnterText.Text.TrimStart('\r', '\n').TrimEnd('\r', '\n');

            textRangeEnterText.Text = TextEditor.RemoveExtraSpaces(enterText);
        }

        private void CountWords(RichTextBox richTextBoxEnterText)
        {
            TextRange textRangeEnterText = new TextRange(richTextBoxEnterText.Document.ContentStart, richTextBoxEnterText.Document.ContentEnd);

            string enterText = textRangeEnterText.Text.TrimStart('\r', '\n').TrimEnd('\r', '\n');

            labelCountWords.Content = "Words: " + TextEditor.CountWords(enterText);
        }
    }
}
