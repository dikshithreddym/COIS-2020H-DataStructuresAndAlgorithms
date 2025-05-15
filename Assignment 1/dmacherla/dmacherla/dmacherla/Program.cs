using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace dmacherla
{
    internal class Program
    {
        static void Main()
        {
            // Assuming you have methods to read names from files: ReadCatNames(), ReadSnakeNames()
            List<string> catNames = ReadCatNames(); // Implement this
            List<string> snakeNames = ReadSnakeNames(); // Implement this

            var animals = new List<Animal>();
            var rand = new Random();

            // Generate 3 cats
            for (int i = 0; i < 3; i++)
            {
                animals.Add(new Cat(i, catNames[i], rand.NextDouble() * 15, new Position(rand.NextDouble() * 30 - 15, rand.NextDouble() * 30 - 15, rand.NextDouble() * 30 - 15), (Cat.Breed)rand.Next(6)));
            }

            // Generate 3 snakes
            for (int i = 3; i < 6; i++)
            {
                animals.Add(new Snake(i, snakeNames[i - 3], rand.NextDouble() * 15, new Position(rand.NextDouble() * 30 - 15, rand.NextDouble() * 30 - 15, rand.NextDouble() * 30 - 15), rand.NextDouble() * 10, rand.Next(2) == 0));
            }

            // Use an array or list to store and manage these objects as required
            Animal[] animalArray = animals.ToArray();
            List<Animal> animalList = new List<Animal>(animals);

            // Traverse and print properties
            foreach (var animal in animalArray)
            {
                Console.WriteLine(animal);
            }

            // Move all animals
            foreach (var animal in animalList)
            {
                double dx = rand.NextDouble() * 4 - 2;
                double dy = rand.NextDouble() * 4 - 2;
                double dz = rand.NextDouble() * 4 - 2;
                animal.Move(dx, dy, dz);
            }

            // Print off all objects and positions again
            foreach (var animal in animalList)
            {
                Console.WriteLine(animal);
            }


        }

        private static List<string> ReadCatNames()
        {
            string filePath = @"C:\Users\diksh\Desktop\COIS 2020H\Assignment 1\catnames.txt"; // the path to where file is located
            try
            {
                var lines = File.ReadAllLines(filePath);
                return new List<string>(lines);
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the cat names file: " + e.Message);
                return new List<string>(); // Return an empty list in case of error
            }
        }

        private static List<string> ReadSnakeNames()
        {
            string filePath = @"C:\Users\diksh\Desktop\COIS 2020H\Assignment 1\snakenames.txt"; // the path to where file is located
            try
            {
                var lines = File.ReadAllLines(filePath);
                return new List<string>(lines);
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the snake names file: " + e.Message);
                return new List<string>(); // Return an empty list in case of error
            }
        }

        public class Position
        {
            private double x, y, z;

            public Position(double x, double y, double z)
            {
                SetX(x);
                SetY(y);
                SetZ(z);
            }

            public double X { get => x; set => SetX(value); }
            public double Y { get => y; set => SetY(value); }
            public double Z { get => z; set => SetZ(value); }

            private void SetX(double value) => x = Clamp(value);
            private void SetY(double value) => y = Clamp(value);
            private void SetZ(double value) => z = Clamp(value);

            private double Clamp(double value) => Math.Max(-15.0, Math.Min(15.0, value));

            public void Move(double dx, double dy, double dz)
            {
                X += dx;
                Y += dy;
                Z += dz;
            }

            public override string ToString() => $"Position: ({X}, {Y}, {Z})";
        }

        public class Animal
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public double Age { get; set; }
            public Position Pos { get; set; }

            public Animal(int id, string name, double age, Position pos)
            {
                ID = id;
                Name = name;
                Age = age;
                Pos = pos;
            }

            public void Move(double dx, double dy, double dz) => Pos.Move(dx, dy, dz);

            public override string ToString() => $"ID: {ID}, Name: {Name}, Age: {Age}, Position: {Pos}";
        }

        public class Cat : Animal
        {
            public enum Breed { Abyssinian, BritishShorthair, Bengal, Himalayan, Ocicat, Serval }
            public Breed CatBreed { get; set; }

            public Cat(int id, string name, double age, Position pos, Breed breed)
                : base(id, name, age, pos) => CatBreed = breed;

            public override string ToString() => $"{base.ToString()}, Breed: {CatBreed}";
        }

        public class Snake : Animal
        {
            public double Length { get; set; }
            public bool Venomous { get; set; }

            public Snake(int id, string name, double age, Position pos, double length, bool venomous)
                : base(id, name, age, pos)
            {
                Length = length;
                Venomous = venomous;
            }

            public override string ToString() => $"{base.ToString()}, Length: {Length}, Venomous: {Venomous}";
        }

    }
}
