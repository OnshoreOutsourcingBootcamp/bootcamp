using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace DogHouse
{
    public class DogHouse
    {
        static void Main(string[] args)
        {
            bool listDone = false;
            string reply = "";
            while (!listDone)
            {
                Console.Clear();
                reply = Prompt("(A)dd dog\n\n(R)emove dog\n\n(V)iew all dogs\n\nView (O)ne dog information\n\n(U)pdate dog information\n\n(E)xit program\n");
                switch (reply.ToLower())
                {
                    case "e":
                        listDone = true;
                        break;
                    case "a":
                        AddDog();
                        break;
                    case "v":
                        ViewAllDogs();
                        Console.ReadLine();
                        break;
                    case "o":
                        ViewOneDog();
                        Console.ReadLine();
                        break;
                    case "r":
                        RemoveDog();
                        break;
                    case "u":
                        UpdateDog();
                        break;
                    default:
                        Console.WriteLine("That doesn't make much sense, does it?");
                        break;
                }
            }
        }
        static string Prompt(string question)
        {
            Console.WriteLine(question);
            string input = Console.ReadLine();
            return input;
        }
        static void AddDog()
        {
            DogVM dog = new DogVM();
            Logic logic = new Logic();
            dog.Name = Prompt("What is the dog's name?");
            dog.Age = Convert.ToInt32(Prompt("What is the dog's age?"));
            dog.Weight = Convert.ToInt32(Prompt("What is the dog's weight?"));
            dog.Breed = Prompt("What is the dog's breed?");
            logic.AddDog(dog);
        }
        static void ViewAllDogs()
        {
            Logic logic = new Logic();
            List<DogVM> dogs = logic.GetAllDogs();
            foreach (DogVM dog in dogs)
            {
                Console.WriteLine(dog.DogId + ": " + dog.Name);
            }
        }
        static void ViewOneDog()
        {
            Logic logic = new Logic();
            List<DogVM> dogs = logic.GetAllDogs();
            string name = Prompt("Which dog do you want to view?");
            foreach (DogVM dog in dogs)
            {
                if (dog.Name == name)
                {
                    Console.WriteLine(dog.DogId + ": " + dog.Name + ", a(n) " + dog.Breed + ", age " + dog.Age + ", that weighs " + dog.Weight + " pound(s).");
                }
            }
        }
        static void RemoveDog()
        {
            Logic logic = new Logic();
            List<DogVM> dogs = logic.GetAllDogs();
            string name = Prompt("Which dog do you want to remove?");
            for (int i = 0; i < dogs.Count; i++)
            {
                if ((dogs[i].Name) == name)
                {
                    logic.DeleteDog((dogs[i].DogId));
                }
            }
        }
        static void UpdateDog()
        {
            Logic logic = new Logic();
            DogVM dog = logic.GetDogByName(Prompt("Which dog's information do you want to update?"));
            string additional = "yes";
            while (additional == "yes" || additional == "y")
            {
                Console.Clear();
                switch (Prompt("Which information do you want to update\n(N)ame\n(A)ge\n(W)eight\n(B)reed?").ToLower())
                {
                    case "n":
                        dog.Name = Prompt("What do you want to change the dog's name?");
                        break;
                    case "a":
                        dog.Age = Convert.ToInt32(Prompt("What do you want to change the dog's age?"));
                        break;
                    case "w":
                        dog.Weight = Convert.ToInt32(Prompt("What do you want to change the dog's weight?"));
                        break;
                    case "b":
                        dog.Breed = Prompt("What do you want to change the dog's breed?");
                        break;
                    default:
                        Console.WriteLine("Type \"N\"");
                        break;
                }
                additional = Prompt("Do you have additional informaton to update on this dog?");
                logic.UpdateDog(dog);
            }
        }
    }
}