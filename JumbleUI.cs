using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntermPortfolio
{
    class JumbleUI
    {
        private void DisplayWelcome() //Displays the welcome to the game and the options the player has to pick from
        {

            System.Console.WriteLine("************************************\n       Welcome to Jumble game" +
                "\n************************************\n");
            System.Console.WriteLine("Your options are:\n Enter the word the unscrambled word (Type your guess)\n hint " +
                "(only allowed one hint per word)\n I give up (It will tell you the word)\n");
        }

        public void MainMethod() //The Method that calls everything for the game
        {
            //data member
            string replay;
           
            do 
            {
                Play();
                //Asks the user to play new game
                    System.Console.Write("Would you like to play a new game again? (y or n) ");
                    replay = System.Console.ReadLine();
                    System.Console.WriteLine();
                    replay = LoopCheck(replay);                         //Check to see if the user entered a valid answer, if they said y, run a new game
                    if (replay == "y")
                    {
                        //Clears the console screen for easier to read.
                        System.Console.Clear();
                    }
            } while (replay == "y"); //run the loop until they type n or anything but y.

        }

        private void Play()
        {
            //data members
            bool match;
            string guess;
            string retry;
            

            //loop for the replaying the game
           
            Jumble thegame = new Jumble();                      //Constructor
            DisplayWelcome();                                   //Calls the DisplayWelcome method


            //Loop for the current game
            do
            {
                System.Console.WriteLine(thegame.Displayword);
                System.Console.WriteLine();

                System.Console.Write("What is the word? ");
                guess = System.Console.ReadLine();
                System.Console.WriteLine();

                //Takes what the option user entered and performs it
                switch (guess)
                {
                    case ("I give up"):                        //If they gave up, give them the word and end the attempts for that game
                        {
                            System.Console.WriteLine("The word was: " + thegame.Hiddenword + ".\n");                                
                            retry = "n";
                            break;
                        }
                    case ("hint"):                             //If they ask for a hint, give them their only hint for that game
                        {
                            System.Console.WriteLine("The first letter is: " + thegame.Hint() + ".\n");
                            retry = "y";
                            continue;

                        }
                    default:                                    //If otherwise check the word to see if it's correct
                        {
                            guess = guess.ToLower();            //Changes the guess the user entered into lowercase
                            match = thegame.GuessMatch(guess);  //Checks the guess against the hidden word
                            //If they match, Congratulate them
                            if (match == true)
                            {
                                System.Console.WriteLine("Congratulations, you figured out the word was: " + thegame.Hiddenword + '\n');
                                retry = "n";
                            }
                            //If not offer them the chance to retry.
                            else
                            {
                                System.Console.WriteLine("Sorry, your guess was wrong. \n");
                                retry = null;

                            }
                            break;
                        }
                }

                if (retry == null)
                {
                    System.Console.Write("Would you like to try again? (y or n) ");
                    retry = System.Console.ReadLine();
                    System.Console.WriteLine();
                        
                }

            } while (LoopCheck(retry) == "y");                  //Check to see if the user entered a valid answer, if they said y, rerun the current game loop. 
                                                                //Otherwise, move on.                
        }

        private string LoopCheck(string answer)
        {
            //Converts the user's response into lowercase
            answer = answer.ToLower();
            answer = answer.Substring(0, 1);                        //Grab the first character from the string and st

            if (answer == "y")
            {
                //drop through
            }
            else                                                    //Fail safe for the people that don't type y
            {
                answer = "n";
            }
        
            return answer;
        }

    }
}
