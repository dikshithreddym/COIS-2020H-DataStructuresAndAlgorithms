
using System;
using System.Collections.Generic;


namespace PE1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList myList1 = new LinkedList();
            LinkedList myList2 = new LinkedList();

            //Testing AddFirst()
            myList1.AddFirst("first");
            myList1.AddFirst("second");
            myList1.AddFirst("third");

            Console.WriteLine("the content of myList1:");
            myList1.printAllNodes();

            //Testing AddLast()
            myList2.AddLast("4th");
            myList2.AddLast("5th");
            myList2.AddLast("6th");

            Console.WriteLine();
            Console.WriteLine("the content of myList2:");
            myList2.printAllNodes();

            //Testing DeleteNode()
            myList1.DeleteNode("first");
            myList1.DeleteNode("second");
            myList1.DeleteNode("third");

            Console.WriteLine();
            Console.WriteLine("After deletion: the content of myList1:");
            myList1.printAllNodes();

            myList1.AddFirst("Seventh");
            myList1.AddFirst("Eighth");
            myList1.AddFirst("Ninth");

            Console.WriteLine();
            Console.WriteLine("After adding three new nodes: the content of myList1:");
            myList1.printAllNodes();

            //Testing Merge()
            myList1.Merge(myList2);

            Console.WriteLine();
            Console.WriteLine("After merging lists: the content of myList1:");
            myList1.printAllNodes();

            Console.WriteLine();
            Console.WriteLine("After merging lists: the content of myList2:");
            myList2.printAllNodes();

            //Testing DeleteLast()
            myList1.DeleteLast();
            myList1.DeleteLast();
            myList1.DeleteLast();

            Console.WriteLine();
            Console.WriteLine("After 3 DeleteLast() calls: the content of myList1:");
            myList1.printAllNodes();

            //Testing Deletefirst()
            myList2.DeleteFirst();
            myList2.DeleteFirst();
            myList2.DeleteFirst();

            Console.WriteLine();
            Console.WriteLine("After 3 DeleteFirst() calls: the content of myList2:");
            myList2.printAllNodes();

            Console.ReadLine();
        } // Main } 
    }//class

    public class Node
    {
        public Node next;
        public Object data;
    }
    public class LinkedList
    {
        private Node head;
        public void printAllNodes()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }

        //the following method adds a node at the beginning of the list

        public void AddFirst(Object data)
        {
			/*[HINT]
				make a new node using data
				point the new node.next to head 
				set head to new node 
			*/
            Node toAdd = new Node();
            //TO BE COMPLETED...................................................1
        }

        //the following methodadds a node at the end of the list
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
                //TO BE COMPLETED...................................................2
            }
        }

        //the following method deletes the first node in the list
        public void DeleteFirst()
        {
            //TO BE COMPLETED...................................................3
        }
		
		//the following delete the last node in the list

        public void DeleteLast()
        {
            Node current = head;
            //TO BE COMPLETED...................................................4
			
			//[HINT] traverse the list until the last element and then delete it
        }


        //the following method deletes one node from the list
        //The node to be deleted is the one that has data equals to the parameter "data"
        public void DeleteNode(Object data)
        {
            //TO BE COMPLETED...................................................5

            //[HINT] Make sure that the list is not empty

        }

        //the following merges this list with the parameter "dl2"
        //Where dl2 is appended to te end of this list
        public void Merge(LinkedList dl2)
        {
            //TO BE COMPLETED...................................................6
        }
    }
}

