using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media.Media3D;

namespace ACD_lab8
{
  public class BinarySearchTree<T> where T : IComparable<T>
  {
    public Node<T> Root
    {
      get; private set;
    }
    public int Count
    {
      get; private set;
    }

    public void Add(T data)
    {
      if (Root == null)
      {
        Root = new Node<T>(data);
        Count = 1;
        return;
      }

      if (Root.Add(data)) { Count++; }
    }
    public bool Search(T data)
    {
      return Root.Search(data);
    }
    /// <summary>
    /// довжина до вершини
    /// </summary>
    public int LengthToApex(T data)
    {
      int count = 0;
      Root.Search(data, ref count);
      return count;
    }
    public bool GetDadAndSon(T data, out Node<T> dad, out Node<T> leftChild, out Node<T> rightChild)
    {
      dad = null; // Спочатку не маємо батька
      leftChild = null;
      rightChild = null;
      return Root.Search(data, ref dad, ref leftChild, ref rightChild);
    }
    public List<T> MixedTraversal()
    {
      if (Root == null)
      {
        return new List<T>();
      }

      return MixedTraversal(Root);
    }
    private List<T> MixedTraversal(Node<T> node)
    {
      var list = new List<T>();
      if (node != null)
      {
        if (node.Left != null) { list.AddRange(MixedTraversal(node.Left)); }

        list.Add(node.Data);

        if (node.Right != null) { list.AddRange(MixedTraversal(node.Right)); }
      }

      return list;
    }

  }
}
