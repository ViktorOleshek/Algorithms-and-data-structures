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

namespace ACD_lab10
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
    void FindLongestWord(out string longestWord)
    {
      string inputText = textBox_Text1.Text;

      string [] words = inputText.Split(' ');

      longestWord = "";

      foreach (string word in words)
      {
        if (word.Length > longestWord.Length)
        {
          longestWord = word;
        }
      }
    }
    /// <summary>
    /// Обчислює префікс-функцію для заданого образу.
    /// </summary>
    /// <returns>Масив значень префікс-функції.</returns>
    public int [] PrefixFunction(string searchWord)
    {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();

      int [] D = new int [searchWord.Length];
      D [0] = 0;
      int k = 0;

      for (int i = 2; i <= searchWord.Length; i++)
      {
        while (k > 0 && searchWord [k] != searchWord [i - 1])
        {
          k = D [k];
        }
        if (searchWord [k] == searchWord [i - 1])
        {
          k++;
        }
        D [i - 1] = k;
      }

      textBox_Log.Text += "Значення префікс функції: ";
      textBox_Log.Text += string.Join(" ", D);

      stopwatch.Stop();
      textBox_Log.Text += $"\nЧас префікс-функції = " +
        $"{stopwatch.ElapsedMilliseconds} ms\n";
      return D;
    }
    public bool KnuthMorrisPrattSearch(string searchWord,
      string text, int [] D)
    {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();

      int i = 0;
      int j = 0;
      int d = 1;//скільки символів співпало

      while (j < searchWord.Length && i < text.Length)
      {
        if (text [i] == searchWord [j])
        {
          d++;
          i++;
          j++;
          textBox_Log.Text += $"D(" +
            $"{searchWord.Substring(0, j)}, {i}): {D [d - 1]}\n";
          if (d == searchWord.Length)
          {
            stopwatch.Stop();
            textBox_Log.Text += $"Час пошуку = {stopwatch.ElapsedMilliseconds} ms\n";
            return true;
          }
        }
        else
        {
          i = i + d - D [d];
          d = 1;
          j = 0;
        }
      }
      stopwatch.Stop();
      textBox_Log.Text += "Не вдалося знайти слово.";
      return false;
    }
    private void button_Running(object sender, RoutedEventArgs e)
    {
      if (ValidateTextBox(textBox_Text1) && ValidateTextBox(textBox_Text2))
      {
        button_ClearLog(sender, e);
        FindLongestWord(out string longestWord);
        int [] valuePrefixFunc = PrefixFunction(longestWord);
        KnuthMorrisPrattSearch(longestWord, textBox_Text2.Text,
          valuePrefixFunc);
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