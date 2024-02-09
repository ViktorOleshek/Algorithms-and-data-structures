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

namespace ACD_lab7
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    LinkedList<int> linkedList1 = new LinkedList<int>();
    //LinkedList<int> linkedList2 = new LinkedList<int>();
    //LinkedList<int> linkedList3 = new LinkedList<int>();
    public MainWindow()
    {
      InitializeComponent();
    }
    void PrintStruct(LinkedList<int> linkedList, TextBox textBox)
    {
      textBox.Text = string.Empty;
      Node<int> current = linkedList.Head;
      while (current != null)
      {
        textBox.Text += current.Data.ToString() + ", ";
        current = current.Next;
      }
    }
    void CreateStruct(LinkedList<int> linkedList)
    {
      linkedList.Clear();
      string str = textBox_UsersEnter.Text;

      var numericData = str.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                          .Where(x => int.TryParse(x, out _))
                          .Select(x => int.Parse(x))
                          .ToArray();

      if (numericData.Length > 0)
      {
        foreach (var number in numericData)
        {
          linkedList.AddElement(number);
        }
      }
      else
      {
        MessageBox.Show("Please enter numeric data in TextBox");
      }
    }
    private void button_CreateStruct(object sender, RoutedEventArgs e)
    {
      CreateStruct(linkedList1);
      //CreateStruct(linkedList2);
    }
    private void PrintBeforeMinAndAfterMax()
    {
      var minElementIndex = linkedList1.IndexOf(linkedList1.MinElement());
      var maxElementIndex = linkedList1.IndexOf(linkedList1.MaxElement());

      if (minElementIndex >= 1)
      {
        Label_NumberElements.Content += "before min = " + linkedList1.ElementAt(minElementIndex - 1).ToString() + "\t";
      }
      else
      {
        Label_NumberElements.Content += "Not found element before min element\n";
      }

      if (maxElementIndex < linkedList1.GetNumberElements() - 1)
      {
        Label_NumberElements.Content += "after max = " + linkedList1.ElementAt(maxElementIndex + 1).ToString() + "\n";
      }
      else
      {
        Label_NumberElements.Content += "Not found element after max element\n";
      }
    }
    private void button_PrintData(object sender, RoutedEventArgs e)
    {
      PrintStruct(linkedList1, textBox_PrintStruct);
      //PrintStruct(linkedList2, textBox_Result);
      Label_NumberElements.Content = null;
      Label_NumberElements.Content += "Number elements = " + linkedList1.GetNumberElements().ToString() + "\t";
      Label_NumberElements.Content += "min = " + linkedList1.MinElement().ToString() + "\t";
      Label_NumberElements.Content += "max = " + linkedList1.MaxElement().ToString() + "\n";

      Label_NumberElements.Content += "3 from start = " + linkedList1.ElementAt(2).ToString() + "\t";
      Label_NumberElements.Content += "2 from end = " + linkedList1.ElementAt(
        linkedList1.GetNumberElements() - 2).ToString() + "\n";// 2 - 2 елемент з кінця

      PrintBeforeMinAndAfterMax();
    }
    private void button_SerchingElement(object sender, RoutedEventArgs e)
    {
      if (int.TryParse(textBox_SearchElement.Text, out int user))
      {
        int index = linkedList1.IndexOf(user);
        if (index >= 0)
        {
          Label_NumberElements.Content += "index searching = " + (index + 1).ToString() + "\t";
        }
        else
        {
          MessageBox.Show("Element not found.");
        }
      }
      else
      {
        MessageBox.Show("Please, check entered element");
      }
    }
    //private void button_AddStruct(object sender, RoutedEventArgs e)
    //{
    //  linkedList3 = linkedList1.Concat(linkedList2);
    //  PrintStruct(linkedList3, textBox_Result);
    //}
    private void button_Exit(object sender, RoutedEventArgs e)
    {
      Environment.Exit(0);
    }
  }
}