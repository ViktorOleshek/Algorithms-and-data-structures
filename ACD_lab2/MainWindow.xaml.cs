using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ACD_lab2
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

    private int [] array1, array2, array3;
    private void Button_CreateArray1(object sender, RoutedEventArgs e)
    {
      int ArraySize = Convert.ToInt32(TextBox_ArraySize1.Text);
      array1 = new int [ArraySize];

      Random random = new Random();
      for (int i = 0; i < array1.Length; i++)
      {
        array1 [i] = random.Next(-100, 100);
      }

      Label_PrintArray1.Content = string.Join(", ", array1);
    }
    private void Button_CreateArray2(object sender, RoutedEventArgs e)
    {
      int ArraySize = Convert.ToInt32(TextBox_ArraySize2.Text);
      array2 = new int [ArraySize];

      Random random = new Random();
      for (int i = 0; i < array2.Length; i++)
      {
        array2 [i] = random.Next(-100, 100);
      }

      Label_PrintArray2.Content = string.Join(", ", array2);
    }
    private void Button_CreateArray3(object sender, RoutedEventArgs e)
    {
      array3 = array1.Where(x => x % 2 == 0)
        .Concat(array2.Where(x => x % 2 != 0))
        .ToArray();

      Label_PrintArray3.Content = string.Join(", ", array3);
    }
    private void Button_Sort(object sender, RoutedEventArgs e)
    {
      Stopwatch time = new Stopwatch();
      time.Start();

      int step = array3.Length / 2;

      while (step > 0)
      {
        for (int i = step; i < array3.Length; i++)
        {
          int temp = array3 [i];
          int j = i;

          while (j >= step && array3 [j - step] > temp)
          {
            array3 [j] = array3 [j - step];
            j -= step;
          }
          array3 [j] = temp;
        }
        Label_PrintArray3.Content += "\n";
        Label_PrintArray3.Content += string.Join(", ", array3);
        step /= 2;
      }
      time.Stop();
      Label_SortingTime.Content = $"Time: {time.ElapsedMilliseconds} ms";
    }
    private void Button_CheckingSort(object sender, RoutedEventArgs e)
    {
      bool result = true;
      for (int i = 0; i < array3.Length - 1; i++)
      {
        if (array3 [i] > array3 [i + 1])
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

    private void Button_Exit(object sender, RoutedEventArgs e)
    {
      Environment.Exit(0);
    }
    // очистка пам'яті
    private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      array1 = null;
      array2 = null;
      array3 = null;
      GC.Collect();
    }
  }

}
