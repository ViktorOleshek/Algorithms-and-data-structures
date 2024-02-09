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

namespace ACD_lab4
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

    double [] array;
    private void PrintArray()
    {
      TextBox_PrintArray.Text = string.Join(" ", array);
      TextBox_PrintArray.Visibility = Visibility.Visible;
    }
    private int FindMaxElement()
    {
      int indexMaxElement = 0;
      for (int i = 0; i < array.Length; i++)
      {
        if (array [i] > array [indexMaxElement])
        {
          indexMaxElement = i;
        }
      }
      return indexMaxElement;
    }
    // Рекурсивна функція для сортування масиву методом злиття
    public static void MergeSort(double [] arr, int left, int right)
    {
      if (left < right)
      {
        // Знаходимо середину масиву
        int mid = (left + right) / 2;

        // Рекурсивно сортуємо ліву і праву половини масиву
        MergeSort(arr, left, mid);
        MergeSort(arr, mid + 1, right);

        // Злиття двох підмасивів
        Merge(arr, left, mid, right);
      }
    }
    // Функція для злиття двох підмасивів у відсортований масив
    public static void Merge(double [] arr, int left, int mid, int right)
    {
      int sizeLeftArray = mid - left + 1;
      int sizeRightArray = right - mid;

      double [] leftArray = new double [sizeLeftArray];
      double [] rightArray = new double [sizeRightArray];

      Array.Copy(arr, left, leftArray, 0, sizeLeftArray);
      Array.Copy(arr, mid + 1, rightArray, 0, sizeRightArray);

      int i = 0, j = 0;// обхід лівого і правого підмасивів
      int k = left;// обновлення початкового елемента

      while (i < sizeLeftArray && j < sizeRightArray)//
      {
        arr [k++] = (leftArray [i] >= rightArray [j]) ? leftArray [i++] : rightArray [j++];
      }
      //якщо залишилися елементи в лівому, то вставляємо їх
      while (i < sizeLeftArray)
      {
        arr [k++] = leftArray [i++];
      }
      //якщо залишилися елементи в правому, то вставляємо їх
      while (j < sizeRightArray)
      {
        arr [k++] = rightArray [j++];
      }
    }
    private void SortAfterMax()
    {
      int indexMaxElement = FindMaxElement();
      double [] elementsAfterMax = new double [array.Length - indexMaxElement - 1];
      Array.Copy(array, indexMaxElement + 1, elementsAfterMax, 0, array.Length - indexMaxElement - 1);

      MergeSort(elementsAfterMax, 0, elementsAfterMax.Length - 1);

      // З'єднати два підмасиви в вихідний масив
      Array.Copy(elementsAfterMax, 0, array, indexMaxElement + 1, elementsAfterMax.Length);
    }
    private void Button_CreateArray(object sender, RoutedEventArgs e)
    {
      int ArraySize = Convert.ToInt32(TextBox_ArraySize1.Text);
      array = new double [ArraySize];

      Random random = new Random();
      for (int i = 0; i < array.Length; i++)
      {
        array [i] = random.Next(10, 99);
      }
      PrintArray();
    }
    private void Button_MargeSort(object sender, RoutedEventArgs e)
    {
      Stopwatch time = new Stopwatch();
      time.Start();

      SortAfterMax();

      time.Stop();
      Label_SortingTime.Content = $"Time: {time.ElapsedMilliseconds} ms";

      PrintArray();
    }
    private void Button_CheckingSort(object sender, RoutedEventArgs e)
    {
      bool result = true;
      for (int i = FindMaxElement(); i < array.Length - 1; i++)
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
