using System;
using System.Collections.Generic;
using System.Data;
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

namespace ACD_lab5
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      TextBox_StartArray.Visibility = Visibility.Hidden;
      TextBox_SortArray.Visibility = Visibility.Hidden;
    }

    int [] array;

    private void PrintArray(TextBox obj, int [] arr)
    {
      obj.Text = string.Join(" ", arr);
      obj.Visibility = Visibility.Visible;
    }
    private void Button_CreateArray(object sender, RoutedEventArgs e)
    {
      int ArraySize = Convert.ToInt32(TextBox_ArraySize1.Text);
      array = new int [ArraySize];

      Random random = new Random();
      for (int i = 0; i < array.Length; i++)
      {
        array [i] = random.Next(0, 5);
      }
      PrintArray(TextBox_StartArray, array);
    }
    private void SortDescending(int [] arr)
    {
      int min = arr.Min();
      int max = arr.Max();

      int range = max - min + 1;

      // Створюємо масив для підрахунку кількості елементів у кожному діапазоні
      int [] count = new int [range];

      // Створюємо масив для збереження відсортованих значень
      int [] output = new int [arr.Length];

      // Підраховуємо кількість кожного елемента в масиві
      for (int i = 0; i < arr.Length; i++)
      {
        count [arr [i] - min]++;
      }
      PrintArray(TextBox_Count, count);

      // Акумулюємо підрахунок кількостей елементів
      for (int i = 1; i < range; i++)
      {
        count [i] += count [i - 1];
      }

      // Розміщуємо елементи в правильному порядку в масиві output
      for (int i = arr.Length - 1; i >= 0; i--)
      {
        output [count [arr [i] - min] - 1] = arr [i];
        count [arr [i] - min]--;
      }

      array = output.Reverse().ToArray();
    }

    private void Button_SortDescending(object sender, RoutedEventArgs e)
    {
      Stopwatch time = new Stopwatch();
      time.Start();

      SortDescending(array);

      time.Stop();
      Label_SortingTime.Content = $"Time: {time.ElapsedMilliseconds} ms";

      PrintArray(TextBox_SortArray, array);
    }
    private void Button_CheckingSort(object sender, RoutedEventArgs e)
    {
      bool result = true;
      for (int i = 0; i < array.Length - 1; i++)
      {
        if (array [i] < array [i + 1])
        {
          result = false;
        }
      }
      if (result)
      {
        Label_ResultCheck.Content = "Result: true";
      }
      else
      {
        Label_ResultCheck.Content = "Result: false";
      }
    }
    private void Button_RemoveElementsMultiplies3(object sender, RoutedEventArgs e)
    {
      array = array.Where(x => x % 3 != 0).
        Select(x => (int) Math.Pow(x, 2)).
        ToArray();
      PrintArray(TextBox_StartArray, array);
    }
    private void Button_Exit(object sender, RoutedEventArgs e)
    {
      Environment.Exit(0);
    }
    // очистка пам'яті
    private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      array = null;
      GC.Collect();
    }
  }
}
