using System;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        // Create ArrayLists for Cats and Snakes
        var cats = new ArrayList<Animal>();
        var snakes = new ArrayList<Animal>();

        // Populate Cats ArrayList
        for (int i = 0; i < 3; i++)
        {
            var cat = new Cat();
            cat.GenerateRandomPosition(-25, 25); // Generate random position
            cats.AddFront(cat);
        }

        // Populate Snakes ArrayList
        for (int i = 0; i < 3; i++)
        {
            var snake = new Snake();
            snake.GenerateRandomPosition(-25, 25); // Generate random position
            snakes.AddLast(snake);
        }

        // Merge the two ArrayLists
        var mergedList = ArrayList<Animal>.Merge(cats, snakes);

        // Test PrintAllForward on the merged ArrayList
        Console.WriteLine("Merged ArrayList (Forward):");
        Console.WriteLine(mergedList.StringPrintAllForward());

        // Test PrintAllReverse on the merged ArrayList
        Console.WriteLine("\nMerged ArrayList (Reverse):");
        Console.WriteLine(mergedList.StringPrintAllReverse());

        // Create DoublyLinkedLists for the first 5 birds and the remaining 5 birds
        var firstFiveBirds = new DoublyLinkedList<Bird>();
        var remainingBirds = new DoublyLinkedList<Bird>();

        // Populate the first DoublyLinkedList with the first 5 birds
        string[] birdNames = { "Tweety", "Zazu", "Iago", "Hula", "Manu" };
        for (int i = 0; i < 5; i++)
        {
            var bird = new Bird(birdNames[i]);
            // Add bird to the front of the list
            firstFiveBirds.AddFront(bird);
        }

        // Populate the second DoublyLinkedList with the remaining 5 birds
        for (int i = 5; i < 10; i++)
        {
            var bird = new Bird(birdNames[i - 5]); // Using same bird names as the first 5
            // Add bird to the front of the list
            remainingBirds.AddFront(bird);
        }

        // Merge the second DoublyLinkedList onto the first one
        firstFiveBirds.Merge(remainingBirds);

        // Main loop
        int round = 1;
       while (mergedList.Count > 0)
{
    Console.WriteLine($"\nRound {round++}");

    // Each iteration over the animals, the Cat or Snake will eat Birds that are in range
    foreach (var cat in cats.ToList()) // ToList() creates a copy of cats to avoid InvalidOperationException
    {
        foreach (var bird in mergedList.ToList()) // ToList() creates a copy of mergedList to avoid InvalidOperationException
        {
            if (cat.IsInRange(bird))
            {
                Console.WriteLine($"Cat ate {bird}");
                mergedList.Remove(bird);
            }
        }
        // If there is nothing in range to eat, the cat moves towards the nearest bird
        var closestBird = mergedList.FindClosest(cat);
        if (closestBird != null)
        {
            cat.MoveTowards(closestBird, 16);
        }
    }

    foreach (var snake in snakes.ToList()) // ToList() creates a copy of snakes to avoid InvalidOperationException
    {
        foreach (var bird in mergedList.ToList()) // ToList() creates a copy of mergedList to avoid InvalidOperationException
        {
            if (snake.IsInRange(bird))
            {
                Console.WriteLine($"Snake ate {bird}");
                mergedList.Remove(bird);
            }
        }
        // If there is nothing in range to eat, the snake moves towards the nearest bird
        var closestBird = mergedList.FindClosest(snake);
        if (closestBird != null)
        {
            snake.MoveTowards(closestBird, 14);
        }
    }

    // Birds "that survive" will randomly move
    foreach (var bird in mergedList)
    {
        bird.MoveRandomly();
    }
}


            // After every fifth iteration, PrintAllForward
            if (round % 5 == 0)
            {
                Console.WriteLine("\nMerged ArrayList (Forward):");
                Console.WriteLine(mergedList.StringPrintAllForward());
            }
        }

        Console.WriteLine("\nAll birds have been eaten.");
        Console.WriteLine($"Total rounds: {round - 1}");
    }
}
