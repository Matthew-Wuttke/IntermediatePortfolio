//Matthew Wuttke
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntermPortfolio
{

    class HomerUI
    {
        //class level
        Homer thelogic; //object variable - Declared!! - No New();

        void Welcome()
        {
            System.Console.WriteLine("************************************\n       Welcome to Homer game" +
                "\n************************************\n");            
        }
        public void MainMethod()
        {
            do
            {
                Welcome();
                System.Console.WriteLine("Your options are to enter:\n Dog\n Maggie\n Poison\n");
                Play(); //call play
            } while (PlayAgain() == true); //keep running as long as the user says yes
        }
        private void Play()
        {
            string choice;            

            thelogic = new Homer(); //instantiated Created in memory.

            //no DataType

            do
            {                
                DisplayGameState();

                choice = PromptUserforMove(); //prompt the user for input               
                thelogic.Move(choice);        //move the choice from the containing arrayList into the non-containing one
                System.Console.Clear();                              
            } while (thelogic.GameOver() == false);//keep running until the game ends
            
            if (thelogic.MaggieAtePoison() == true) //if game ended on Maggie eating poison
            {
                DisplayGameState(); //display why the game ended
                System.Console.WriteLine("\nGAMEOVER!!\n\nYou lose - Maggie got a hold of poison\n");
            }
            if (thelogic.DogAttackedMaggie() == true)//if game ended on Dog attacked Maggie
            {
                DisplayGameState(); //display why the game ended
                System.Console.WriteLine("\nGAMEOVER!!\n\nYou lose -  Dog attacked Maggie\n");
            }
            if (thelogic.HomerAlone() == true)//if game ended on Dog attacked Maggie
            {
                DisplayGameState(); //display why the game ended
                System.Console.WriteLine("\nGAMEOVER!!\n\nYou lose -  Homer left everyone behind\n");
            }
            if (thelogic.DetermineWin() == true)//if game ended on Player won
            {
                DisplayGameState(); //display why the game ended
                System.Console.WriteLine("\nGAMEOVER!!\n\nYou win -  Everyone has made it to the South Bank\n");
            }               
        }
        private string PromptUserforMove()
        {
            System.Console.Write("What would you like to move across the river? ");
            return ProcessChoice(System.Console.ReadLine());
            
        }
        private string ProcessChoice(string choice)
        {
            if (choice.Equals(string.Empty)) //test to see if the user hit enter with no 
            {
                choice = " ";
            }
            switch (choice.ToUpper().Substring(0, 1))//test to see what the user entered fits any of the following cases
            {
                case "D":
                    {
                        choice = "Dog";
                        break;
                    }
                case "M":
                    {
                        choice = "Maggie";
                        break;
                    }
                case "P":
                    {
                        choice = "Poison";
                        break;
                    }
                case " ":
                    {
                        break;
                    }
                default:
                    {
                        choice = PromptUserforMove();
                        break;
                    }                    
            }
            return choice;
        }
        private bool PlayAgain()
        {
            string replay;
            //Ask the user to see if they want to play again
            System.Console.Write("Would you like to play again? (y or n) ");
            replay =System.Console.ReadLine();

            if (replay.Equals("y"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }        

        void DisplayGameState()
        {   
            //state where the game is
            System.Console.WriteLine("\nHomer is contemplating on the " + thelogic.Location + " bank.\n");
            DisplayNorthBank();
            DisplayRiver();
            DisplaySouthBank();
        }
        void DisplayRiver() //displays the river
        {
            System.Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~");
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~");
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~\n");
        }
        void DisplayNorthBank() //Displays what is in the North Bank
        {
            System.Console.WriteLine("North Bank");
            System.Console.WriteLine("-----------");
            System.Console.WriteLine(thelogic.NorthBank());
        }
        void DisplaySouthBank() //Displays what is in the South Bank
        {
            System.Console.WriteLine("South Bank");
            System.Console.WriteLine("-----------");
            System.Console.WriteLine(thelogic.SouthBank());
        }
    }
}
