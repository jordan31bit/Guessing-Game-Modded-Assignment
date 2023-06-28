using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessing_Game_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int randomNum, minNum, maxNum, numOfGuesses, numOfRounds, userInput, lowestNumOfGuesses;
            bool wantsToPlay = false;
            string replayInput;
            minNum = 1;
            maxNum = 20;

            // Banner that displays only once at start of the program.
            Console.WriteLine("#####################################################");
            Console.WriteLine("####                                             ####");
            Console.WriteLine("####        RANDOM NUMBER GUESSING GAME          ####");
            Console.WriteLine("####                                             ####");
            Console.WriteLine("#####################################################");
            Console.WriteLine(); // Adding another new line.

            // Creates RNG and sets variables for start of the first game.
            Random rng = new Random();
            numOfRounds = 0;
            lowestNumOfGuesses = int.MaxValue; // This needs a initial value such as high values.

            // Generates new number within range and asks the user to guess the number.
            // If user guesses wrong then the nested loop repeats until the user guesses correctly.
            // We also track the number of guesses and rounds in the following code to later output in results.
            // The inner loop represents the current game and the outer loop represents a new game.
            do
            {
                // Resets for repeatly used variables when a new game start.
                numOfGuesses = 0;
                userInput = int.MaxValue; // Reset this var for every new game. Don't want it accidently
                                          // matching the rng before we even play.

                numOfRounds++; // Increament the number of rounds the user plays by 1.

                // Display new game round banner.
                Console.WriteLine("#####################################################");
                Console.WriteLine("####                   ROUND {0}                    ###", numOfRounds);
                Console.WriteLine("#####################################################");
                Console.WriteLine(); // Adding another new line.

                randomNum = rng.Next(minNum, maxNum);
                //Console.WriteLine(randomNum); uncomment if you want to know the random num.
                Console.Write("Guess a number between {0} and {1}: ", minNum, maxNum);

                while (userInput != randomNum)
                {
                    userInput = Convert.ToInt16(Console.ReadLine());
                    numOfGuesses++; // Starts from zero and increments.

                    if (userInput > randomNum)
                    {
                        Console.Write("Sorry, too HIGH! Please try again: ");
                    }
                    else if (userInput < randomNum)
                    {
                        Console.Write("Too LOW! Try again: ");
                    }
                    else
                    {
                        Console.WriteLine("Congrats! You guessed correctly.");
                    }
                }

                // Ask the user if they want to play again. Then attempt to convert their response
                // to uppercase. 
                Console.Write("Do you want to play again? ('yes', 'no'): ");
                replayInput = Console.ReadLine();
                replayInput = replayInput.ToUpper();
                // Checks if input is yes or no and set boolean flags. Determines if do while loop
                // exits.
                if (replayInput == "YES")
                {
                    // Set wantsToPlay flag to TRUE.
                    wantsToPlay = true;
                }
                else
                {
                    // Set flag to false if user enter input other than "yes".
                    wantsToPlay = false;
                }

                // This checks if current number of guesses is lower than previous. If lower than previous replace.
                // This is used in displaying the results.
                if (numOfGuesses < lowestNumOfGuesses)
                {
                    lowestNumOfGuesses = numOfGuesses;
                }

            } while (wantsToPlay); // This is the flag we use to end the game.

            // Displays the results of the game if you win and the number of guesses.
            Console.WriteLine("\n\n"); // Just adding padding to more seperate results from other content.
            Console.WriteLine("#####################################################");
            Console.WriteLine("####                                             ####");
            Console.WriteLine("####                GAME RESULTS                 ####");
            Console.WriteLine("####                                             ####");
            Console.WriteLine("####  Number of Rounds: {0}                        ####", numOfRounds);
            Console.WriteLine("####  Lowest Number of Guesses: {0}                ####", lowestNumOfGuesses);
            Console.WriteLine("####                                             ####");
            Console.WriteLine("#####################################################");

            Console.Read(); // for debugging only
        }
    }
}
