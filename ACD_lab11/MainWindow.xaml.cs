using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ACD_lab11
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }
    private bool ValidateTextBox(TextBox textBox)
    {
      if (string.IsNullOrWhiteSpace(textBox.Text))
      {
        MessageBox.Show("Будь ласка, введіть дані в TextBox!");
        return false;
      }
      else
      {
        string enteredData = textBox.Text;
        return true;
      }
    }
    void FindWordWithLeastVowels(out string wordWithLeastVowels)
    {
      string inputText = textBox_Text1.Text;

      string [] words = inputText.Split(' ');

      wordWithLeastVowels = "";

      int minVowelCount = int.MaxValue;

      foreach (string word in words)
      {
        int vowelCount = CountVowels(word);

        if (vowelCount < minVowelCount)
        {
          minVowelCount = vowelCount;
          wordWithLeastVowels = word;
        }
      }
    }

    int CountVowels(string word)
    {
      int count = 0;
      string vowels = "aeiouAEIOU";

      foreach (char c in word)
      {
        if (vowels.Contains(c))
        {
          count++;
        }
      }

      return count;
    }
    string ReverseWord(string inputWord)
    {
      char [] charArray = inputWord.ToCharArray();
      Array.Reverse(charArray);
      return new string(charArray);
    }

    /// <summary>
    /// Обчислює префікс-функцію для заданого образу.
    /// </summary>
    /// <returns>Масив значень префікс-функції.</returns>
    private void button_Running(object sender, RoutedEventArgs e)
    {
      if (ValidateTextBox(textBox_Text1) && ValidateTextBox(textBox_Text2))
      {
        button_ClearLog(sender, e);
        FindWordWithLeastVowels(out string wordWithLeastVowels);
        textBox_Log.Text += wordWithLeastVowels + '\n';
        wordWithLeastVowels = ReverseWord(wordWithLeastVowels);
        textBox_Log.Text += wordWithLeastVowels + '\n';

        BoyerMooreAlgorithm boyerMooreAlgorithm = new BoyerMooreAlgorithm();
        int index = boyerMooreAlgorithm.Search(textBox_Text2.Text, 
          wordWithLeastVowels, textBox_Log);
        if (index == -1)
        {
          textBox_Log.Text += "No matches found\n";
        }
        else
        {
          textBox_Log.Text += "Match found at index: " + index + "\n";
        }
      }
      else
      {
        return;
      }
    }
    private void button_Exit(object sender, RoutedEventArgs e)
    {
      Environment.Exit(0);
    }
    private void button_ClearLog(object sender, RoutedEventArgs e)
    {
      textBox_Log.Clear();
    }
  }
}