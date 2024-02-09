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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ACD_lab8
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private BinarySearchTree<char> bst = new BinarySearchTree<char>();
    public MainWindow()
    {
      InitializeComponent();
    }

    private void button_CreateBinarySearchTree(object sender, RoutedEventArgs e)
    {
      string input = textBox_UsersEnter.Text;

      if (string.IsNullOrEmpty(input))
      {
        MessageBox.Show("Please, enter an element");
        return;
      }

      foreach (char c in input)
      {
        if (char.TryParse(c.ToString(), out char symbol))
        {
          bst.Add(symbol);
        }
        else
        {
          MessageBox.Show($"Invalid character: {c}");
          return;
        }
      }


      label_ResultCreated.Content = "Created successfully";
    }

    private void CheckUsersEnter(out char symbol, TextBox textbox)
    {
      if (string.IsNullOrEmpty(textbox.Text))
      {
        MessageBox.Show(messageBoxText: "Please, enter an element");
        symbol = '\0'; // Позначка, що дані недійсні
        return;
      }

      if (!char.TryParse(textbox.Text, out symbol))
      {
        MessageBox.Show("Invalid input. Please enter a single character.");
        symbol = '\0'; // Позначка, що дані недійсні
      }
    }
    private void button_Search(object sender, RoutedEventArgs e)
    {
      char symbol;
      CheckUsersEnter(out symbol, textBox_SearchElement);

      if (symbol == '\0') { return; }

      if (bst.Search(symbol))
      {
        MessageBox.Show($"Binary search tree contains {symbol}");
      }
      else
      {
        MessageBox.Show($"Binary search tree does not contain {symbol}");
      }
    }

    private void button_LengthToApex(object sender, RoutedEventArgs e)
    {
      char symbol;
      CheckUsersEnter(out symbol, textBox_Apex);
      if (symbol == '\0') { return; }

      int length = bst.LengthToApex(symbol);
      if (length > 0)
      {
        MessageBox.Show($"Length to apex {symbol} = {length}");
      }
      else
      {
        MessageBox.Show($"The apex {symbol} is not find");
      }
    }

    private void button_FindDadAndSon(object sender, RoutedEventArgs e)
    {
      char symbol;
      CheckUsersEnter(out symbol, textBox_FindDadAndSon);
      if (symbol == '\0') { return; }


      Node<char> dad, leftChild, rightChild;
      if (bst.GetDadAndSon(symbol, out dad, out leftChild, out rightChild))
      {
        MessageBox.Show(messageBoxText: $"For {symbol}:\n" +
            $"dad = {(dad != null ? dad.Data.ToString() : "Not Found")}\n" +
            $"left child = {(leftChild != null ? leftChild.Data.ToString() : "Not Found")}\n" +
            $"right child = {(rightChild != null ? rightChild.Data.ToString() : "Not Found")}");
      }
      else
      {
        MessageBox.Show(messageBoxText: $"Binary search tree does not contain {symbol}");
      }
    }

    private void button_MixedTraversal(object sender, RoutedEventArgs e)
    {
      var list = bst.MixedTraversal();
      textBox_MixedTraversal.Text = string.Join(", ", list);
    }

    private void button_Exit(object sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }
  }
}
