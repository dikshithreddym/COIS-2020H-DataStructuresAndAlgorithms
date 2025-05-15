using System;
using System.Text;

public class DoublyLinkedList<T>
{
    private class Node
    {
        public T Data { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }

    private Node head;
    private Node tail;
    private int count;

    public DoublyLinkedList()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public void AddFront(T data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Prev = newNode;
            head = newNode;
        }
        count++;
    }

    public void AddLast(T data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }
        count++;
    }

    public int GetCount()
    {
        return count;
    }

    public void InsertAtRandomLocation(T data)
    {
        if (count == 0)
        {
            AddFront(data);
            return;
        }

        Random rand = new Random();
        int index = rand.Next(count);

        Node current = head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }

        Node newNode = new Node(data);
        newNode.Next = current;
        newNode.Prev = current.Prev;
        if (current.Prev != null)
        {
            current.Prev.Next = newNode;
        }
        else
        {
            head = newNode;
        }
        current.Prev = newNode;
        count++;
    }

    public void Merge(DoublyLinkedList<T> otherList)
    {
        if (otherList == null || otherList.head == null)
        {
            return;
        }

        if (head == null)
        {
            head = otherList.head;
            tail = otherList.tail;
        }
        else
        {
            tail.Next = otherList.head;
            otherList.head.Prev = tail;
            tail = otherList.tail;
        }
        count += otherList.count;
    }

    public T FindClosest(T data)
    {
        // Implement method to find closest node to given data
        return default(T); // Placeholder
    }

    public double FindDistance(T pos, T data)
    {
        // Implement method to find distance between two data points
        return 0.0; // Placeholder
    }

    public void DeleteFirst()
    {
        if (head != null)
        {
            head = head.Next;
            if (head == null)
            {
                tail = null;
            }
            else
            {
                head.Prev = null;
            }
            count--;
        }
    }

    public void DeleteLast()
    {
        if (tail != null)
        {
            tail = tail.Prev;
            if (tail == null)
            {
                head = null;
            }
            else
            {
                tail.Next = null;
            }
            count--;
        }
    }

    public void GetEaten(T target)
    {
        // Implement method to remove the target from the list
        // Print which bird was eaten
    }

    public void RotateLeft()
    {
        if (head != null && head != tail)
        {
            Node temp = head;
            head = head.Next;
            tail.Next = temp;
            temp.Prev = tail;
            temp.Next = null;
            head.Prev = null;
            tail = temp;
        }
    }

    public void RotateRight()
    {
        if (tail != null && head != tail)
        {
            Node temp = tail;
            tail = tail.Prev;
            head.Prev = temp;
            temp.Next = head;
            temp.Prev = null;
            tail.Next = null;
            head = temp;
        }
    }

    public string StringPrintAllForward()
    {
        StringBuilder builder = new StringBuilder();
        Node current = head;
        while (current != null)
        {
            builder.Append(current.Data.ToString()).Append(" ");
            current = current.Next;
        }
        return builder.ToString();
    }

    public string StringPrintAllReverse()
    {
        StringBuilder builder = new StringBuilder();
        Node current = tail;
        while (current != null)
        {
            builder.Append(current.Data.ToString()).Append(" ");
            current = current.Prev;
        }
        return builder.ToString();
    }

    public void DeleteAll()
    {
        head = null;
        tail = null;
        count = 0;
    }
}
