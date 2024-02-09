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

namespace ACD_lab3
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      TextBox_PrintArray.Visibility = Visibility.Hidden;
    }

    private double [,] array;
    private void PrintArray()
    {
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < array.GetLength(0); i++)
      {
        for (int j = 0; j < array.GetLength(1); j++)
        {
          sb.Append(array [i, j]);
          if (j < array.GetLength(1) - 1)
          {
            sb.Append(", ");
          }
        }
        sb.AppendLine(); // перехід на новий рядок
      }
      TextBox_PrintArray.Visibility = Visibility.Visible;
      TextBox_PrintArray.Text = sb.ToString();
    }
    private void Button_CreateArray(object sender, RoutedEventArgs e)
    {
      int ArraySize = Convert.ToInt32(TextBox_ArraySize1.Text);
      array = new double [ArraySize, ArraySize];

      Random random = new Random();
      for (int i = 0; i < array.GetLength(0); i++)
      {
        for (int j = 0; j < array.GetLength(1); j++)
        {
          array [i, j] = random.Next(0, 9);
        }
      }
      PrintArray();
    }
    private void Button_QuickSort(object sender, RoutedEventArgs e)
    {
      Stopwatch time = new Stopwatch();
      time.Start();

      QuickSort(array, 0, 0, array.GetLength(0) - 1);

      time.Stop();
      Label_SortingTime.Content = $"Time: {time.ElapsedMilliseconds} ms";

      PrintArray();
    }
    private void QuickSort(double [,] arr, int columnIndex, int left, int right)
    {
      if (left < right)
      {
        // індекс опорного елементу після розділення
        int pivotIndex = Partition(arr, columnIndex, left, right);

        // Рекурсивно сортуємо ліву та праву частини масиву навколо опорного елементу
        QuickSort(arr, columnIndex, left, pivotIndex - 1);
        QuickSort(arr, columnIndex, pivotIndex + 1, right);
      }
    }
    private static int Partition(double [,] array, int columnIndex, int leftLimit, int rightLimit)
    {
      double pivot = array [rightLimit, columnIndex];
      int i = leftLimit - 1;// більше опорного
      int j = rightLimit;// менше опорного

      while (true)
      {
        while (array [++i, columnIndex] < pivot)
        {
          if (i == rightLimit)
            break;
        }

        while (pivot < array [--j, columnIndex])
        {
          if (j == leftLimit)
            break;
        }

        if (i >= j)
          break;

        SwapRows(array, i, j);
      }

      SwapRows(array, i, rightLimit);
      return i;
    }
    private static void SwapRows(double [,] arr, int i, int j)
    {
      int numCols = arr.GetLength(1);
      for (int col = 0; col < numCols; col++)
      {
        (arr [i, col], arr [j, col]) = (arr [j, col], arr [i, col]);
      }
    }
    private void Button_CheckingSort(object sender, RoutedEventArgs e)
    {
      bool result = true;
      for (int i = 0; i < array.GetLength(0) - 1; i++)
      {
        if (array [i, 0] > array [i + 1, 0])
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
    private void Button_ChangeMaxElementInRow(object sender, RoutedEventArgs e)
    {
      for (int i = 0; i < array.GetLength(0); i++)
      {
        double maxElementInRow = array [i, 0];
        int indexMaxElementInRow = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
          if (maxElementInRow < array [i, j])
          {
            maxElementInRow = array [i, j];
            indexMaxElementInRow = j;
          }
        }
        array [i, indexMaxElementInRow] =
          Math.Round(Math.Log(maxElementInRow, 9), 2);
      }
      PrintArray();
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
