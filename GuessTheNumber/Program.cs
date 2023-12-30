using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("English(e) / Turkish(t): ");
            //char langOpt = Convert.ToChar(Console.ReadLine());
            //if (langOpt == 'e') { }

            int userLevel = 1;
            int userScore = 0;
            int remainingAttempt = 3;

            int maxValueOfNum = 6;
            Random rnd = new Random();
            int rndNum = rnd.Next(1, maxValueOfNum);

            int inputNum;
            int levelCounter = 0;
            int winsNeededForLevelUp = 1;


            //FIRST PART
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Welcome to number guessing game. You have a number range getting bigger, when you know the number.\n\nScore: {userScore}\nLevel: {userLevel}\nRemaining Attempt: {remainingAttempt}\nGuessing Range: [1,{maxValueOfNum}]\n\nPress any button for start!\n");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();


            //SECOND PART
            while (remainingAttempt > 0)
            {
                Console.Write("Guess the number: ");
                inputNum = Convert.ToInt32(Console.ReadLine());

                if (inputNum == rndNum)
                {
                    levelCounter += 1;
                    remainingAttempt++;
                    userScore += 10;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congratulations you won!");
                    
                    if(levelCounter >= userLevel * winsNeededForLevelUp)
                    {
                        userLevel++;
                        winsNeededForLevelUp += 1;
                        maxValueOfNum += 2;
                        Console.WriteLine($"\nYou leveled up! New level: {userLevel}");
                    }

                    Console.WriteLine($"\nScore: {userScore}\nLevel: {userLevel}\nRemaining Attempt: {remainingAttempt}\nGuessing Range: [1,{maxValueOfNum - 1}]\n\nPress any button to start!\n");
                    Console.ReadKey();
                    //Console.Clear();
                    Console.ResetColor();

                    rndNum = rnd.Next(1, maxValueOfNum);
                }
                else
                {
                    remainingAttempt--;
                    if (remainingAttempt == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nYou lost the game! Press any key for start again\n");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                        remainingAttempt = 3;
                    }
                }
            }



            Console.ReadKey();
        }
    }
}
