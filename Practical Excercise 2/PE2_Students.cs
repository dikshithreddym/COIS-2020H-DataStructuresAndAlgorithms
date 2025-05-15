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
        public Node prev; // Added as per REQUIREMENT 1
        public Object data;
    }

    public class LinkedList
    {
        private Node head;
        private Node tail; // Added as per REQUIREMENT 2

        public void AddFirstUsingTail(Object data) // REQUIREMENT 3 Implementation
        {
            Node toAdd = new Node { data = data };
            if (tail == null) // If list is empty
            {
                head = tail = toAdd;
            }
            else
            {
                toAdd.next = tail;
                while (toAdd.next.prev != null) // Traverse back to the head
                {
                    toAdd.next = toAdd.next.prev;
                }
                toAdd.next.prev = toAdd; // Set the current head's prev to the new node
                head = toAdd; // Update head to the new node
            }
        }

        public void AddLastUsingTail(Object data) // REQUIREMENT 4 Implementation
        {
            Node toAdd = new Node { data = data };
            if (tail == null) // If the list is empty
            {
                head = tail = toAdd;
            }
            else
            {
                tail.next = toAdd; // Set the current tail's next to the new node
                toAdd.prev = tail; // Set the new node's prev to the current tail
                tail = toAdd; // Update the tail to the new node
            }
        }

        public void DeleteLastUsingTail() // REQUIREMENT 5 Implementation
        {
            if (tail != null)
            {
                if (tail.prev != null) // If there's more than one element in the list
                {
                    tail = tail.prev; // Move tail back
                    tail.next = null; // Remove last node
                }
                else // If there's only one element in the list
                {
                    head = tail = null; // Empty the list
                }
            }
        }

        public void MergeUsingHeadAndTail(LinkedList dl2) // REQUIREMENT 6 Implementation
        {
            if (head == null) // If the first list is empty
            {
                head = dl2.head;
                tail = dl2.tail;
            }
            else if (dl2.head != null) // If the second list is not empty
            {
                tail.next = dl2.head; // Connect the two lists
                dl2.head.prev = tail; // Set the prev of the head of the second list
                tail = dl2.tail; // Update the tail to the end of the second list
            }
            // If both lists are empty or the second list is empty, do nothing
        }

        // Given methods remain unchanged
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
                    head = null; // Adjusted to fully remove the node
                }
                else
                {
                    while (current.next.next != null)
                    {
                        current = current.next;
                    }
                    current.next = null; // Properly remove the last node
                }
            }
        }

        public void DeleteFirst()
        {
            if (head != null)
            {
                head = head.next;
                if (head != null) // Added check to avoid null pointer exception
                {
                    head.prev = null; // Correctly setting the prev pointer of the new head
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
                            current.next.prev = current; // Adjusting the prev pointer
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
                if (dl2.head != null) // Additional check to avoid null pointer
                {
                    dl2.head.prev = current; // Correctly setting the prev pointer
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
