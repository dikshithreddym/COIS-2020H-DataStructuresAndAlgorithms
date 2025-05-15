using System;
using System.Text;

public class ArrayList<T>
{
    private T[] array;
    private int count;

    public ArrayList()
    {
        array = new T[4];
        count = 0;
    }

    private void Grow()
    {
        int newSize = array.Length * 2;
        T[] newArray = new T[newSize];
        Array.Copy(array, newArray, count);
        array = newArray;
    }

    public void AddFront(T item)
    {
        if (count == array.Length)
        {
            Grow();
        }
        Array.Copy(array, 0, array, 1, count);
        array[0] = item;
        count++;
    }

    public void AddLast(T item)
    {
        if (count == array.Length)
        {
            Grow();
        }
        array[count] = item;
        count++;
    }

    public int GetCount()
    {
        return count;
    }

    public void InsertBefore(T newItem, T existingItem)
    {
        int index = Array.IndexOf(array, existingItem);
        if (index == -1)
        {
            throw new ArgumentException("Existing item not found in the list");
        }
        if (count == array.Length)
        {
            Grow();
        }
        Array.Copy(array, index, array, index + 1, count - index);
        array[index] = newItem;
        count++;
    }

    public void InPlaceSort()
    {
        Array.Sort(array, 0, count);
    }

    public void Swap(int index1, int index2)
    {
        if (index1 < 0 || index1 >= count || index2 < 0 || index2 >= count)
        {
            throw new IndexOutOfRangeException("Index out of range");
        }
        T temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }

    public void DeleteFirst()
    {
        if (count == 0)
        {
            throw new InvalidOperationException("List is empty");
        }
        Array.Copy(array, 1, array, 0, count - 1);
        count--;
    }

    public void DeleteLast()
    {
        if (count == 0)
        {
            throw new InvalidOperationException("List is empty");
        }
        count--;
    }

    public void RotateLeft()
    {
        if (count < 2)
        {
            return;
        }
        T temp = array[0];
        Array.Copy(array, 1, array, 0, count - 1);
        array[count - 1] = temp;
    }

    public void RotateRight()
    {
        if (count < 2)
        {
            return;
        }
        T temp = array[count - 1];
        Array.Copy(array, 0, array, 1, count - 1);
        array[0] = temp;
    }

    public static ArrayList<T> Merge(ArrayList<T> list1, ArrayList<T> list2)
    {
        ArrayList<T> mergedList = new ArrayList<T>();
        for (int i = 0; i < list1.GetCount(); i++)
        {
            mergedList.AddLast(list1[i]);
        }
        for (int i = 0; i < list2.GetCount(); i++)
        {
            mergedList.AddLast(list2[i]);
        }
        return mergedList;
    }

    public string StringPrintAllForward()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++)
        {
            sb.Append(array[i].ToString()).Append(" ");
        }
        return sb.ToString();
    }

    public string StringPrintAllReverse()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = count - 1; i >= 0; i--)
        {
            sb.Append(array[i].ToString()).Append(" ");
        }
        return sb.ToString();
    }

    public void DeleteAll()
    {
        count = 0;
    }

    // Indexer to access elements by index
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            return array[index];
        }
        set
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            array[index] = value;
        }
    }
}
