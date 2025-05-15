using System;

namespace PE2_Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList myList1 = new LinkedList();
            LinkedList myList2 = new LinkedList();

            //Testing AddFirstUsingTail()
            myList1.AddFirstUsingTail("first");
            myList1.AddFirstUsingTail("second");
            myList1.AddFirstUsingTail("third");

            Console.WriteLine("After three calls to AddFirstUsingTail, the content of myList1:");
            myList1.printAllNodes();

            //Testing AddLastUsingTail()
            myList2.AddLastUsingTail("4th");
            myList2.AddLastUsingTail("5th");
            myList2.AddLastUsingTail("6th");

            Console.WriteLine();
            Console.WriteLine("After three calls to AddLastUsingTail, the content of myList2:");
            myList2.printAllNodes();

            myList2.DeleteLastUsingTail();

            Console.WriteLine();
            Console.WriteLine("After deleting last: the content of myList2:");
            myList2.printAllNodes();

            myList2.DeleteLastUsingTail();

            Console.WriteLine();
            Console.WriteLine("After deleting last one more time: the content of myList2:");
            myList2.printAllNodes();

            //Testing Merge()
            myList1.MergeUsingHeadAndTail(myList2);

            Console.WriteLine();
            Console.WriteLine("After merging lists: the content of myList1:");
            myList1.printAllNodes();

            Console.WriteLine();
            Console.WriteLine("After merging lists: the content of myList2:");
            myList2.printAllNodes();
            Console.ReadLine();
        }
    }

    public class Node
    {
        public Node next;
        public Node prev;
        public Object data;
    }

    public class LinkedList
    {
        private Node head;
        private Node tail;

        public void AddFirstUsingTail(Object data)
        {
            Node toAdd = new Node { data = data };
            if (tail == null)
            {
                head = tail = toAdd;
            }
            else
            {
                toAdd.next = tail;
                while (toAdd.next.prev != null)
                {
                    toAdd.next = toAdd.next.prev;
                }
                toAdd.next.prev = toAdd;
                head = toAdd;
            }
        }

        public void AddLastUsingTail(Object data)
        {
            Node toAdd = new Node { data = data };
            if (tail == null)
            {
                head = tail = toAdd;
            }
            else
            {
                tail.next = toAdd;
                toAdd.prev = tail;
                tail = toAdd;
            }
        }

        public void DeleteLastUsingTail()
        {
            if (tail != null)
            {
                if (tail.prev != null)
                {
                    tail = tail.prev;
                    tail.next = null;
                }
                else
                {
                    head = tail = null;
                }
            }
        }

        public void MergeUsingHeadAndTail(LinkedList dl2)
        {
            if (head == null)
            {
                head = dl2.head;
                tail = dl2.tail;
            }
            else if (dl2.head != null)
            {
                tail.next = dl2.head;
                dl2.head.prev = tail;
                tail = dl2.tail;
            }
        }

        public Object Head { get { return head.data; } }
        public void AddFirst(Object data)
        {
            Node toAdd = new Node();
            toAdd.data = data;
            toAdd.next = head;
            head = toAdd;
        }

        public void AddLast(Object data)
        {
            if (head == null)
            {
                head = new Node();
                head.data = data;
                head.next = null;
            }
            else
            {
                Node toAdd = new Node();
                toAdd.data = data;
                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = toAdd;
            }
        }
        public void DeleteLast()
        {
            Node current = head;
            if (head != null)
            {
                if (head.next == null)
                {
                    head = null;
                }
                else
                {
                    while (current.next.next != null)
                    {
                        current = current.next;
                    }
                    current.next = null;
                }
            }
        }

        public void DeleteFirst()
        {
            if (head != null)
            {
                head = head.next;
                if (head != null)
                {
                    head.prev = null;
                }
            }
        }

        public void DeleteNode(Object data)
        {
            if (head != null)
            {
                if (head.data == data)
                {
                    DeleteFirst();
                    return;
                }
                Node current = head;
                while (current.next != null)
                {
                    if (current.next.data.Equals(data))
                    {
                        if (current.next.next == null)
                        {
                            DeleteLast();
                            return;
                        }
                        else
                        {
                            current.next = current.next.next;
                            current.next.prev = current;
                            return;
                        }
                    }
                    current = current.next;
                }
            }
            else
            {
                Console.WriteLine("The list is empty");
            }
        }

        public void Merge(LinkedList dl2)
        {
            if (head == null)
            {
                head = dl2.head;
            }
            else
            {
                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = dl2.head;
                if (dl2.head != null)
                {
                    dl2.head.prev = current;
                }
            }
        }

        public void printAllNodes()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }
    }
}
