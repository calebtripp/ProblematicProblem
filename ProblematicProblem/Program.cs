using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    public class Program
    {
        static Random rng = new Random();
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies\n", "Paintball\n", "Bowling\n", "Lazer Tag\n", "LAN Party\n", "Hiking\n", "Axe Throwing\n", "Wine Tasting\n" };

        public static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? Please type yes or no to continue: ");
            string start = Console.ReadLine().ToLower();

            if (start == "no")
            {
                Console.WriteLine("OK, Bye!");
                return; // closes out program
            }

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("What is your age? ");
            int userAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Would you like to see the current list of activities? Please type yes or no to continue:");
            var seeList = Console.ReadLine().ToLower();
            Console.WriteLine();

            if (seeList == "yes")
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity}");
                    Thread.Sleep(250);
                }

                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? Please type yes or no to continue:");
                var addToList = Console.ReadLine().ToLower();

                while (addToList == "yes")
                {
                    Console.Write("What would you like to add?");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);

                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity}\n");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();

                    Console.WriteLine("Would you like to add more? Please type yes or no to continue:");
                    addToList = Console.ReadLine().ToLower();
                }
            }

            while (start == "yes")
            {
                Console.Write("Connecting to the database");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(10);
                }

                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(10);
                }

                Console.WriteLine();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];

                if (userAge < 21 && randomActivity == "Wine Tasting\n")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }

                Console.Write($"Ah got it! {userName}, your random activity is:{randomActivity}! \nWould you like to continue with this activity? Please type yes or no to continue:");
                var likeAct = Console.ReadLine();

                if (likeAct == "yes")
                {
                    Console.WriteLine("Great! Have Fun!");
                    return;
                }
            }
        }
    }
}