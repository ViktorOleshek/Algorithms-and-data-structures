using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace ACD_lab9
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    int [] array;
    public MainWindow()
    {
      InitializeComponent();
      textBox_PrintArray.Visibility = Visibility.Collapsed;
    }

    private void CheckUsersEnter(out int value, TextBox textbox)
    {
      if (string.IsNullOrEmpty(textbox.Text))
      {
        MessageBox.Show(messageBoxText: "Please, enter an element");
        value = '\0'; // Позначка, що дані недійсні
        return;
      }

      if (!int.TryParse(textbox.Text, out value))
      {
        MessageBox.Show("Invalid input. Please enter a single character.");
        value = '\0'; // Позначка, що дані недійсні
      }
    }
    void PrintArray(TextBox textBox)
    {
      textBox_PrintArray.Visibility = Visibility.Visible;
      textBox.Clear();
      textBox.Text = string.Join(" ", array);
    }
    void CreateArray(int numberElements)
    {
      array = new int [numberElements];

      Random random = new Random();
      for (int i = 0; i < numberElements; i++)
      {
        array [i] = random.Next(array.Length);
      }
    }
    private void button_CreateArray(object sender, RoutedEventArgs e)
    {
      int numberElements;
      CheckUsersEnter(out numberElements, textBox_NumberElements);
      if (numberElements == '\0') { return; }

      CreateArray(numberElements);
      PrintArray(textBox_PrintArray);
    }
    private void button_SortArray(object sender, RoutedEventArgs e)
    {
      Array.Sort(array);
      PrintArray(textBox_PrintArray);
    }
    public int GetFibonacciNumberAtPosition(int position)
    {
      if (position <= 0)
      {
        throw new ArgumentException("The position of the Fibonacci number should be greater than 0.");
      }

      if (position <= 2)
      {
        return 1;
      }

      int a = 1, b = 1, FibonacciNumber = 0;

      for (int i = 3; i <= position; i++)
      {
        FibonacciNumber = a + b;
        a = b;
        b = FibonacciNumber;
      }

      return FibonacciNumber;
    }
    bool BinarySearch(int FibonacciNumber, out int index)
    {
      int left = 0;
      int right = array.Length - 1;
      index = -1;
      int i = 0;// кількість порівнянь
      while (left <= right)
      {
        ++i;
        int middle = left + (right - left) / 2;

        if (array [middle] >= FibonacciNumber)
        {
          index = middle;
          right = middle - 1;
        }
        else
        {
          left = middle + 1;
        }
      }
      textBox_NumberСomparisons.Text = i.ToString();
      // Повертає true, якщо знайдено хоча б один відповідний елемент
      return index != -1;
    }
    private void button_SearchElement(object sender, RoutedEventArgs e)
    {
      int positionNumberFibonacci;
      CheckUsersEnter(out positionNumberFibonacci, textBox_NumberFibonacci);
      if (positionNumberFibonacci == '\0') { return; }

      int FibonacciNumber = GetFibonacciNumberAtPosition(positionNumberFibonacci);


      if (BinarySearch(FibonacciNumber, out int index))
      {
        MessageBox.Show($"Перший елемент, що більший або рівний " +
          $"{FibonacciNumber}, знайдений на позиції {index + 1}");
      }
      else
      {
        MessageBox.Show($"Немає елементів, що більші або рівні" +
          $" {FibonacciNumber} в масиві");
      }
    }

    private void button_Exit(object sender, RoutedEventArgs e)
    {
      Environment.Exit(0);
    }
  }
}
