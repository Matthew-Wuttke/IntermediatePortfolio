//Matthew Wuttke
using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace IntermPortfolio
{

    public enum Direction { North, South };
    class Homer
    {
        //data members
        ArrayList northBank; //object reference
        ArrayList southBank;
        Direction location;  //could have been a string - enum two choices.

        public Homer()  //constructor
        {
            northBank = new ArrayList(); //instantiated
            southBank = new ArrayList();

            location = Direction.North; //
            //adds strings to the northBank array
            northBank.Add("Maggie");
            northBank.Add("Poison");
            northBank.Add("Dog");

        }
        public Direction Location
        {
            get { return location; }
        }

        public string NorthBank()
        {            
            string output = "";
            //loops for each subscript in the arraylist
            foreach (string value in northBank)
            {
                output = output + value + '\n';
            }

            return output;
        }
        public string SouthBank()
        {
            string output = "";
            //loops for each subscript in the arraylist
            foreach (string value in southBank)
            {
                output = output + value + '\n';
            }

            return output;
        }

        public void Move(string choice)
        {
            //if Homer is at north -> moving south
            //if Homer is at south -> moving north

            if (location == Direction.North) //Homer is at the North -moving South
            {
                if (northBank.Contains(choice))
                {
                    northBank.Remove(choice);
                    southBank.Add(choice);                    
                }
                location = Direction.South;               
            }
            else if (location == Direction.South) //Homer is at South - moving North
            {               
                    if (southBank.Contains(choice)) // is the choice in the southBank arraylist
                    {
                        southBank.Remove(choice);
                        northBank.Add(choice);
                    }
                    location = Direction.North;         
             }
        }
        public bool DetermineWin()
        {
            bool won = false; //if everyone isn't on the south bank set to false
            if (southBank.Contains("Maggie") == true && southBank.Contains("Poison") == true && southBank.Contains("Dog") == true) // are Maggie, the poison, and the dog on the south bank.
            {
                won = true;                     //if so you win
            }
            return won; 
        }

        public bool MaggieAtePoison()
        {
            bool poisonEaten = false;

            if (location == Direction.South) //Homer at south bank
            {
                if (northBank.Contains("Maggie") == true && northBank.Contains("Poison") == true && northBank.Contains("Dog") == false)// are Maggie, the poison on the same bank without the dog or Homer present
                {
                    poisonEaten = true;         //if so Maggie ate the poison
                }
            }
            else //Homer North Bank
            {
                if (southBank.Contains("Maggie") == true && southBank.Contains("Poison") == true && southBank.Contains("Dog") == false)// are Maggie, the poison on the same bank without the dog or Homer present
                {
                    poisonEaten = true;         //if so Maggie ate the poison
                }
            }
            return poisonEaten;
        }
        public bool DogAttackedMaggie()
        {
            bool maggieAttacked = false;

            if (location == Direction.South) //Homer at south bank
            {

                if (northBank.Contains("Maggie") == true && northBank.Contains("Dog") == true && northBank.Contains("Poison") == false) // are Maggie, and Dog on the same bank without the poison or Homer present
                {
                    maggieAttacked = true;      //if so Dog attacked Maggie
                }
            }
            else //Homer North Bank
            {
                if (southBank.Contains("Maggie") == true && southBank.Contains("Dog") == true && southBank.Contains("Poison") == false)
                {
                    maggieAttacked = true;      //if so Dog attacked Maggie
                }
         
            }
            return maggieAttacked;

        }
        public bool HomerAlone()
        {
            bool lonelyHomer = false;

            if (location == Direction.South) //Homer at south bank
            {
                if (northBank.Contains("Maggie") == true && northBank.Contains("Poison") == true && northBank.Contains("Dog") == true)// are Maggie, the poison, and the dog on the north bank without Homer present
                {
                    lonelyHomer = true;         //if so everyone was left behind
                }
            }
            return lonelyHomer;
        }
        public bool GameOver()
        {
            bool endOfGame = false;     //defaults the ending of the game to false
            if (MaggieAtePoison() == true || DogAttackedMaggie() == true || HomerAlone() == true || DetermineWin() == true) //if the player won or cause Maggie and Dog or cause Maggie and the poison to be together
            {
                endOfGame = true; //end the game
            }
            return endOfGame;
        }

    } //class
}