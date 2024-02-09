using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACD_lab7
{
  public class Node<T> where T : IComparable<T>
  {
    public T Data
    {
      get; private set;
    }
    public Node<T> Next
    {
      get; internal set;
    }

    public Node(T data)
    {
      Data = data;
      Next = null;
    }
  }
}