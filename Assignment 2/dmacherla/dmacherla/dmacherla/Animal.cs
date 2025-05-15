using System;
using System.Collections.Generic;

public abstract class Animal
{
    protected int X { get; set; }
    protected int Y { get; set; }

    public abstract void GenerateRandomPosition(int minX, int maxX);
    public abstract bool IsInRange(Animal other);
    public abstract void MoveTowards(Animal other, int distance);
    public abstract void MoveRandomly();
}

public class Cat : Animal
{
    public override void GenerateRandomPosition(int minX, int maxX)
    {
        Random rand = new Random();
        X = rand.Next(minX, maxX);
        Y = rand.Next(minX, maxX);
    }

    public override bool IsInRange(Animal other)
    {
        // Implement your range logic here
        return false;
    }

    public override void MoveTowards(Animal other, int distance)
    {
        // Implement move towards logic here
    }

    public override void MoveRandomly()
    {
        // Implement random movement logic here
    }
}

public class Snake : Animal
{
    public override void GenerateRandomPosition(int minX, int maxX)
    {
        Random rand = new Random();
        X = rand.Next(minX, maxX);
        Y = rand.Next(minX, maxX);
    }

    public override bool IsInRange(Animal other)
    {
        // Implement your range logic here
        return false;
    }

    public override void MoveTowards(Animal other, int distance)
    {
        // Implement move towards logic here
    }

    public override void MoveRandomly()
    {
        // Implement random movement logic here
    }
}

public class Bird : Animal
{
    public string Name { get; }

    public Bird(string name)
    {
        Name = name;
    }

    public override void GenerateRandomPosition(int minX, int maxX)
    {
        Random rand = new Random();
        X = rand.Next(minX, maxX);
        Y = rand.Next(minX, maxX);
    }

    public override bool IsInRange(Animal other)
    {
        // Implement your range logic here
        return false;
    }

    public override void MoveTowards(Animal other, int distance)
    {
        // Implement move towards logic here
    }

    public override void MoveRandomly()
    {
        // Implement random movement logic here
    }

    public override string ToString()
    {
        return Name;
    }
}
