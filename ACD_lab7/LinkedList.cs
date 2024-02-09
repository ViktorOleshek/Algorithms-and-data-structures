using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ACD_lab7
{
  public class LinkedList<T> where T : IComparable<T>
  {
    public Node<T> Head
    {
      get; private set;
    }
    public void AddElement(T data)
    {
      Node<T> newNode = new Node<T>(data);
      if (Head == null)
      {
        Head = newNode;
      }
      else
      {
        Node<T> current = Head;
        while (current.Next != null)
        {
          current = current.Next;
        }
        current.Next = newNode;
      }
    }
    public void Clear()
    {
      while (Head != null)
      {
        Node<T> tmp = Head;
        Head = Head.Next;
        tmp = null;
      }
    }
    /// <summary>
    /// вертає значення максимального елемента
    /// </summary>
    public T MaxElement()
    {
      var maxValue = Head.Data;
      Node<T> current = Head;
      while (current != null)
      {
        if (current.Data.CompareTo(maxValue) > 0)
          maxValue = current.Data;
        current = current.Next;
      }

      return maxValue;
    }
    /// <summary>
    /// вертає значення мінімального елемента
    /// </summary>
    public T MinElement()
    {
      var minValue = Head.Data;
      Node<T> current = Head;
      while (current != null)
      {
        if (current.Data.CompareTo(minValue) < 0)
          minValue = current.Data;
        current = current.Next;
      }

      return minValue;
    }
    public int GetNumberElements()
    {
      int number = 0;
      Node<T> current = Head;
      while (current != null)
      {
        number++;
        current = current.Next;
      }
      return number;
    }
    /// <summary>
    /// вертає елемент за індексом
    /// </summary>
    public T ElementAt(int index)
    {
      if (index < 0)
      {
        MessageBox.Show("Out of range");
        return default(T);
      }

      int i = 0;
      Node<T> current = Head;

      while (i != index)
      {
        if (current == null)
        {
          MessageBox.Show("Out of range");
          return default(T);
        }
        i++;
        current = current.Next;
      }

      if (current == null)
      {
        MessageBox.Show("Out of range");
        return default(T);
      }

      return current.Data;
    }
    /// <summary>
    /// індекс за значенням елемента
    /// </summary>
    public int IndexOf(T data)
    {
      int i = 0;
      Node<T> current = Head;

      while (current != null)
      {
        if (current.Data.CompareTo(data) == 0)
        {
          return i;
        }
        i++;
        current = current.Next;
      }

      // data не знайдено в списку
      return -1;
    }

    public LinkedList<T> Concat(LinkedList<T> otherList)
    {
      LinkedList<T> result = new LinkedList<T>();

      Node<T> current = this.Head;

      while (current != null)
      {
        result.AddElement(current.Data);
        current = current.Next;
      }

      current = otherList.Head;
      while (current != null)
      {
        result.AddElement(current.Data);
        current = current.Next;
      }

      return result;
    }
  }
}
