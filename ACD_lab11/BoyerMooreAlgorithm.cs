using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ACD_lab11
{
  internal class BoyerMooreAlgorithm
  {
    private int [] BuildBadCharShift(string pattern)
    {
      int m = pattern.Length;
      int [] badCharShift = new int [256];

      for (int i = 0; i < badCharShift.Length; i++)
        badCharShift [i] = m; // якщо символ не входить у паттерн, то зсув = довжині паттерну

      for (int i = 0; i < m - 1; i++)
        badCharShift [pattern [i]] = m - 1 - i;

      return badCharShift;
    }

    public int Search(string text, string pattern, TextBox textBox_Log)
    {
      int n = text.Length;
      int m = pattern.Length;

      int [] badCharShift = BuildBadCharShift(pattern);


      int i = m - 1; // початкове положення паттерну у тексті

      textBox_Log.Text += "Stop symbols: ";
      while (i < n)
      {
        int j = m - 1;

        while (j >= 0 && (text [i] == pattern [j] || pattern [j] == ' '))
        {
          i--;
          j--;
        }

        if (j < 0)
        {

          textBox_Log.Text += "\n";
          return i + 1; // знайдено входження
        }

        int badCharShiftValue = badCharShift [text [i]];
        textBox_Log.Text += text [i] + "/";
        int spaceShift = pattern.Substring(j + 1).LastIndexOf(' ');

        i += Math.Max(badCharShiftValue, spaceShift + 1);
      }
      textBox_Log.Text += "\n";

      return -1; // входжень не знайдено
    }
  }
}
