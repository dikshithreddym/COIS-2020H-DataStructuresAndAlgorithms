// Required namespace for basic system functionalities.
using System;

// Namespace for our priority queue demo.
namespace PriorityQueueDemo
{
    // Main Program class.
    class Program
    {
        // Entry point of the program.
        static void Main(string[] args)
        {
            // Instantiate a new PriorityQueue with a capacity for 10 patients.
            PriorityQueue<Patient> queue = new PriorityQueue<Patient>(10);

            // Running flag for our menu loop.
            bool running = true;
            while (running)
            {
                // Display the user menu.
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1: Add a patient");
                Console.WriteLine("2: Remove one patient");
                Console.WriteLine("3: Print information of all patients");
                Console.WriteLine("4: Delete all patients");
                Console.WriteLine("0: Exit");
                Console.Write("Select an option: ");

                // Read and parse the user's menu choice.
                int choice = Convert.ToInt32(Console.ReadLine());

                // Process the user's menu choice.
                switch (choice)
                {
                    case 1:
                        AddPatient(queue); // Add a new patient.
                        break;
                    case 2:
                        // Remove and print the next patient.
                        Patient patient = queue.Dequeue();
                        if (patient != null)
                        {
                            Console.WriteLine("Removed patient: " + patient.ToString());
                        }
                        break;
                    case 3:
                        queue.PrintAll(); // Print all patients.
                        break;
                    case 4:
                        queue.DeleteAll(); // Delete all patients.
                        break;
                    case 0:
                        running = false; // Exit the program.
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again."); // Handle invalid inputs.
                        break;
                }
            }

            Console.WriteLine("Exiting program..."); // Program exit confirmation.
        }

        // Method for adding a new patient.
        static void AddPatient(PriorityQueue<Patient> queue)
        {
            // Request and read patient information from the user.
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            // Generate a random emergency level for the new patient.
            Random rnd = new Random();
            int emergencyLevel = rnd.Next(1, 11); // Emergency level between 1 and 10.

            // Create a new patient object and add it to the queue.
            Patient newPatient = new Patient(firstName, lastName, age, emergencyLevel);
            queue.Enqueue(newPatient, emergencyLevel);

            // Confirm addition of the new patient.
            Console.WriteLine("Added patient: " + newPatient.ToString());
        }
    }

    // Defines a class to represent patient information.
    public class Patient
    {
        // Properties to hold patient details.
        public string FirstName { get; set; } // Patient's first name.
        public string LastName { get; set; } // Patient's last name.
        public int Age { get; set; } // Patient's age.
        public int EmergencyLevel { get; set; } // Patient's emergency level, determining their priority in the queue.

        // Constructor to initialize a new patient with given details.
        public Patient(string firstName, string lastName, int age, int emergencyLevel)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            EmergencyLevel = emergencyLevel;
        }

        // Overrides the ToString method to return patient information in a readable format.
        public override string ToString()
        {
            return $"{FirstName} {LastName}, Age: {Age}, Emergency Level: {EmergencyLevel}";
        }
    }

    // A generic priority queue class, where T is constrained to be of type Patient or derived from Patient.
    public class PriorityQueue<T> where T : Patient
    {
        // Array to store elements of the queue.
        private Node<T>[] queue;
        // Index of the front element in the queue.
        private int front = -1;
        // Index of the rear element in the queue.
        private int rear = -1;
        // Maximum size of the queue.
        private int size;

        // Constructor to initialize the priority queue with a specific size.
        public PriorityQueue(int size)
        {
            this.size = size; // Sets the size of the queue.
            queue = new Node<T>[size]; // Initializes the array with the specified size.
        }

        // Adds an item to the queue based on its priority.
        public void Enqueue(T item, int priority)
        {
            // Check if the queue is full.
            if ((rear + 1) % size == front)
            {
                Console.WriteLine("Queue is full.");
                return;
            }

            // Create a new node for the item.
            Node<T> newNode = new Node<T>(item, priority);

            // If the queue is empty, add the first element.
            if (front == -1)
            {
                front = rear = 0;
            }
            else
            {
                // Find the correct position for the new node based on its priority.
                int i;
                for (i = rear; i != front; i = (i - 1 + size) % size)
                {
                    if (priority > queue[i].Priority)
                    {
                        // Shift elements to make room for the new node.
                        queue[(i + 1) % size] = queue[i];
                    }
                    else
                    {
                        break;
                    }
                }
                // Insert the new node in the queue.
                queue[(i + 1) % size] = newNode;
                rear = (rear + 1) % size;
            }
        }

        // Removes and returns the item at the front of the queue.
        public T Dequeue()
        {
            // Check if the queue is empty.
            if (front == -1)
            {
                Console.WriteLine("Queue is empty.");
                return null;
            }

            // Retrieve the item at the front of the queue.
            T item = queue[front].Item;
            // If there is only one item, reset the queue to empty.
            if (front == rear)
            {
                front = rear = -1;
            }
            else
            {
                // Move the front pointer to the next element.
                front = (front + 1) % size;
            }
            return item;
        }

        // Prints all elements in the queue.
        public void PrintAll()
        {
            // Check if the queue is empty.
            if (front == -1)
            {
                Console.WriteLine("Queue is empty.");
                return;
            }

            // Loop through the queue and print each element.
            int i = front;
            while (i != rear)
            {
                Console.WriteLine(queue[i].Item.ToString());
                i = (i + 1) % size;
            }
            // Print the last element.
            Console.WriteLine(queue[i].Item.ToString());
        }

        // Deletes all elements in the queue.
        public void DeleteAll()
        {
            front = rear = -1; // Reset the indices to indicate an empty queue.
            Console.WriteLine("All patients have been deleted from the queue.");
        }
    }

    public class Node<T>
        where T : Patient
    {
        public T Item { get; set; } // The item stored in this node.
        public int Priority { get; set; } // The priority of the item.

        // Constructor to initialize the node with an item and its priority.
        public Node(T item, int priority)
        {
            Item = item;
            Priority = priority;
        }
    }
}
