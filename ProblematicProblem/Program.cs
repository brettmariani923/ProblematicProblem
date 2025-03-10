using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    public class Program
    {
        static Random rng = new Random();
        private static List<string> activities = new List<string>()
        { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

        static void Main(string[] args)
        {
            Console.Write(
                "Hello, welcome to the random activity generator!");
            string input;
            bool cont = false;

            while (!cont)
            {
                Console.Write("Would you like to generate a random activity? yes/no: ");
                input = Console.ReadLine().Trim().ToLower();
                if (input == "yes" || input == "y")
                {
                    cont = true;
                }
                else if (input == "no" || input == "no thanks")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Please enter a valid response (yes/no).");
                }
            }
             

            if (!cont) return; 

            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("What is your age? ");
            string ageInput = Console.ReadLine();
            int userAge;
            while (!int.TryParse(ageInput, out userAge))
            {
                Console.WriteLine("Invalid input. Please enter a valid age.");
                ageInput = Console.ReadLine();
            }
            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            input = Console.ReadLine().Trim().ToLower();
            bool seeList = input == "sure";

            if (seeList)
            {
                Console.WriteLine("\nHere are the current activities:");
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250); 
                }

                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                input = Console.ReadLine().Trim().ToLower();
                bool addToList = input == "yes";

                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    Console.WriteLine("\nUpdated activities list:");
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250); 
                    }

                    Console.WriteLine();
                    Console.Write("Would you like to add more? yes/no: ");
                    input = Console.ReadLine().Trim().ToLower();
                    addToList = input == "yes";
                }
            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];

                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }

                Console.WriteLine($"Ah got it! {userName}, your random activity is: {randomActivity}!");
                Console.Write("Is this ok or do you want to grab another activity? Keep/Redo: ");
                input = Console.ReadLine().Trim().ToLower();

                cont = input == "redo";
            }
        }
    }
}