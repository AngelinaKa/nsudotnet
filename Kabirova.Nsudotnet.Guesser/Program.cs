﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guesser
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Random RandomNumOfPhrase = new Random();
            int Number = rand.Next(0, 10);
            string name;
            Console.WriteLine("Hi! Say your name to start the game");
            name = Console.ReadLine();
            Console.WriteLine("Hello, {0}! I thought of a number from 0 to 10, guess what?", name);
            DateTime date1 = DateTime.Now;
            Console.WriteLine(date1);
            string Input ;
            int NumOfAttempts = 1;
            int CounterOfEveryFourthAttempt = 1;
            string[] HistoryOfAttempts = new string[1000];
            string[] Phrases = { "Hey, Hello, you're loser!", "You look so pity, Hello!", "How can be people as unlucky as you, Hello?"};
            int Supposed_Number = Convert.ToInt32(Console.ReadLine());
            while (Supposed_Number != Number)
           {
            if (Supposed_Number > Number)
            { Console.WriteLine("No, your number is bigger");
            HistoryOfAttempts[NumOfAttempts] = Supposed_Number.ToString() + ">";
            }
            if (Supposed_Number < Number)
            {Console.WriteLine("No, your number is smaller");
                HistoryOfAttempts[NumOfAttempts] = Supposed_Number.ToString() + "<";
            }
            Console.WriteLine("Try ones again");
            
                if (CounterOfEveryFourthAttempt == 4)
               {
                   int NumOfPhrase = RandomNumOfPhrase.Next(0, 3);
                   Console.WriteLine("{0}", Phrases[NumOfPhrase].Replace("Hello", name));
                   CounterOfEveryFourthAttempt = 0;
               }
               CounterOfEveryFourthAttempt++;
            Input = Console.ReadLine();
                NumOfAttempts++;
            if (Input == "q") 
            {
                Console.WriteLine("I'm so sorry for my behavior :( Goodbye, {0}! Hope to see your again", name); break;
            }
               if (Input != "q")
                   Supposed_Number = Int32.Parse(Input);
        }
            if (Supposed_Number == Number)
            {
                DateTime date2 = DateTime.Now;
                Console.WriteLine(date2);
                TimeSpan interval = new TimeSpan();
                  interval = date2 - date1;
                  string time = interval.ToString();
                Console.WriteLine(time);
                HistoryOfAttempts[NumOfAttempts] = Supposed_Number.ToString() + "=";
            Console.WriteLine("you won, you've done {0} attempts",NumOfAttempts);
        }
           Console.WriteLine(HistoryOfAttempts[0]);
          int n=1
              ;
            while (n!= NumOfAttempts+1)
            {Console.WriteLine(HistoryOfAttempts[n]);
            n++;}
            Console.ReadKey();
        }
    }
}