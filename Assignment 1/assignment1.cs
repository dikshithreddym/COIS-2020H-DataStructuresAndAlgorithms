public class Position {
    private double x, y, z;

    // Constructor to initialize the position
    public Position(double x, double y, double z) {
        X = x; // Automatically clamps values within +/- 15.0
        Y = y;
        Z = z;
    }

    // Properties for X, Y, and Z with validation
    public double X {
        get => x;
        set => x = Math.Clamp(value, -15.0, 15.0);
    }

    public double Y {
        get => y;
        set => y = Math.Clamp(value, -15.0, 15.0);
    }

    public double Z {
        get => z;
        set => z = Math.Clamp(value, -15.0, 15.0);
    }

    // Method to move the position, clamps to +/- 15.0
    public void Move(double dx, double dy, double dz) {
        X += dx;
        Y += dy;
        Z += dz;
    }

    // Optional: Override ToString for easy debugging/printing
    public override string ToString() {
        return $"Position: ({X}, {Y}, {Z})";
    }
}

public abstract class Animal {
    public int ID { get; set; }
    public string Name { get; set; }
    public double Age { get; set; }
    public Position Pos { get; set; }

    // Constructor for initializing an Animal object
    public Animal(int id, string name, double age, Position pos) {
        ID = id;
        Name = name;
        Age = age;
        Pos = pos;
    }

    // Method to move the animal
    public void Move(double dx, double dy, double dz) {
        Pos.Move(dx, dy, dz); // Delegates the move logic to the Position object
    }

    // Override ToString to provide a string representation of the animal's state
    public override string ToString() {
        return $"ID: {ID}, Name: {Name}, Age: {Age}, Position: {Pos}";
    }
}

public class Cat : Animal {
    public enum Breed { Abyssinian, BritishShorthair, Bengal, Himalayan, Ocicat, Serval }

    public Breed CatBreed { get; set; }

    // Constructor for initializing a Cat object
    public Cat(int id, string name, double age, Position pos, Breed catBreed)
        : base(id, name, age, pos) {
        CatBreed = catBreed;
    }

    // Override ToString to include breed information
    public override string ToString() {
        return base.ToString() + $", Breed: {CatBreed}";
    }
}

public class Snake : Animal {
    public double Length { get; set; }
    public bool Venomous { get; set; }

    // Constructor for initializing a Snake object
    public Snake(int id, string name, double age, Position pos, double length, bool venomous)
        : base(id, name, age, pos) {
        Length = length;
        Venomous = venomous;
    }

    // Override ToString to include length and venomous information
    public override string ToString() {
        return base.ToString() + $", Length: {Length}, Venomous: {Venomous}";
    }
}

static void Main(string[] args) {
    var rand = new Random();

    // Assuming methods GetUniqueNamesFromFile(filePath, count) and ShuffleList(list, rand)
    // These methods should read names from a file, ensuring uniqueness and randomness
    var catNames = GetUniqueNamesFromFile("catnames.txt", 3);
    var snakeNames = GetUniqueNamesFromFile("snakenames.txt", 3);

    var animals = new List<Animal>();

    // Create and add cats to the animals list
    for (int i = 0; i < 3; i++) {
        animals.Add(new Cat(
            i,
            catNames[i],
            rand.Next(1, 15), // Random age between 1 and 15
            new Position(rand.NextDouble() * 30 - 15, rand.NextDouble() * 30 - 15, rand.NextDouble() * 30 - 15),
            (Cat.Breed)rand.Next(Enum.GetNames(typeof(Cat.Breed)).Length)
        ));
    }

    // Create and add snakes to the animals list
    for (int i = 0; i < 3; i++) {
        animals.Add(new Snake(
            i + 3,
            snakeNames[i],
            rand.Next(1, 15), // Random age between 1 and 15
            new Position(rand.NextDouble() * 30 - 15, rand.NextDouble() * 30 - 15, rand.NextDouble() * 30 - 15),
            rand.NextDouble() * 2 + 1, // Random length between 1 and 3
            rand.Next(2) == 0 // Randomly venomous or not
        ));
    }

    // Demonstrating storing and printing using an ArrayList and a generic List
    Animal[] animalArray = animals.ToArray();
    List<Animal> animalList = animals.ToList();

    // Print initial states
    foreach (var animal in animalList) Console.WriteLine(animal);

    // Move each animal by a random dx, dy, dz
    foreach (var animal in animals) {
        double dx = rand.NextDouble() * 4 - 2;
        double dy = rand.NextDouble() * 4 - 2;
        double dz = rand.NextDouble() * 4 - 2;
        animal.Move(dx, dy, dz);
    }

    Console.WriteLine("\nAfter moving:");
    // Print updated states
    foreach (var animal in animalArray) Console.WriteLine(animal);
}