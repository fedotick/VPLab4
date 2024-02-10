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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            richTextBoxEnterText.TextChanged += RichTextBoxEnterText_TextChanged;
            richTextBoxDeleteWord.TextChanged += RichTextBoxDeleteWord_TextChanged;
            richTextBoxRepetitionWord.TextChanged += RichTextBoxRepetitionWord_TextChanged;
        }

        private void RichTextBoxEnterText_TextChanged(object sender, TextChangedEventArgs e)
        {
            Placeholder(sender, labelEnterText, "Enter text...");
        }

        private void RichTextBoxDeleteWord_TextChanged(object sender, TextChangedEventArgs e)
        {
            Placeholder(sender, labelDeleteWord, "Enter word...");
        }

        private void RichTextBoxRepetitionWord_TextChanged(object sender, TextChangedEventArgs e)
        {
            Placeholder(sender, labelRepetitionWord, "Enter word...");
        }

        private void Placeholder(object sender, Label label, string placeholderText)
        {
            RichTextBox richTextBox = (RichTextBox)sender;
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            string text = textRange.Text;

            if (text.Length == 2)
            {
                label.Content = placeholderText;
            }
            else
            {
                label.Content = "";
            }
        }
    }
}
