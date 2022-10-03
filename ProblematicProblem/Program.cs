using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    public static class Program
    {
        static Random rng;
        static bool cont = true;
        static bool stop = false;

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
                string randomActivity = activities[randomNumber].ToString();   
                
                if (userAge !> 21 && randomActivity == "Wine Tasting") 
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                  //  string randomNumber = rng.Next(activities.Count); commenting these two lines out brings errors from 7 to 1. not sure what purpose they serve. 
                  //  string randomActivity = activities[randomNumber];
                }

                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Would you like to continue with this activity? Please type yes or no to continue: ");  // or grab another - back into loop?
                Console.WriteLine();

                 cont = bool.Parse(Console.ReadLine());
            }
        }
    }
}