using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ACD_lab8
{
  public class Node<T> where T : IComparable<T>
  {
    public T Data
    {
      get; private set;
    }
    public Node<T> Left
    {
      get; private set;
    }
    public Node<T> Right
    {
      get; private set;
    }

    public Node(T data)
    {
      Data = data;
      Left = null;
      Right = null;
    }

    public bool Add(T data)
    {
      var node = new Node<T>(data);
      int comparison = node.Data.CompareTo(Data);

      if (comparison == 0)
      {
        return false;
      }
      else if (comparison < 0)
      {
        if (Left == null)
        {
          Left = node;
        }
        else
        {
          Left.Add(data);
        }
      }
      else
      {
        if (Right == null)
        {
          Right = node;
        }
        else
        {
          Right.Add(data);
        }
      }

      return true;
    }
    public bool Search(T data)
    {
      int comparison = data.CompareTo(Data);

      if (comparison == 0)
      {
        return true;
      }

      else if (comparison < 0)
      {
        if (Left != null)
        {
          return Left.Search(data);
        }
        else { return false; }
      }

      else // comparison > 0
      {
        if (Right != null)
        {
          return Right.Search(data);
        }
        else { return false; }
      }
    }
    public void Search(T data, ref int count)
    {
      int comparison = data.CompareTo(Data);

      if (comparison == 0) { return; }

      else if (comparison < 0)
      {
        if (Left != null)
        {
          Left.Search(data, ref count);
          count++;
        }
        else { return; }
      }

      else // comparison > 0
      {
        if (Right != null)
        {
          Right.Search(data, ref count);
          count++;
        }
        else { return; }
      }
    }
    public bool Search(T data, ref Node<T> dad, ref Node<T> leftChild, ref Node<T> rightChild)
    {
      int comparison = data.CompareTo(Data);

      if (comparison == 0)
      {
        leftChild = Left;
        rightChild = Right;
        return true;
      }

      else if (comparison < 0)
      {
        if (Left != null)
        {
          dad = this;
          return Left.Search(data, ref dad, ref leftChild, ref rightChild);
        }
        else
        {
          return false;
        }
      }

      else // comparison > 0
      {
        if (Right != null)
        {
          dad = this;
          return Right.Search(data, ref dad, ref leftChild, ref rightChild);
        }
        else
        {
          return false;
        }
      }
    }

    public bool Remove(T data)
    {
      return true;
    }
  }
}
